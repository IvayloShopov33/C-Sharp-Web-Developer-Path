using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using AutoMapper;

using PetStore.Data.Models;
using PetStore.Services.Data.Contracts;
using PetStore.Services.Mapping;
using PetStore.Web.ViewModels.Product;
using PetStore.Common;

namespace PetStore.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var allCategories = this.categoryService.All().To<ListCategoriesOnProductCreateViewModel>().ToArray();

            return View(allCategories);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(CreateProductInputModel model)
        {
            if (!ModelState.IsValid || !this.categoryService.ExistsById(model.CategoryId))
            {
                return RedirectToAction("Create", "Product");
            }

            var product = AutoMapperConfig.MapperInstance.Map<Product>(model);
            await this.productService.AddProductAsync(product);

            return RedirectToAction("All", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var product = await this.productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var viewModel = AutoMapperConfig.MapperInstance.Map<DetailsProductViewModel>(product);

            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var product = await this.productService.GetProductByIdAsync(id);

                var viewModel = new EditProductViewModel
                {
                    Name = product.Name,
                    Price = product.Price,
                    ImageURL = product.ImageURL,
                    CategoryId = product.CategoryId,
                    CategoryName = this.productService
                        .GetAllProductsCategories()
                        .FirstOrDefault(categoryName => categoryName == product.Category.Name),
                    Categories = this.categoryService.All().To<ListCategoriesOnProductCreateViewModel>().ToArray(),
                };

                return View(viewModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Product");
            }
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id, EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.productService.EditProductByIdAsync(id, model);

                return RedirectToAction("All", "Product");
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Product");
            }
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.productService.DeleteProductByIdAsync(id);

                return RedirectToAction("All", "Product");
            }
            catch (Exception e)
            {
                return RedirectToAction("All", "Product");
            }
        }

        [HttpGet]
        public IActionResult All(string search)
        {
            var allProducts = this.productService.GetAllProductsByName(search);
            var categories = this.productService.GetAllProductsCategories();

            var viewModel = new AllProductsViewModel
            {
                AllProducts = allProducts.To<ListAllProductViewModel>().ToArray(),
                Categories = categories,
                SearchQuery = search,
            };

            return View(viewModel);
        }
    }
}