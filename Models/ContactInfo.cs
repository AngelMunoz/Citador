using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Citador.Models
{
  public class ContactInfo
  {
    public uint Id { get; set; }

    [MaxLength(120)]
    [EmailAddress]
    public string Email2 { get; set; }

    [MaxLength(40)]
    [Phone(ErrorMessage = "This is not a valid phone, please input a valid phone")]
    public string Phone { get; set; }

    [MaxLength(40)]
    [Phone(ErrorMessage = "This is not a valid phone, please input a valid phone")]
    public string Phone2 { get; set; }


    public int UserId { get; set; }
    public User User { get; set; }
  }
}
