using System.Globalization;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models.Game;

using static GameZone.Constants.ModelsValidationConstants;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext dbContext;

        public GameController(GameZoneDbContext dbContext)
            => this.dbContext = dbContext;

        public IActionResult All()
        {
            var games = this.dbContext.Games
                .Where(x => !x.IsDeleted)
                .Select(x => new AllGameViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    ReleasedOn = x.ReleasedOn.ToString(GameReleasedOnDateFormat) ?? string.Empty,
                    Genre = x.Genre.Name,
                    Publisher = x.Publisher.UserName,
                })
                .AsNoTracking()
                .ToList();

            return View(games);
        }

        public IActionResult Add()
        {
            var model = new GameFormModel();
            model.Genres = this.GetAllGenres();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(GameFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            var isReleaseDateValid = DateTime.TryParseExact(formModel.ReleasedOn, GameReleasedOnDateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releasedOnDate);

            if (!isReleaseDateValid)
            {
                ModelState.AddModelError(nameof(formModel.ReleasedOn), "Invalid date format.");

                return View(formModel);
            }

            var game = new Game
            {
                Title = formModel.Title,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                PublisherId = this.GetCurrentUserId(),
                ReleasedOn = releasedOnDate,
                GenreId = formModel.GenreId,
                IsDeleted = false,
            };

            this.dbContext.Games.Add(game);
            this.dbContext.SaveChanges();

            return this.RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var gameById = this.dbContext.Games
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new GameFormModel
                {
                    Title = x.Title,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    ReleasedOn = x.ReleasedOn.ToString(GameReleasedOnDateFormat),
                    GenreId = x.GenreId,
                })
                .FirstOrDefault();

            if (gameById != null)
            {
                gameById.Genres = this.GetAllGenres();
            }

            return this.View(gameById);
        }

        [HttpPost]
        public IActionResult Edit(GameFormModel formModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            var isReleaseDateValid = DateTime.TryParseExact(formModel.ReleasedOn, GameReleasedOnDateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releasedOnDate);

            if (!isReleaseDateValid)
            {
                ModelState.AddModelError(nameof(formModel.ReleasedOn), "Invalid date format.");

                return View(formModel);
            }

            var gameById = this.GetGameById(id);

            if (gameById.PublisherId != this.GetCurrentUserId())
            {
                return this.RedirectToAction("All");
            }

            gameById.Title = formModel.Title;
            gameById.Description = formModel.Description;
            gameById.ImageUrl = formModel.ImageUrl;
            gameById.PublisherId = this.GetCurrentUserId();
            gameById.ReleasedOn = releasedOnDate;
            gameById.GenreId = formModel.GenreId;
            gameById.IsDeleted = false;

            this.dbContext.SaveChanges();

            return this.RedirectToAction("All");
        }

        public IActionResult MyZone()
        {
            var games = this.dbContext.Games
                .Where(x => !x.IsDeleted && x.GamersGames.Any(y => y.GamerId == this.GetCurrentUserId()))
                .Select(x => new AllGameViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    ReleasedOn = x.ReleasedOn.ToString(GameReleasedOnDateFormat) ?? string.Empty,
                    Genre = x.Genre.Name,
                    Publisher = x.Publisher.UserName,
                })
                .AsNoTracking()
                .ToList();

            return this.View(games);
        }

        public IActionResult AddToMyZone(int id)
        {
            var currentUserId = this.GetCurrentUserId();
            var gameById = this.dbContext.Games
                .Where(x => x.Id == id)
                .Include(x => x.GamersGames)
                .FirstOrDefault();

            if (gameById == null || gameById.IsDeleted)
            {
                throw new ArgumentException("Invalid id.");
            }

            if (!gameById.GamersGames.Any(x => x.GameId == id && x.GamerId == currentUserId))
            {
                gameById.GamersGames.Add(new GamerGame
                {
                    GameId = id,
                    GamerId = currentUserId,
                });

                this.dbContext.SaveChanges();
            }
           
            return this.RedirectToAction("MyZone");
        }

        public IActionResult StrikeOut(int id)
        {
            var currentUserId = this.GetCurrentUserId();
            var gameById = this.dbContext.Games
                .Where(x => x.Id == id)
                .Include(x => x.GamersGames)
                .FirstOrDefault();

            if (gameById == null || gameById.IsDeleted)
            {
                throw new ArgumentException("Invalid id.");
            }

            if (gameById.GamersGames.Any(x => x.GameId == id && x.GamerId == currentUserId))
            {
                var gamerGame = gameById.GamersGames
                    .Where(x => x.GameId == id && x.GamerId == currentUserId)
                    .First();

                gameById.GamersGames.Remove(gamerGame);
                this.dbContext.SaveChanges();
            }

            return this.RedirectToAction("MyZone");
        }

        public IActionResult Details(int id)
        {
            var gameById = this.dbContext.Games
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new DetailsGameViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    ReleasedOn = x.ReleasedOn.ToString(GameReleasedOnDateFormat),
                    Publisher = x.Publisher.UserName,
                    Genre = x.Genre.Name,
                })
                .FirstOrDefault();

            if (gameById == null)
            {
                throw new ArgumentException("Invalid id.");
            }

            return this.View(gameById);
        }

        public IActionResult Delete(int id)
        {
            var gameByIdModel = this.dbContext.Games
                .Where(x => x.Id == id && !x.IsDeleted && x.PublisherId == this.GetCurrentUserId())
                .Select(x => new DeleteGameViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Publisher = x.Publisher.UserName,
                })
                .FirstOrDefault();

            if (gameByIdModel == null)
            {
                throw new ArgumentException("Invalid id.");
            }

            return this.View(gameByIdModel);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(DeleteGameViewModel deleteModel)
        {
            var gameById = this.GetGameById(deleteModel.Id);

            gameById.IsDeleted = true;
            this.dbContext.SaveChanges();

            return this.RedirectToAction("All");
        }

        private string GetCurrentUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        private List<Genre> GetAllGenres()
            => this.dbContext.Genres.AsNoTracking().ToList();

        private Game GetGameById(int id)
        {
            var gameById = this.dbContext.Games.Find(id);
            if (gameById == null || gameById.IsDeleted)
            {
                throw new ArgumentException("Invalid id.");
            }

            return gameById;
        }
    }
}