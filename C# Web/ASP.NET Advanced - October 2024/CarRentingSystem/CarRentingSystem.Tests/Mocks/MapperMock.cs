﻿using AutoMapper;

using CarRentingSystem.Infrastructure;

namespace CarRentingSystem.Tests.Mocks
{
    public static class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

                return new Mapper(mapperConfiguration);
            }
        }
    }
}