using Microsoft.Extensions.DependencyInjection;
using UserService.DbContext;
using UserService.Domain;

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
            if (!_dbContext.Users.Any())
            {
                var list = new List<User>
                {
                    new User
                    {
                        FirstName = "Artem",
                        LastName = "Puzyrev",
                        BirthDate = new DateTime(2001, 11, 27),
                        Id = Guid.Parse("4A4D2E92-47E0-419B-903B-A05FFB90D688")
                    },
                    new User
                    {
                        FirstName = "Anton",
                        LastName = "Goncharov",
                        BirthDate = new DateTime(2000, 01, 01),
                        Id = Guid.Parse("4A4D2E92-47E0-419B-903B-A05FFB90D687")
                    }
                };

                await _dbContext.Users.AddRangeAsync(list);
                _dbContext.SaveChanges();
            }
        }
    }
}
