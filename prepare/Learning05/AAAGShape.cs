/*
Author: Angelo Arellano Gaona
Date: 2/26/2023
Description:
Attributes:
color: keeps track of the color of the shape

getarea: Abstract method used to get the area of the shape
*/

public abstract class AAAGShape
{
  protected String _aaagColor;

  protected AAAGShape(String aaagColor)
  {
    _aaagColor = aaagColor;
  }

  public String AaagGetColor()
  {
    return _aaagColor;
  }
  public abstract double AaagGetArea();
}