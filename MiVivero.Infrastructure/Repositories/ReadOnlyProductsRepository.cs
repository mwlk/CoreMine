using MiVivero.Data;
using MiVivero.Data.ReadModels;
using MiVivero.ApplicationBusiness.Interfaces;

namespace MiVivero.Infraestructure.Repositories
{
    public class ReadOnlyProductsRepository : IReadOnlyProductsRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProductWithCategoryReadModel> GetQueryable()
        {
            return _context.Set<ProductWithCategoryReadModel>().AsQueryable();
        }
    }
}
