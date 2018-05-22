using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Citador.Models
{
  public class Address
  {
    public uint Id { get; set; }

    [MaxLength(100)]
    public string Line1 { get; set; }
    [MaxLength(100)]
    public string Line2 { get; set; }
    [MaxLength(70)]
    public string City { get; set; }
    [MaxLength(65)]
    public string State { get; set; }
    [MaxLength(65)]
    public string Country { get; set; }
    [MaxLength(10)]
    public uint PostalCode { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

  }
}
