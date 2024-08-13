using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using BlogApp.Services.Contracts;
using BlogApp.Services.Models;

namespace BlogApp.Web.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.articleService.Add(model, this.User.Identity.Name);

            return RedirectToAction("All", "Article");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("All", "Article");
            }

            var articleById = await this.articleService.GetArticleById(id.Value);

            return View(articleById);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("All", "Article");
            }

            try
            {
                var articleViewModel = await this.articleService.GetArticleById(id.Value);
                var articleEditModel = new ArticleEditViewModel
                {
                    Id = articleViewModel.Id,
                    Title = articleViewModel.Title,
                    Content = articleViewModel.Content,
                    Category = articleViewModel.Category,
                };

                return View(articleEditModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Article");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, ArticleEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!id.HasValue)
            {
                return RedirectToAction("All", "Article");
            }

            try
            {
                await this.articleService.EditArticleById(id.Value, model);

                return RedirectToAction("All", "Article");
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Article");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("All", "Article");
            }

            try
            {
                await this.articleService.DeleteArticleById(id.Value);

                return RedirectToAction("All", "Article");
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Article");
            }
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var articles = await this.articleService.GetAllArticles();

            return View(articles);
        }
    }
}