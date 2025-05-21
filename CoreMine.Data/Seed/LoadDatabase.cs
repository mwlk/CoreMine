using CoreMine.Entities;

namespace CoreMine.Data.Seed
{
    public static class LoadDatabase
    {
        public static async Task InsertData(AppDbContext context)
        {
            if (!context.ProductCategories.Any())
            {
                var categorias = new List<ProductCategory>
                {
                    new ProductCategory { Code = "1", Name = "Herramientas" },
                    new ProductCategory { Code = "2", Name = "Lubricantes" },
                    new ProductCategory { Code = "3", Name = "Repuestos" },
                    new ProductCategory { Code = "4", Name = "Equipos de Seguridad" }
                };

                var herramientas = categorias.First(c => c.Name == "Herramientas");
                var lubricantes = categorias.First(c => c.Name == "Lubricantes");
                var repuestos = categorias.First(c => c.Name == "Repuestos");

                categorias.AddRange(new[]
                {
                    new ProductCategory { Code = "1", Name = "Manuales", Parent = herramientas },
                    new ProductCategory { Code = "2", Name = "Eléctricas", Parent = herramientas },
                    new ProductCategory { Code = "1", Name = "Aceites", Parent = lubricantes },
                    new ProductCategory { Code = "2", Name = "Grasas", Parent = lubricantes },
                    new ProductCategory { Code = "1", Name = "Motor", Parent = repuestos },
                    new ProductCategory { Code = "2", Name = "Hidráulica", Parent = repuestos },
                    new ProductCategory { Code = "3", Name = "Eléctrico", Parent = repuestos }
                });

                context.ProductCategories.AddRange(categorias);
                await context.SaveChangesAsync();
            }

            if (!context.UnitOfMeasures.Any())
            {
                var unidades = new List<UnitOfMeasure>
                {
                    new UnitOfMeasure { Symbol = "u", Name = "Unidad" },
                    new UnitOfMeasure { Symbol = "kg", Name = "Kilogramo" },
                    new UnitOfMeasure { Symbol = "l", Name = "Litro" },
                    new UnitOfMeasure { Symbol = "m", Name = "Metro" }
                };

                context.UnitOfMeasures.AddRange(unidades);
                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var productCategories = context.ProductCategories.ToList();
                var unitOfMeasures = context.UnitOfMeasures.ToList();

                var products = new List<Product>
                {
                    new Product { Name = "Aceite SAE 15W-40", Category = productCategories.First(c => c.Name == "Aceites"), UnitOfMeasure = unitOfMeasures.First(p => p.Name == "Litro") },
                    new Product { Name = "Grasa multiuso EP-2", Category = productCategories.First(c => c.Name == "Grasas"), UnitOfMeasure = unitOfMeasures.First(p => p.Name == "Litro") },
                    new Product { Name = "Llave Inglesa 12\"", Category = productCategories.First(c => c.Name == "Manuales"), UnitOfMeasure = unitOfMeasures.First(p => p.Name == "Unidad") },
                    new Product { Name = "Taladro Percutor 800W", Category = productCategories.First(c => c.Name == "Eléctricas"),UnitOfMeasure = unitOfMeasures.First(p => p.Name == "Unidad") },
                    new Product { Name = "Filtro de Aceite Komatsu", Category = productCategories.First(c => c.Name == "Motor"), UnitOfMeasure = unitOfMeasures.First(p => p.Name == "Unidad") },
                    new Product { Name = "Manguera Hidráulica Alta Presión", Category = productCategories.First(c => c.Name == "Hidráulica"), UnitOfMeasure = unitOfMeasures.First(p => p.Name == "Unidad") },
                    new Product { Name = "Guantes de Nitrilo Reforzados", Category = productCategories.First(c => c.Name == "Equipos de Seguridad"), UnitOfMeasure = unitOfMeasures.First(p => p.Name == "Unidad") }
                };

                context.Products.AddRange(products);
            }

            if (!context.ProductStateTypes.Any())
            {
                var states = new List<ProductStateType>
                {
                    new ProductStateType { Name = "Operacional" },
                    new ProductStateType { Name = "En Mantenimiento" },
                    new ProductStateType { Name = "Fuera de Servicio" }
                };

                context.ProductStateTypes.AddRange(states);
                await context.SaveChangesAsync();
            }

            if (!context.StockMovementTypes.Any())
            {
                var movementTypes = new List<StockMovementType>
                {
                    new StockMovementType { Name = "Compra", IsPositive = true },
                    new StockMovementType { Name = "Devolución", IsPositive = true },
                    new StockMovementType { Name = "Usado para Reparación", IsPositive = false },
                    new StockMovementType { Name = "Pérdida", IsPositive = false },
                    new StockMovementType { Name = "Ajuste (+)", IsPositive = true },
                    new StockMovementType { Name = "Ajuste (-)", IsPositive = false }
                };

                context.StockMovementTypes.AddRange(movementTypes);
            }

            if (!context.Locations.Any())
            {
                var locations = new List<Location>
                {
                    new Location { Name = "Taller Principal", Description = "Taller de la planta" }
                };

                context.Locations.AddRange(locations);
            }

            await context.SaveChangesAsync();
        }
    }
}
