using Microsoft.EntityFrameworkCore;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.Data;
using CoreMine.Data.ReadModels;
using CoreMine.Entities;
using CoreMine.Models.ViewModels;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyCategoriesRepository : IReadOnlyCategoriesRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> GetQueryable()
        {
            var query = _context.Categories.AsQueryable().AsNoTracking();

            return query;
        }
    }
}
