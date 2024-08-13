using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Services.Contracts;
using BlogApp.Services.Models;

namespace BlogApp.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext dbContext;

        public ArticleService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(ArticleAddViewModel model, string authorName)
        {
            var authorId = this.dbContext.Users
                .Where(x => x.UserName == authorName)
                .Select(x => x.Id)
                .FirstOrDefault();

            if (!IsValid(model) || authorId == null)
            {
                throw new InvalidDataException();
            }

            await this.dbContext.Articles.AddAsync(new Article
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content,
                Category = model.Category,
                CreatedOn = DateTime.UtcNow,
                AuthorId = authorId,
            });

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ArticleViewModel> GetArticleById(int id)
        {
            var articleById = await this.dbContext.Articles
                .Select(a => new ArticleViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category,
                    CreatedOn = a.CreatedOn,
                    AuthorId = a.AuthorId,
                })
                .FirstOrDefaultAsync(a => a.Id == id);

            var authorUserName = await this.dbContext.Users
                    .Where(x => x.Id == articleById!.AuthorId)
                    .Select(x => x.UserName)
                    .FirstOrDefaultAsync();

            if (articleById == null || authorUserName == null)
            {
                throw new InvalidDataException();
            }

            articleById.Author = authorUserName;

            return articleById;
        }

        public async Task EditArticleById(int id, ArticleEditViewModel model)
        {
            var articleToEdit = await this.dbContext.Articles
                .FirstOrDefaultAsync(a => a.Id == id);

            if (articleToEdit == null)
            {
                throw new InvalidOperationException();
            }

            articleToEdit.Title = model.Title;
            articleToEdit.Content = model.Content;
            articleToEdit.Category = model.Category;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteArticleById(int id)
        {
            var articleToDelete = await this.dbContext.Articles
                .FirstOrDefaultAsync(a => a.Id == id);

            if (articleToDelete == null)
            {
                throw new InvalidOperationException();
            }

            this.dbContext.Articles.Remove(articleToDelete);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<ArticleViewModel>> GetAllArticles()
        {
            var allArticles = await this.dbContext.Articles
                .Select(a => new ArticleViewModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category,
                    CreatedOn = a.CreatedOn,
                    AuthorId = a.AuthorId,
                })
                .ToListAsync();

            foreach (var article in allArticles)
            {
                var authorUserName = await this.dbContext.Users
                    .Where(x => x.Id == article.AuthorId)
                    .Select(x => x.UserName)
                    .FirstOrDefaultAsync();

                if (authorUserName == null)
                {
                    continue;
                }

                article.Author = authorUserName;
            }

            return allArticles;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}