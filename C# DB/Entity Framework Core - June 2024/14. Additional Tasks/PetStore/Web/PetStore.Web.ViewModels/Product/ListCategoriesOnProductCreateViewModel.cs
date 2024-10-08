﻿using PetStore.Data.Models;
using PetStore.Services.Mapping;

namespace PetStore.Web.ViewModels.Product
{
    public class ListCategoriesOnProductCreateViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}