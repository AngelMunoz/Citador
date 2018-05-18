using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Citador.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Citador.Pages
{
  public class AboutModel : PageModel
  {
    public Resume Resume { get; set; }
    public HttpClient client = new HttpClient();

    public async Task OnGetAsync()
    {
      client.BaseAddress = new Uri(@"https://raw.githubusercontent.com");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      Resume = await GetResumeAsync();
      Console.WriteLine(Resume?.Basics?.Name);
    }

    private async Task<Resume> GetResumeAsync()
    {
      Resume resume = null;
      HttpResponseMessage response = await client.GetAsync(@"AngelMunoz/resume/master/resume.json");
      if (response.IsSuccessStatusCode)
      {
        string res = await response.Content.ReadAsStringAsync();
        resume = JsonConvert.DeserializeObject<Resume>(res);
      }
      return resume;
    }
  }
}
