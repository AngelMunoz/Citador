using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Citador.Models
{
  public class User
  {
    public int Id { get; set; }
    [MaxLength(80)]
    public string Name { get; set; }
    [MaxLength(80)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(120)]
    public string Password { get; set; }
    [MaxLength(60)]
    public string Username { get; set; }
  }

  public class UserDTO
  {
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
  }
}
