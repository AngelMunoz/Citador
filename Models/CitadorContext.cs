using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citador.Models
{
  public class CitadorContext : DbContext
  {
    public DbSet<User> Users { get; set; }

    public CitadorContext(DbContextOptions<CitadorContext> options)
      : base(options)
    { }
  }
}
