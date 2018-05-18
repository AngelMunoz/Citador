using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Citador.Models
{
  public class Permission
  {
    public int Id { get; set; }
    [MaxLength(30)]
    public string Role { get; set; }
    [MaxLength(30)]
    public string Area { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
  }
}
