using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PetStore.Data.Common.Repositories;
using PetStore.Data.Models;
using PetStore.Services.Data.Contracts;
using PetStore.Web.ViewModels.Product;

namespace PetStore.Services.Data
{
    public class ProductService : IProductService
    {
        private const string EmptyString = "";

        private readonly IDeletableEntityRepository<Product> productRepo;

        public ProductService(IDeletableEntityRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }

        public IQueryable<Product> GetAllProductsByName(string nameSearch = EmptyString)
        {
            if (nameSearch != EmptyString && nameSearch != null)
            {
                return this.productRepo
                    .AllAsNoTracking()
                    .Where(x => x.Name.ToLower().Contains(nameSearch.ToLower()));
            }

            return this.productRepo
                .AllAsNoTracking();
        }

        public IQueryable<Product> GetAllProductsByCategory(string categoryNameSearch = EmptyString)
        {
            if (categoryNameSearch != EmptyString && categoryNameSearch != null)
            {
                return this.productRepo
                    .AllAsNoTracking()
                    .Where(x => x.Category.Name.ToLower().Contains(categoryNameSearch.ToLower()));
            }

            return this.productRepo
                .AllAsNoTracking();
        }

        public ICollection<string> GetAllProductsCategories()
        {
            return this.productRepo
                .AllAsNoTracking()
                .Select(x => x.Category.Name)
                .Distinct()
                .ToArray();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await this.productRepo
                .All()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddProductAsync(Product product)
        {
            await this.productRepo.AddAsync(product);
            await this.productRepo.SaveChangesAsync();
        }

        public async Task EditProductByIdAsync(string id, EditProductViewModel model)
        {
            var productToEdit = await this.productRepo
                .All()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (productToEdit == null)
            {
                throw new InvalidOperationException();
            }

            productToEdit.Name = model.Name;
            productToEdit.Price = model.Price;
            productToEdit.ImageURL = model.ImageURL;
            productToEdit.CategoryId = model.CategoryId;

            await this.productRepo.SaveChangesAsync();
        }

        public async Task DeleteProductByIdAsync(string id)
        {
            var productToDelete = await this.productRepo
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (productToDelete == null)
            {
                throw new InvalidOperationException();
            }

            this.productRepo.Delete(productToDelete);
            await this.productRepo.SaveChangesAsync();
        }
    }
}