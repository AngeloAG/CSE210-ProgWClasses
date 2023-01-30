/*
Author: Angelo Arellano Gaona
Date: 1/30/2023
Description:
Class representing a fraction number.
As you recall from your Math classes, a fraction has a top number (numerator) and a bottom number (denominator). The fraction can be expressed as two integers with a slash between them, such as 3/4 or as a decimal, such as 0.75
*/

public class AAAGFraction
{
  private int _aaagTop;
  private int _aaagBottom;

  public AAAGFraction()
  {

  }

  public AAAGFraction(int aaagWholeNumber)
  {
    _aaagTop = aaagWholeNumber;
    _aaagBottom = 1;
  }

  public AAAGFraction(int aaagTop, int aaagBottom)
  {
    _aaagTop = aaagTop;
    _aaagBottom = aaagBottom;
  }

  public int AAAGGetTop()
  {
    return _aaagTop;
  }

  public void AAAGSetTop(int aaagTop)
  {
    _aaagTop = aaagTop;
  }

  public int AAAGGetBottom()
  {
    return _aaagBottom;
  }

  public void AAAGSetBottom(int aaagBottom)
  {
    _aaagBottom = aaagBottom;
  }

  public String AAAGGetFractionString()
  {
    return $"{_aaagTop}/{_aaagBottom}";
  }

  public double AAAGGetDecimalValue()
  {
    return (double)_aaagTop / _aaagBottom;
  }
}