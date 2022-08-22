using Microsoft.EntityFrameworkCore;
using UserService.Domain;

namespace UserService.DbContext
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
