using Microsoft.EntityFrameworkCore;

namespace WebAppHW11.Repository
{
    public interface IDbContext<T> where T : class
    {
        DbSet<T> Items { get; set; }
        void SaveChanges();
    }
}