/*
Author: Alberto Angelo Arellano Gaona
Date: 
Description:
Return selected option

Attributes:
_Options
list of options

Behaviors:
Return user selected option
*/

public class AAAGMenu
{
  protected List<String> _aaagOptions;

  public AAAGMenu(List<String> options)
  {
    _aaagOptions = options;
  }

  public String AAAGToString()
  {
    String aaagMenuText = "";
    int aaagOptionNumber = 1;
    foreach (String option in _aaagOptions)
    {
      aaagMenuText += aaagOptionNumber + ". " + option + "\n";
      aaagOptionNumber++;
    }
    return aaagMenuText;
  }
}