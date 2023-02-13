/*
Author: Angelo Arellano Gaona
Description:
Class for the writing asssingment inherints from assignment
Attrbutes
aaagTitle
behaviors
getwritinginformation

*/

public class AAAGWritingAssignment : AAAGAssignment
{
  private String _aaagTitle;

  public AAAGWritingAssignment(String aaagStudentName, String aaagTopic, String aaagTitle) : base(aaagStudentName, aaagTopic)
  {
    _aaagTitle = aaagTitle;
  }

  public String AAAGGetWritingInformation()
  {
    return $"{base.AAAGGetSummary()} \n{_aaagTitle} by {base._aaagStudentName}";
  }
}