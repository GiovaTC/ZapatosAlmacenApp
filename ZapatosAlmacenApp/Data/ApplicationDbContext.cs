using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ZapatosAlmacenApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ZapatosAlmacenApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options) { }

      public DbSet<Zapato> Zapatos { get; set; }
    }
}
