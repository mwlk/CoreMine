using Microsoft.EntityFrameworkCore;
using MiVivero.ApplicationBusiness.Interfaces;
using MiVivero.Data;
using MiVivero.Entities;

namespace MiVivero.Repository
{
    public class ProductsRepository : IRepository<Product>
    {
        private readonly AppDbContext _context;

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product entityToAdd, CancellationToken cancellationToken)
        {
            await _context.AddAsync(entityToAdd, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Remove(product);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task EditAsync(Product entityToEdit, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(entityToEdit.Id);

            if (product != null)
            {
                product.Name = entityToEdit.Name;

                _context.Entry(product).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
