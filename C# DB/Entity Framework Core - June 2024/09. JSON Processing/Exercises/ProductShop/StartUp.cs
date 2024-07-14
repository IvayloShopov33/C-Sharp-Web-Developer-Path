using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main()
        {
            var productShopDbContext = new ProductShopContext();
            productShopDbContext.Database.Migrate();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();

            // Task 1 - Import Users
            string usersJson = File.ReadAllText("../../../Datasets/users.json");
            Console.WriteLine(ImportUsers(productShopDbContext, usersJson));

            // Task 2 - Import Products
            string productsJson = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportProducts(productShopDbContext, productsJson));

            // Task 3 - Import Categories
            string categoriesJson = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportCategories(productShopDbContext, categoriesJson));

            // Task 4 - Import Categories and Products
            string categoriesProductsJson = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(productShopDbContext, categoriesProductsJson));

            // Task 5 - Export Products In Range
            Console.WriteLine(GetProductsInRange(productShopDbContext));

            // Task 6 - Export Sold Products
            Console.WriteLine(GetSoldProducts(productShopDbContext));

            // Task 7 - Export Categories By Products Count
            Console.WriteLine(GetCategoriesByProductsCount(productShopDbContext));

            // Task 8 - Export Users and Products
            Console.WriteLine(GetUsersWithProducts(productShopDbContext));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();
            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var dtoCategoryProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);
            var categoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoryProducts);

            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new { x.Name, x.Price, Seller = $"{x.Seller.FirstName} {x.Seller.LastName}" })
                .OrderBy(x => x.Price)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(productsInRange, jsonSettings);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context.Users
                .Where(x => x.ProductsSold
                    .Where(y => y.BuyerId != null).Count() > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold.Select(y =>
                        new { y.Name, y.Price, BuyerFirstName = y.Buyer.FirstName, BuyerLastName = y.Buyer.LastName })
                })
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(usersWithSoldProducts, jsonSettings);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.Categories
                .OrderByDescending(x => x.CategoriesProducts.Count)
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoriesProducts.Count,
                    AveragePrice = $"{x.CategoriesProducts.Average(x => x.Product.Price):f2}",
                    TotalRevenue = $"{x.CategoriesProducts.Sum(x => x.Product.Price):f2}"
                })
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(categoriesByProductsCount, jsonSettings);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold
                    .Where(y => y.BuyerId != null).Count() > 0)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold.Where(y => y.BuyerId != null).Count(),
                        Products = x.ProductsSold.Where(y => y.BuyerId != null).Select(y => new { y.Name, y.Price })
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Products.Count())
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(new
            {
                UsersCount = users.Count,
                users
            }, jsonSettings);
        }
    }
}