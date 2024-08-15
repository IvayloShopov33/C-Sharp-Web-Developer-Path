using AutoMapper;
using PetStore.Services.Mapping;

namespace PetStore.Web.ViewModels.Product
{
    public class DetailsProductViewModel : IMapFrom<PetStore.Data.Models.Product>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<PetStore.Data.Models.Product, DetailsProductViewModel>()
                .ForMember(d => d.CategoryName, mo => mo.MapFrom(s => s.Category.Name));
        }
    }
}