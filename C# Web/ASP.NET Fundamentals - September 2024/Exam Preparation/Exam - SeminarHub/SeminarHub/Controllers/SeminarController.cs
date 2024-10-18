using System.Globalization;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models.Seminar;

using static SeminarHub.Common.ModelsValidationConstraints;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext dbContext;

        public SeminarController(SeminarHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> All()
        {
            var seminars = await this.dbContext.Seminars
                .Where(x => !x.IsDeleted)
                .Select(x => new AllSeminarViewModel
                {
                    Id = x.Id,
                    Topic = x.Topic,
                    Lecturer = x.Lecturer,
                    Category = x.Category.Name,
                    DateAndTime = x.DateAndTime.ToString(SeminarDateAndTimeDateFormat),
                    Organizer = x.Organizer.UserName,
                })
                .AsNoTracking()
                .ToListAsync();

            return this.View(seminars);
        }

        public async Task<IActionResult> Add()
        {
            var seminarFormModel = new SeminarFormModel();
            seminarFormModel.Categories = await this.GetCategoriesAsync();

            return this.View(seminarFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            var isDateAndTimeValid = DateTime.TryParseExact(formModel.DateAndTime, SeminarDateAndTimeDateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateAndTime);
            if (!isDateAndTimeValid)
            {
                ModelState.AddModelError(nameof(formModel.DateAndTime), "Invalid date format.");

                return View(formModel);
            }

            var seminar = new Seminar
            {
                Id = formModel.Id,
                Topic = formModel.Topic,
                Lecturer = formModel.Lecturer,
                Details = formModel.Details,
                DateAndTime = dateAndTime,
                Duration = formModel.Duration ?? null,
                CategoryId = formModel.CategoryId,
                OrganizerId = this.GetCurrentUserId(),
            };

            await this.dbContext.Seminars.AddAsync(seminar);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var seminarById = await this.dbContext.Seminars
                .Where(x => x.Id == id && !x.IsDeleted && x.OrganizerId == this.GetCurrentUserId())
                .Select(x => new SeminarFormModel
                {
                    Id = x.Id,
                    Topic = x.Topic,
                    Lecturer = x.Lecturer,
                    Details = x.Details,
                    DateAndTime = x.DateAndTime.ToString(SeminarDateAndTimeDateFormat),
                    Duration = x.Duration ?? 0,
                    CategoryId = x.CategoryId,
                })
                .FirstOrDefaultAsync();

            if (seminarById == null)
            {
                return this.BadRequest();
            }

            seminarById.Categories = await this.GetCategoriesAsync();

            return this.View(seminarById);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeminarFormModel formModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            var isDateAndTimeValid = DateTime.TryParseExact(formModel.DateAndTime, SeminarDateAndTimeDateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateAndTime);
            if (!isDateAndTimeValid)
            {
                ModelState.AddModelError(nameof(formModel.DateAndTime), "Invalid date format.");

                return View(formModel);
            }

            var seminarById = await this.GetSeminarByIdAsync(id);
            if (seminarById.OrganizerId != this.GetCurrentUserId())
            {
                return this.RedirectToAction("All");
            }

            seminarById.Id = formModel.Id;
            seminarById.Topic = formModel.Topic;
            seminarById.Lecturer = formModel.Lecturer;
            seminarById.Details = formModel.Details;
            seminarById.DateAndTime = dateAndTime;
            seminarById.Duration = formModel.Duration ?? null;
            seminarById.CategoryId = formModel.CategoryId;
            seminarById.OrganizerId = this.GetCurrentUserId();

            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var seminarById = await this.dbContext.Seminars
                .Where(x => x.Id == id && !x.IsDeleted && x.OrganizerId == this.GetCurrentUserId())
                .Select(x => new DeleteSeminarViewModel
                {
                    Id = x.Id,
                    Topic = x.Topic,
                    DateAndTime = x.DateAndTime,
                })
                .FirstOrDefaultAsync();

            if (seminarById == null)
            {
                return this.BadRequest();
            }

            return this.View(seminarById);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteSeminarViewModel formModel)
        {
            var seminarById = await this.GetSeminarByIdAsync(formModel.Id);

            seminarById.IsDeleted = true;
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> Details(int id)
        {
            var seminarById = await this.dbContext.Seminars
                .Where(x => x.Id == id && !x.IsDeleted)
                .Select(x => new DetailsSeminarViewModel
                {
                    Id = x.Id,
                    Topic = x.Topic,
                    Lecturer = x.Lecturer,
                    Details = x.Details,
                    DateAndTime = x.DateAndTime.ToString(SeminarDateAndTimeDateFormat),
                    Duration = x.Duration ?? 0,
                    Category = x.Category.Name,
                    Organizer = x.Organizer.UserName,
                })
                .FirstOrDefaultAsync();

            if (seminarById == null)
            {
                return this.BadRequest();
            }

            return this.View(seminarById);
        }

        public async Task<IActionResult> Joined()
        {
            var seminars = await this.dbContext.Seminars
                .Where(x => !x.IsDeleted && x.SeminarsParticipants.Any(y => y.ParticipantId == this.GetCurrentUserId()))
                .Select(x => new AllSeminarViewModel
                {
                    Id = x.Id,
                    Topic = x.Topic,
                    Lecturer = x.Lecturer,
                    DateAndTime = x.DateAndTime.ToString(SeminarDateAndTimeDateFormat),
                    Category = x.Category.Name,
                    Organizer = x.Organizer.UserName,
                })
                .AsNoTracking()
                .ToListAsync();

            return this.View(seminars);
        }

        public async Task<IActionResult> Join(int id)
        {
            var currentUserId = this.GetCurrentUserId();
            var seminarById = await this.dbContext.Seminars
                .Where(x => x.Id == id && !x.IsDeleted)
                .Include(x => x.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminarById == null)
            {
                return this.BadRequest();
            }

            if (!seminarById.SeminarsParticipants.Any(x => x.SeminarId == seminarById.Id && x.ParticipantId == currentUserId))
            {
                seminarById.SeminarsParticipants.Add(new SeminarParticipant
                {
                    SeminarId = seminarById.Id,
                    ParticipantId = currentUserId,
                });

                await this.dbContext.SaveChangesAsync();
            }

            return this.RedirectToAction("Joined");
        }

        public async Task<IActionResult> Leave(int id)
        {
            var currentUserId = this.GetCurrentUserId();
            var seminarById = await this.dbContext.Seminars
                .Where(x => x.Id == id && !x.IsDeleted)
                .Include(x => x.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminarById == null)
            {
                return this.BadRequest();
            }

            var seminarParticipant = seminarById.SeminarsParticipants
                .FirstOrDefault(x => x.SeminarId == seminarById.Id && x.ParticipantId == currentUserId);

            if (seminarParticipant != null)
            {
                seminarById.SeminarsParticipants.Remove(seminarParticipant);
                await this.dbContext.SaveChangesAsync();
            }

            return this.RedirectToAction("Joined");
        }

        private async Task<List<Category>> GetCategoriesAsync()
            => await this.dbContext.Categories.AsNoTracking().ToListAsync();

        private string GetCurrentUserId()
            => this.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        private async Task<Seminar> GetSeminarByIdAsync(int id)
        {
            var seminarById = await this.dbContext.Seminars.FindAsync(id);
            if (seminarById == null || seminarById.IsDeleted)
            {
                throw new ArgumentException("Invalid id.");
            }

            return seminarById;
        }
    }
}