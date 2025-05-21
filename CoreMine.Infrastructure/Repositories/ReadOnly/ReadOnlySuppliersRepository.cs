using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlySuppliersRepository : IReadOnlySuppliersRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlySuppliersRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Supplier> GetQueryable()
        {
            return _context.Suppliers
                .AsQueryable()
                .AsNoTracking();
        }
    }
}
