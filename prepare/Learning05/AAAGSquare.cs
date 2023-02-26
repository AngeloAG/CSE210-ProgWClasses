/*
Author: Angelo Arellano Gaona
Date: 2/26/2023
Description:
Attributes:
side: Keeps track of the size of the side of the square

getarea: method used to get the area of the shape
*/

public class AAAGSquare : AAAGShape
{
  protected double _aaagSide;

  public AAAGSquare(String aaagColor, double aaagSide) : base(aaagColor)
  {
    _aaagSide = aaagSide;
  }


  public override double AaagGetArea()
  {
    return _aaagSide * _aaagSide;
  }
}