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
  protected String _menuTitle;

  public AAAGMenu(String menuTitle, List<String> options)
  {
    _menuTitle = menuTitle;
    _aaagOptions = options;
  }

  public String AAAGToString()
  {
    String aaagMenuText = _menuTitle + "\n";
    int aaagOptionNumber = 1;
    foreach (String option in _aaagOptions)
    {
      aaagMenuText += aaagOptionNumber + ". " + option + "\n";
      aaagOptionNumber++;
    }
    return aaagMenuText;
  }

  public String AAAGGetOptionStringFromNumber(int optionNumber)
  {
    String aaagOption;
    try
    {
      aaagOption = _aaagOptions[optionNumber - 1];
    }
    catch (ArgumentOutOfRangeException)
    {
      aaagOption = "";
    }
    return aaagOption;
  }
}