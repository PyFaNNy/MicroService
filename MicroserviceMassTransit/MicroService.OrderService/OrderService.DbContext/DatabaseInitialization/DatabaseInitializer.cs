using Microsoft.Extensions.DependencyInjection;
using OrderService.Domain;

namespace OrderService.DbContext.DatabaseInitialization
{
    public class DatabaseInitializer
    {
        private readonly IApplicationDbContext _dbContext;

        public DatabaseInitializer(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async void SeedAsync()
        {
            if (!_dbContext.Orders.Any())
            {
                var list = new List<Order>
                {
                    new Order
                    {
                        Number ="1232",
                        CreatedDate = DateTime.Now,
                        Description = "The best Order",
                        Id = Guid.Parse("238DFB0B-1A79-4220-89FC-BA8AC9C3D526"),
                        UserId = Guid.Parse("4A4D2E92-47E0-419B-903B-A05FFB90D688")
                    },
                    new Order
                    {
                        Number ="1231",
                        CreatedDate = DateTime.Now,
                        Description = "The worst Order",
                        Id = Guid.Parse("238DFB0B-1A79-4220-89FC-BA8AC9C3D527"),
                        UserId = Guid.Parse("4A4D2E92-47E0-419B-903B-A05FFB90D687")
                    }
                };

                await _dbContext.Orders.AddRangeAsync(list);
                _dbContext.SaveChanges();
            }
        }
    }
}
