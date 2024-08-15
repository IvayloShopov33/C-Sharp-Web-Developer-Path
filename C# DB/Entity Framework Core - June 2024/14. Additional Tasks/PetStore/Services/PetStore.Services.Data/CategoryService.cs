using System.Linq;
using System.Collections.Generic;

using PetStore.Data.Common.Repositories;
using PetStore.Data.Models;
using PetStore.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PetStore.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepo;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public IQueryable<Category> All()
        {
            return this.categoryRepo
                .AllAsNoTracking();
        }

        public bool ExistsById(int id)
        {
            return this.categoryRepo
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Id == id) != null;
        }
    }
}