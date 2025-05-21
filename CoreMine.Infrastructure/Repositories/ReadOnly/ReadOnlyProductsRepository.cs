using CoreMine.Data;
using CoreMine.Data.ReadModels;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using CoreMine.Entities;

namespace CoreMine.Infraestructure.Repositories.ReadOnly
{
    public class ReadOnlyProductsRepository : IReadOnlyProductsRepository
    {
        private readonly AppDbContext _context;

        public ReadOnlyProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> GetQueryable()
        {
            return _context.Products
                .AsQueryable()
                .AsNoTracking();
        }

        //public async Task<(int TotalCount, List<ProductWithCategoryReadModel> Rows)> GetProductsByHierarchyAsync(string? name, string ancestorIdsCsv, int ancestorCount, int skip, int take, CancellationToken cancellationToken)
        //{
        //    var totalSql = @"
        //        WITH Filtered AS (
        //            SELECT *
        //            FROM vw_ProductsWithFullCategoryInfo
        //            WHERE
        //              (@Name IS NULL OR ProductName LIKE '%' + @Name + '%')
        //              AND (@AncestorCount = 0 OR AncestorCategoryId IN (SELECT value FROM STRING_SPLIT(@AncestorIdsCsv, ',')))
        //        )
        //        SELECT COUNT(DISTINCT ProductId) 
        //        FROM Filtered;
        //        ";

        //    await _context.Database.OpenConnectionAsync(cancellationToken);
        //    using var cmd = _context.Database.GetDbConnection().CreateCommand();
        //    cmd.CommandText = totalSql;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Parameters.Add(new SqlParameter("@Name", (object?)name ?? DBNull.Value));
        //    cmd.Parameters.Add(new SqlParameter("@AncestorIdsCsv", ancestorIdsCsv));
        //    cmd.Parameters.Add(new SqlParameter("@AncestorCount", ancestorCount));
        //    var totalObj = await cmd.ExecuteScalarAsync(cancellationToken);
        //    var total = Convert.ToInt32(totalObj);

        //    // 2) Paginación + ranking en SQL
        //    var dataSql = @"
        //        WITH Filtered AS (
        //            SELECT *
        //            FROM vw_ProductsWithFullCategoryInfo
        //            WHERE
        //              (@Name IS NULL OR ProductName LIKE '%' + @Name + '%')
        //              AND (@AncestorCount = 0 OR AncestorCategoryId IN (SELECT value FROM STRING_SPLIT(@AncestorIdsCsv, ',')))
        //        ),
        //        Ranked AS (
        //            SELECT
        //              ProductId,
        //              ProductName,
        //              AncestorCategoryId,
        //              FullCategoryPath,
        //              FullCategoryCode,
        //              ROW_NUMBER() OVER (
        //                 PARTITION BY ProductId
        //                 ORDER BY LEN(FullCategoryCode) DESC
        //              ) AS rn
        //            FROM Filtered
        //        )
        //        SELECT
        //          ProductId,
        //          ProductName,
        //          AncestorCategoryId,
        //          FullCategoryPath,
        //          FullCategoryCode
        //        FROM Ranked
        //        WHERE rn = 1
        //        ORDER BY ProductId
        //        OFFSET @Skip ROWS
        //        FETCH NEXT @Take ROWS ONLY;
        //        ";

        //    var rows = await _context.Set<ProductWithCategoryReadModel>()
        //    .FromSqlRaw(dataSql,
        //        new SqlParameter("@Name", (object?)name ?? DBNull.Value),
        //        new SqlParameter("@AncestorIdsCsv", ancestorIdsCsv),
        //        new SqlParameter("@AncestorCount", ancestorCount),
        //        new SqlParameter("@Skip", skip),
        //        new SqlParameter("@Take", take))
        //    .ToListAsync(cancellationToken);

        //    return (total, rows);
        //}
    }
}
