using Microsoft.EntityFrameworkCore;

namespace vue_sample_proj
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<VueSampleModel> VueSample { get; set; }
  }
}
