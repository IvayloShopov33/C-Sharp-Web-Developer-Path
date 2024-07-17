using CinemaApp.Data.Models;

namespace CinemaApp.Contracts
{
    public interface ICinemaService
    {
        Task AddCinemaAsync(CinemaModel model);
    }
}