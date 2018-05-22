using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Citador.Models
{
  public class Service
  {
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }

    /// <summary>
    /// Duration In hours
    /// 1.5 equals an hour and a half
    /// </summary>
    public double Duration { get; set; }
    public decimal Cost { get; set; }

  }
}
