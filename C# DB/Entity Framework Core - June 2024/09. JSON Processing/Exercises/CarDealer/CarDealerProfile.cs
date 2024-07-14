using AutoMapper;
using CarDealer.DTOs;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierInputModel, Supplier>();
            this.CreateMap<ImportPartInputModel, Part>();
            this.CreateMap<ImportCarInputModel, Car>();
            this.CreateMap<ImportCustomerInputModel, Customer>();
            this.CreateMap<ImportSaleInputModel, Sale>();
        }
    }
}