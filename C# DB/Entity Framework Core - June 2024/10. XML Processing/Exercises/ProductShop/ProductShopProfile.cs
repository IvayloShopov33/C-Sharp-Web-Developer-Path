using AutoMapper;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserInputModel, User>();
            this.CreateMap<ImportProductInputModel, Product>();
            this.CreateMap<ImportCategoryInputModel, Category>();
            this.CreateMap<ImportCategoryProductInputModel, CategoryProduct>();
        }
    }
}
