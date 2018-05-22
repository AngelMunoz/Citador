using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Citador.Models;
using Citador.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Citador.Controllers
{
  [Produces("application/json")]
  [Route("api/Auth")]
  public class AuthController : Controller
  {

    private readonly CitadorContext _context;

    public AuthController(CitadorContext context)
    {
      _context = context;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] User user)
    {

      user.Password = HashPassword(user.Password);
      _context.Add(user);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException updateEx)
      {
        if(updateEx.InnerException.Message.ToLower().Contains("duplicate"))
        {
          return BadRequest(updateEx.InnerException.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      UserDTO usr = new UserDTO();
      Copier.CopyPropertiesTo(user, usr);
      return CreatedAtAction("SignUp", usr);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login payload)
    {
      if (_context.Users.Count() <= 0)
      {
        return NotFound();
      }
      User user = await _context.Users.Where(u => u.Email == payload.Email).FirstAsync();
      if (user is null)
      {
        return NotFound();
      }

      if (!PasswordsMatch(user.Password, payload.Password))
      {
        return BadRequest();
      }

      user.Password = null;

      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MuchSecretWowSuchSecretWow"));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
      var header = new JwtHeader(credentials);

      //Some PayLoad that contain information about the  customer
      var jwtPayload = new JwtPayload { { "user", user } };
      var secToken = new JwtSecurityToken(header, jwtPayload);
      var handler = new JwtSecurityTokenHandler();

      // Token to String so you can use it in your client
      var tokenString = handler.WriteToken(secToken);
      return Json(new Dictionary<string, object>() { { "user", user }, { "token", tokenString } });
    }

    // Private methods

    private static bool PasswordsMatch(string fromUser, string fromRequest)
    {
      /* Fetch the stored value */
      string savedPasswordHash = fromUser;
      /* Extract the bytes */
      byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
      /* Get the salt */
      byte[] salt = new byte[16];
      Array.Copy(hashBytes, 0, salt, 0, 16);
      /* Compute the hash on the password the user entered */
      var pbkdf2 = new Rfc2898DeriveBytes(fromRequest, salt, 10000);
      byte[] hash = pbkdf2.GetBytes(20);
      /* Compare the results */
      for (int i = 0; i < 20; i++)
      {
        if (hashBytes[i + 16] != hash[i])
        {
          return false;
        }
      }
      return true;
    }
    public static string HashPassword(string password)
    {
      byte[] salt;
      new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
      var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
      byte[] hash = pbkdf2.GetBytes(20);
      byte[] hashBytes = new byte[36];
      Array.Copy(salt, 0, hashBytes, 0, 16);
      Array.Copy(hash, 0, hashBytes, 16, 20);
      return Convert.ToBase64String(hashBytes);
    }
  }
}