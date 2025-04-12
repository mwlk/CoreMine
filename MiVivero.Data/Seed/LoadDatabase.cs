using MiVivero.Entities;

namespace MiVivero.Data.Seed
{
    public static class LoadDatabase
    {
        public static async Task InsertData(AppDbContext context)
        {
            if (!context.Products!.Any())
            {
                context.Products.AddRange(new Product
                {
                    Name = "Test 1"
                },
                new Product
                {
                    Name = "Test 2"
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
