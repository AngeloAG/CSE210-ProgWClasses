/*
Responsibilities:
Keeps track of the company, job title, start year, and end year.
Behaviors:
Displays the job information in the format "Job Title (Company) StartYear-EndYear", for example: "Software Engineer (Microsoft) 2019-2022".
*/
public class AAAGJob
{

  public string _aaagCompany;
  public string _aaagJobTitle;
  public int _aaagStartYear;
  public int _aaagEndYear;

  public AAAGJob()
  {

  }

  public void Display()
  {
    Console.WriteLine($"{_aaagJobTitle} {_aaagCompany} {_aaagStartYear}-{_aaagEndYear}");
  }
}