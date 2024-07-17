namespace CinemaApp.Data.Common
{
    public interface IRepository : IDisposable
    {
        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadOnly<T>() where T : class;

        Task<T?> GetByIdAsync<T>(object id) where T : class;

        Task Add<T>(T entity) where T : class;

        Task AddRange<T>(IEnumerable<T> entities) where T : class;

        Task<int> SaveChangesAsync();
    }
}