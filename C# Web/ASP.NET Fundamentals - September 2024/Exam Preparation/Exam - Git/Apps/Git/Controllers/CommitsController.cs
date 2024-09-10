using System;
using System.Linq;

using SUS.HTTP;
using SUS.MvcFramework;

using Git.Data;
using Git.Data.Models;
using Git.Services.Contracts;
using Git.ViewModels.Commits;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext dbContext;

        public CommitsController(IValidator validator, ApplicationDbContext dbContext)
        {
            this.validator = validator;
            this.dbContext = dbContext;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("You must be signed in to see this page.");
            }

            var userAllCommits = this.dbContext.Commits
                .Where(x => x.CreatorId == this.GetUserId())
                .Select(x => new AllCommitsViewModel
                {
                    Id = x.Id,
                    RepositoryName = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                })
                .ToList();

            return this.View(userAllCommits);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("You must be signed in to see this page.");
            }

            var repository = this.dbContext.Repositories
                .Where(x => x.Id == id)
                .Select(x => new CommitToRepositoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefault();

            if (repository == null)
            {
                return this.Error("This repository does not exist.");
            }

            return this.View(repository);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitFormModel model)
        {
            if (!this.dbContext.Repositories.Any(x => x.Id == model.Id))
            {
                return this.Error("This repository does not exist.");
            }

            var errors = this.validator.ValidateCommit(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            var commit = new Commit
            {
                Description = model.Description,
                RepositoryId = model.Id,
                CreatedOn = DateTime.UtcNow,
                CreatorId = this.GetUserId(),
            };

            this.dbContext.Commits.Add(commit);
            this.dbContext.SaveChanges();

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("You must be signed in to see this page.");
            }

            var commit = this.dbContext.Commits
                .Where(x => x.CreatorId == this.GetUserId())
                .FirstOrDefault(x => x.Id == id);

            if (commit == null)
            {
                return this.Error("You can delete only your own commits.");
            }

            this.dbContext.Commits.Remove(commit);
            this.dbContext.SaveChanges();

            return this.Redirect("/Commits/All");
        }
    }
}