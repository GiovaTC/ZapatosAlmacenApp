using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ZapatosAlmacenApp.Models;

namespace ZapatosAlmacenApp.Data
{
    public class ApplicationDbContext : DbContext
    {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options) { }

      public DbSet<Zapato> Zapatos { get; set; }
    }
}
