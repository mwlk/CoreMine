using CoreMine.ApplicationBusiness.Common.Pagination;
using CoreMine.ApplicationBusiness.Interfaces.ReadOnly;
using CoreMine.ApplicationBusiness.Interfaces.Shared;
using CoreMine.ApplicationBusiness.UseCases.Repairs.Queries;
using CoreMine.Models.Common;
using CoreMine.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CoreMine.ApplicationBusiness.UseCases.Repairs.Handlers
{
    public class GetRepairsQueryHandler : IQueryHandler<GetRepairsQuery, PagedResult<RepairViewModel>>
    {
        private readonly IReadOnlyRepairsRepository _repository;

        public GetRepairsQueryHandler(IReadOnlyRepairsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<RepairViewModel>> HandleAsync(GetRepairsQuery query, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int pageSize = query.PageSize > 0 ? query.PageSize.Value : 10;
            int pageNumber = query.PageNumber > 0 ? query.PageNumber.Value : 1;

            var baseQuery = _repository.GetQueryable();

            if (query.Id.HasValue)
            {
                baseQuery = baseQuery.Where(x => x.RepairId == query.Id.Value);
            }

            if (query.Ids.Length > 0)
            {
                baseQuery = baseQuery.Where(x => query.Ids.Contains(x.RepairId));
            }

            if (query.MachineId.HasValue)
            {
                baseQuery = baseQuery.Where(x => x.MachineId == query.MachineId.Value);
            }

            if (query.StartDate.HasValue)
            {
                baseQuery = baseQuery.Where(x => x.StartDate >= query.StartDate.Value);
            }

            if (query.EndDate.HasValue)
                baseQuery = baseQuery.Where(x => x.StartDate <= query.EndDate.Value);

            if (query.MachineIsActive.HasValue)
            {
                baseQuery = baseQuery.Where(x => x.MachineIsActive == query.MachineIsActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(query.MachineCode))
            {
                baseQuery = baseQuery.Where(x => x.MachineCode.Contains(query.MachineCode));
            }

            var groupedQuery = baseQuery
                .GroupBy(p => new
                {
                    p.RepairId,
                    p.StartDate,
                    p.EndDate,
                    p.Description,
                    p.Observations,
                    p.MachineId,
                    p.MachineDescription,
                    p.MachineCode,
                    p.MachineIsActive
                })
                .Select(g => new RepairViewModel
                {
                    Id = g.Key.RepairId,
                    StartDate = g.Key.StartDate,
                    EndDate = g.Key.EndDate,
                    Description = g.Key.Description,
                    Observations = g.Key.Observations,
                    Machine = new MachineViewModel
                    {
                        Id = g.Key.MachineId,
                        Description = g.Key.MachineDescription,
                        Code = g.Key.MachineCode,
                        IsActive = g.Key.MachineIsActive
                    },
                    Products = new List<RepairProductViewModel>() // se carga después
                })
                .OrderByDescending(p => p.StartDate);

            var pagedResult = await groupedQuery.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);

            var repairIds = pagedResult.Items.Select(x => x.Id).ToList();

            var products = await _repository.GetQueryable()
                .Where(p => repairIds.Contains(p.RepairId) && p.ProductId.HasValue)
                .Select(p => new
                {
                    p.RepairId,
                    Product = new RepairProductViewModel
                    {
                        Id = p.ProductId!.Value,
                        Name = p.ProductName!,
                        QuantityUsed = p.QuantityUsed!.Value,
                        UnitPrice = p.UnitPrice!.Value,
                        Category = new CategoryViewModel
                        {
                            Id = p.CategoryId!.Value,
                            Code = p.CategoryCode!,
                            Name = p.CategoryName!
                        },
                        UnitOfMeasure = new UnitOfMeasureViewModel
                        {
                            Id = p.UnitOfMeasureId!.Value,
                            Name = p.UnitOfMeasureName!,
                            Symbol = p.UnitOfMeasureSymbol!
                        }
                    }
                })
                .ToListAsync(cancellationToken);

            var groupedProducts = products
                .GroupBy(p => p.RepairId)
                .ToDictionary(g => g.Key, g => g.Select(x => x.Product).ToList());

            foreach (var repair in pagedResult.Items)
            {
                if (groupedProducts.TryGetValue(repair.Id, out var productList))
                {
                    repair.Products = productList;
                }
            }

            return pagedResult;
        }

    }
}
