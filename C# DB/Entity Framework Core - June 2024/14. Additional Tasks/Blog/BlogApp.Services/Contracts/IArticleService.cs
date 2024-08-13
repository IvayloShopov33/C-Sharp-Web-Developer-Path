using BlogApp.Services.Models;

namespace BlogApp.Services.Contracts
{
    public interface IArticleService
    {
        Task Add(ArticleAddViewModel model, string authorName);

        Task<ArticleViewModel> GetArticleById(int id);

        Task EditArticleById(int id, ArticleEditViewModel model);

        Task DeleteArticleById(int id);

        Task<List<ArticleViewModel>> GetAllArticles();
    }
}