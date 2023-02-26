/*
Author: Angelo Arellano Gaona
Date: 2/26/2023
Description:
Attributes:
width: Keeps track of the size of the with of the rectangle
height: keeps track of the size of the height of the rectangle

getarea: method used to get the area of the shape
*/

public class AAAGRectangle : AAAGShape
{
  protected double _aaagWidth;
  protected double _aaagHeight;

  public AAAGRectangle(String aaagColor, double aaagWidth, double aaagHeight) : base(aaagColor)
  {
    _aaagWidth = aaagWidth;
    _aaagHeight = aaagHeight;
  }


  public override double AaagGetArea()
  {
    return _aaagWidth * _aaagHeight;
  }
}