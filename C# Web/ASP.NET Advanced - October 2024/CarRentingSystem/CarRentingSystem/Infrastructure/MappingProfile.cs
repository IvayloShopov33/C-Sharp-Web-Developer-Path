using AutoMapper;

using CarRentingSystem.Data.Models;
using CarRentingSystem.Models.Cars;
using CarRentingSystem.Services.Cars;

namespace CarRentingSystem.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<DetailsCarServiceModel, CarFormModel>();
            this.CreateMap<Car, CarServiceModel>();
            this.CreateMap<Category, CarCategoryServiceModel>();
            this.CreateMap<Car, DetailsCarServiceModel>()
                .ForMember(x => x.UserId, cfg => cfg.MapFrom(x => x.Dealer.UserId))
                .ForMember(x => x.Category, cfg => cfg.MapFrom(x => x.Category.Name));
        }
    }
}