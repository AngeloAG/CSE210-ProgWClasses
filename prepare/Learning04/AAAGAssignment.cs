/*
Author: Angelo Arellano Gaona
Description:
Attributes: 
student name 
topic

behavior:
return the summary of the assignment
*/

public class AAAGAssignment
{
  protected String _aaagStudentName;
  private String _aaagTopic;

  public AAAGAssignment(String aaagStudentName, String aaagTopic)
  {
    _aaagStudentName = aaagStudentName;
    _aaagTopic = aaagTopic;
  }

  public String AAAGGetSummary()
  {
    return $"{_aaagStudentName} - {_aaagTopic}";
  }
}