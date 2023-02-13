/*
Author: Angelo Arellano Gaona
Description:
Child class for assignments
Attributes:
Textbook section
problems

behaviors:
gethomeworklist
*/

public class AAAGMathAssignment : AAAGAssignment
{
  private String _aaagTextbookSection;
  private String _aaagProblems;

  public AAAGMathAssignment(String aaagStudentName, String aaagTopic, String aaagTextbookSection, String aaagProblems) : base(aaagStudentName, aaagTopic)
  {
    _aaagTextbookSection = aaagTextbookSection;
    _aaagProblems = aaagProblems;
  }

  public String AAAGGetHomeworkList()
  {
    return $"{base.AAAGGetSummary()} \nSection {_aaagTextbookSection} Problems {_aaagProblems}";
  }
}