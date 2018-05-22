using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Citador.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Citador.Pages
{
  public class SignupModel : PageModel
  {
    private readonly Citador.Models.CitadorContext _context;

    private HttpClient client = new HttpClient();

    public SignupModel(Citador.Models.CitadorContext context)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      return Page();
    }


    [BindProperty]
    public User User { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      try
      {
        await SignUpAsync();

      }
      catch (HttpRequestException reqEx)
      {
        ViewData["Error"] = reqEx.Message;
        return Page();
      }

      return RedirectToPage("./Index");
    }

    private async Task SignUpAsync()
    {

      HttpContent content = new StringContent(JsonConvert.SerializeObject(User), Encoding.UTF8, "application/json");
      HttpResponseMessage response = await client.PostAsync(new Uri("http://" + HttpContext.Request.Host.Value + "/api/auth/signup"), content);

      if (!response.IsSuccessStatusCode)
      {
        var responseStr = await response.Content.ReadAsStringAsync();
        string msg = "";
        foreach (var str in responseStr.Split(" ").Take(3))
        {
          msg += str + " ";
        }
        msg += "\"";
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
          throw new HttpRequestException(msg);
        } else
        {
          throw new HttpRequestException("Something went wrong, please try again");
        }
      }
    }
  }
}