/*
Responsibilities:
Keeps track of the person's name and a list of their jobs.
Behaviors:
Displays the resume, which shows the name first, followed by displaying each one of the jobs.
*/

public class AAAGResume
{

  public string _aaagName;
  public List<AAAGJob> _aaagJobs = new List<AAAGJob>();

  public AAAGResume()
  {

  }

  public void Display()
  {
    Console.WriteLine($"Resume from {_aaagName}");
    Console.WriteLine("Jobs: ");
    foreach (AAAGJob job in _aaagJobs)
    {
      job.Display();
    }
  }
}