using Microsoft.EntityFrameworkCore;
using BookStore.Backend.Models.Entities;

namespace BookStore.Backend.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
