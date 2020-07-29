using Microsoft.EntityFrameworkCore;

namespace NonProfit.Models
{
  public class ToDoListContext : DbContext
  {
    public virtual DbSet<Donors> Donors { get; set; }
    public DbSet<Donations> Donations { get; set; }

    public NonProfitContext(DbContextOptions options) : base(options) { }
  }
}