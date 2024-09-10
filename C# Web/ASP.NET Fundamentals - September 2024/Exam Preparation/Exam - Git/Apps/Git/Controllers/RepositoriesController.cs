using System;
using System.Linq;

using SUS.HTTP;
using SUS.MvcFramework;

using Git.Data;
using Git.Services.Contracts;
using Git.ViewModels.Repositories;
using Git.Data.Models;

using static Git.Data.ModelsValidationConstraints;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext dbContext;

        public RepositoriesController(IValidator validator, ApplicationDbContext dbContext)
        {
            this.validator = validator;
            this.dbContext = dbContext;
        }

        public HttpResponse All()
        {
            var publicRepositories = this.dbContext.Repositories
                .Where(x => x.IsPublic || (!x.IsPublic && x.OwnerId == this.GetUserId()))
                .Select(x => new AllRepositoriesViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    OwnerUsername = x.Owner.Username,
                    RepositoryType = x.IsPublic ? RepositoryTypePublic : RepositoryTypePrivate,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Commits = x.Commits.Count,
                })
                .ToList();

            return this.View(publicRepositories);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("You must be signed in to see this page.");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryFormModel model)
        {
            var errors = this.validator.ValidateRepository(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = model.RepositoryType == RepositoryTypePublic,
                OwnerId = this.GetUserId(),
            };

            this.dbContext.Repositories.Add(repository);
            this.dbContext.SaveChanges();

            return this.Redirect("/Repositories/All");
        }
    }
}