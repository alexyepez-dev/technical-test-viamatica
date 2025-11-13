using Microsoft.EntityFrameworkCore;
using VMT.TechnicalTest.Domain.Entities.User;

namespace VMT.TechnicalTest.Persistence.Context
{
    public class AppDbContext
    (
        DbContextOptions<AppDbContext> options
    ) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
    }
}