/*
Author: Angelo Arellano Gaona
Date: 2/26/2023
Description:
Attributes:
radius: Keeps track of the size of the radius of the circle

getarea: method used to get the area of the shape
*/

public class AAAGCircle : AAAGShape
{
  protected double _aaagRadius;

  public AAAGCircle(String aaagColor, double aaagRadius) : base(aaagColor)
  {
    _aaagRadius = aaagRadius;
  }


  public override double AaagGetArea()
  {
    return Math.PI * Math.Sqrt(_aaagRadius);
  }
}