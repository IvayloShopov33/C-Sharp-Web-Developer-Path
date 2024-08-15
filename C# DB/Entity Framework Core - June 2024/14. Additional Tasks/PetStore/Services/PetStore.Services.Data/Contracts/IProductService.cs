using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using PetStore.Data.Models;
using PetStore.Web.ViewModels.Product;

namespace PetStore.Services.Data.Contracts
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProductsByName(string nameSearch = "");

        IQueryable<Product> GetAllProductsByCategory(string categoryNameSearch = "");

        ICollection<string> GetAllProductsCategories();

        Task<Product> GetProductByIdAsync(string id);

        Task AddProductAsync(Product product);

        Task EditProductByIdAsync(string id, EditProductViewModel model);

        Task DeleteProductByIdAsync(string id);
    }
}