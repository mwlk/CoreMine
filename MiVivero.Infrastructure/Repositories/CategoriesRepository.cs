using Microsoft.EntityFrameworkCore;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.Data;
using MiVivero.Entities;

namespace MiVivero.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _context;

        public CategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Category entityToAdd, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Category entityToEdit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        
    }
}
