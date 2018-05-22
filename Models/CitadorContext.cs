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
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ContactInfo> ContactInfos { get; set; }

    public CitadorContext(DbContextOptions<CitadorContext> options)
      : base(options)
    { }
  }
}
