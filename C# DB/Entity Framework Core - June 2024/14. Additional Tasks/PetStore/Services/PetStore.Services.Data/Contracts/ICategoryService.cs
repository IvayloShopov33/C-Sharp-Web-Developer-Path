using System.Linq;

using PetStore.Data.Models;

namespace PetStore.Services.Data.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Category> All();

        bool ExistsById(int id);
    }
}