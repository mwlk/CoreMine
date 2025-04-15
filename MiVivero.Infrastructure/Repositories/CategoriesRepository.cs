using MiVivero.Entities;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.Models.Filters;
using MiVivero.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Category>> GetByFilterAsync(CategoryFilter filter, CancellationToken cancellationToken)
        {
            var query = _context.Categories
                .Include(c => c.Parent)
                .AsNoTracking()
                .AsQueryable();

            if (filter.Id.HasValue)
            {
                query = query.Where(p => p.Id == filter.Id.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name));
            }

            return await query.ToListAsync(cancellationToken);
        }

        public Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        
    }
}
