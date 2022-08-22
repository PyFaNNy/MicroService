using Microsoft.EntityFrameworkCore;
using OrderService.Domain;

namespace OrderService.DbContext
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
