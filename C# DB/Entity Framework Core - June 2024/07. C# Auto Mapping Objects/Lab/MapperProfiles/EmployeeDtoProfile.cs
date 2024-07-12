using AutoMapper;
using Demo.Data.Models;

namespace Demo.MapperProfiles
{
    public class EmployeeDtoProfile : Profile
    {
        public EmployeeDtoProfile()
        {
            this.CreateMap<Employee, EmployeeDto>()
                    .ForMember(x => x.FullName, options =>
                          options.MapFrom(x => $"{x.FirstName} {x.LastName}"))
                    .ForMember(x => x.AddressText, options =>
                          options.MapFrom(x => x.Address.AddressText))
                    .ForMember(x => x.ManagerFullName, options =>
                          options.MapFrom(x => $"{x.Manager.FirstName} {x.Manager.LastName}"))
                    .ReverseMap();
        }
    }
}