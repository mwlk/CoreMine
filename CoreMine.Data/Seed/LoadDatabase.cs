using CoreMine.Entities;

namespace CoreMine.Data.Seed
{
    public static class LoadDatabase
    {
        public static async Task InsertData(AppDbContext context)
        {
            if (!context.Categories!.Any())
            {
                var plantas = new ProductCategory
                {
                    Code = "1",
                    Name = "Plantas",
                };

                var herramientas = new ProductCategory
                {
                    Code = "2",
                    Name = "Herramientas"
                };

                var sustratos = new ProductCategory
                {
                    Code = "3",
                    Name = "Sustratos"
                };

                var plantas_arboles = new ProductCategory
                {
                    Code = "1",
                    Name = "Árboles",
                    Parent = plantas
                };

                var plantas_arbustos = new ProductCategory
                {
                    Code = "2",
                    Name = "Arbustos",
                    Parent = plantas
                };

                var plantas_flores = new ProductCategory
                {
                    Code = "3",
                    Name = "Flores",
                    Parent = plantas
                };

                var herramientas_jardineria = new ProductCategory
                {
                    Code = "1",
                    Name = "Jardineria",
                    Parent = herramientas
                };

                var herramientas_riego = new ProductCategory
                {
                    Code = "2",
                    Name = "Riego",
                    Parent = herramientas
                };

                context.Categories.AddRange(plantas, herramientas, sustratos, 
                    plantas_arboles, plantas_arbustos, plantas_flores,
                    herramientas_jardineria, herramientas_riego);

                await context.SaveChangesAsync();
            }

            if (!context.Products!.Any())
            {
                var flores_1 = new Product
                {
                    Name = "Rosa",
                    Category = context.Categories.First(c => c.Code == "3" && c.Name == "Flores") 
                };

                var arboles_1 = new Product
                {
                    Name = "Abeto",
                    Category = context.Categories.First(c => c.Code == "1" && c.Name == "Árboles") 
                };

                var jardineria_1 = new Product
                {
                    Name = "Tijeras de Jardinería",
                    Category = context.Categories.First(c => c.Code == "1" && c.Name == "Jardineria") 
                };

                var sustratos_1 = new Product
                {
                    Name = "Sustrato Orgánico",
                    Category = context.Categories.First(c => c.Code == "3" && c.Name == "Sustratos") 
                };

                context.Products.AddRange(flores_1, arboles_1, jardineria_1, sustratos_1);
            }

            await context.SaveChangesAsync();

        }
    }
}
