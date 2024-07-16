using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.XML_Helper;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

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
            string usersXml = File.ReadAllText("../../../Datasets/users.xml");
            Console.WriteLine(ImportUsers(productShopDbContext, usersXml));

            // Task 2 - Import Products
            string productsXml = File.ReadAllText("../../../Datasets/products.xml");
            Console.WriteLine(ImportProducts(productShopDbContext, productsXml));

            // Task 3 - Import Categories
            string categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            Console.WriteLine(ImportCategories(productShopDbContext, categoriesXml));

            // Task 4 - Import Categories and Products
            string categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            Console.WriteLine(ImportCategoryProducts(productShopDbContext, categoriesProductsXml));

            // Task 5 - Export Products In Range
            Console.WriteLine(GetProductsInRange(productShopDbContext));

            // Task 6 - Export Sold Products
            Console.WriteLine(GetSoldProducts(productShopDbContext));

            // Task 7 - Export Categories By Products Count
            Console.WriteLine(GetCategoriesByProductsCount(productShopDbContext));

            // Task 8 - Export Users and Products
            Console.WriteLine(GetUsersWithProducts(productShopDbContext));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportUserInputModel[]), new XmlRootAttribute("Users"));
            var textRead = new StringReader(inputXml);
            var dtoUsers = (ImportUserInputModel[])serializer.Deserialize(textRead);
            var users = mapper.Map<User[]>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {context.Users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportProductInputModel[]), new XmlRootAttribute("Products"));
            var textRead = new StringReader(inputXml);
            var dtoProducts = (ImportProductInputModel[])serializer.Deserialize(textRead);
            var products = mapper.Map<Product[]>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {context.Products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryInputModel[]), new XmlRootAttribute("Categories"));
            var textRead = new StringReader(inputXml);
            var dtoCategories = (ImportCategoryInputModel[])serializer.Deserialize(textRead);
            var categories = mapper.Map<Category[]>(dtoCategories);

            categories = categories
                .Where(x => x.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryProductInputModel[]), new XmlRootAttribute("CategoryProducts"));
            var textRead = new StringReader(inputXml);
            var dtoCategoriesProducts = (ImportCategoryProductInputModel[])serializer.Deserialize(textRead);
            var categoriesProducts = mapper.Map<CategoryProduct[]>(dtoCategoriesProducts);

            categoriesProducts = categoriesProducts
                .Where(x => x.ProductId != null && x.CategoryId != null)
                .ToArray();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Select(x => new ExportProductOutputModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerFullName = $"{x.Buyer.FirstName} {x.Buyer.LastName}"
                })
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .ToList();

            return XmlConverter.Serialize(productsInRange, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithTheirSoldProducts = context.Users
                .Where(x => x.ProductsSold.Where(y => y.BuyerId != null).Count() > 0)
                .Select(x => new ExportUserOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(y => new ExportSoldProductOutputModel
                    {
                        Name = y.Name,
                        Price = y.Price
                    })
                    .ToList()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();

            return XmlConverter.Serialize(usersWithTheirSoldProducts, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.Categories
                .Select(x => new ExportCategoriesOutputModel
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(y => y.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(y => y.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            return XmlConverter.Serialize(categoriesByProductsCount, "Categories");
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new ExportNewUserOutputModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new ExportSoldProductsExtendedOutputModel
                    {
                        Count = x.ProductsSold.Count,
                        SoldProducts = x.ProductsSold.Select(y => new ExportSoldProductOutputModel
                        {
                            Name = y.Name,
                            Price = y.Price
                        })
                        .OrderByDescending(y => y.Price)
                        .ToList()
                    }

                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToList();

            var allUsersWithTheirProductsExtended = new ExportAllUsersWithTheirProductsOutputModel
            {
                Count = usersWithProducts.Count,
                Users = usersWithProducts.Take(10).ToList()
            };

            return XmlConverter.Serialize(allUsersWithTheirProductsExtended, "Users");
        }
    }
}