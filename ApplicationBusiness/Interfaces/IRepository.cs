namespace MiVivero.ApplicationBusiness.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(T entityToAdd, CancellationToken cancellationToken);
        Task EditAsync(T entityToEdit, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
