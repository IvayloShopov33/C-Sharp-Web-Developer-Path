using CinemaApp.Contracts;
using CinemaApp.Data.Common;
using CinemaApp.Data.Models;

namespace CinemaApp.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly IRepository repository;

        public CinemaService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddCinemaAsync(CinemaModel model)
        {
            if (this.repository.AllReadOnly<Cinema>().Any(c=>c.Name == model.Name))
            {
                throw new ArgumentException($"Cinema with name {model.Name} already exists.");
            }

            var cinema = new Cinema
            {
                Name = model.Name,
                Address = model.Address,
            };

            await this.repository.Add(cinema);
            await this.repository.SaveChangesAsync();
        }
    }
}