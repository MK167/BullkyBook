using BullkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BullkyBookWeb.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

     
    }
}
