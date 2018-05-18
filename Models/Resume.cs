using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citador.Models
{
  public class Resume
  {
    public Basics Basics { get; set; }
    public Work[] Work { get; set; }
    public Education[] Education{ get; set; }
    public Volunteer[] Volunteer{ get; set; }
    public Awards[] Awards{ get; set; }
    public Publications[] Publications { get; set; }
    public Skills[] Skills { get; set; }
    public Languajes[] Languajes { get; set; }
    public Interests[] Interests { get; set; }
    public References[] References { get; set; }
  }

  public class Basics
  {
    public string Name { get; set; }
    public string Label { get; set; }
    public string Picture { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Website { get; set; }
    public string Summary { get; set; }
    public Location Location { get; set; }
    public Profiles[] Profiles { get; set; }
  }

  public class Location
  {
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string CountryCode { get; set; }
    public string Region { get; set; }
  }

  public class Profiles
  {
    public string Network { get; set; }
    public string Username { get; set; }
    public string Url { get; set; }
  }

  public class Work
  {
    public string Company { get; set; }
    public string Position { get; set; }
    public string Website { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Summary { get; set; }
    public string[] HighLights { get; set; }

  }

  public class Education
  {
    public string Institution { get; set; }
    public string Area { get; set; }
    public string StudyType { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Gpa { get; set; }
    public string[] Courses { get; set; }
  }

  public class Awards
  {
    public string Title { get; set; }
    public string Date { get; set; }
    public string Awarder { get; set; }
    public string Summary { get; set; }
  }

  public class Publications
  {
    public string Name { get; set; }
    public string Publisher { get; set; }
    public string ReleaseDate { get; set; }
    public string Website { get; set; }
    public string Summary { get; set; }
  }

  public class Skills
  {
    public string Name { get; set; }
    public string Level { get; set; }
    public string[] Keywords { get; set; }
  }

  public class Languajes
  {
    public string Name { get; set; }
    public string Level{ get; set; }
  }

  public class Interests
  {
    public string Name { get; set; }
    public string[] Keywords { get; set; }
  }

  public class References
  {
    public string Name { get; set; }
    public string Reference { get; set; }
  }

  public class Volunteer
  {
    public string Organization { get; set; }
    public string Position { get; set; }
    public string Website { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Summary { get; set; }
    public string[] HighLights { get; set; }
  }
}
