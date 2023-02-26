using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello Learning05 World!");
    List<AAAGShape> aaagShapes = new List<AAAGShape>() { new AAAGSquare("Blue", 20), new AAAGRectangle("Red", 30, 50), new AAAGCircle("Green", 40) };

    foreach (AAAGShape aaagShape in aaagShapes)
    {
      Console.WriteLine($"{aaagShape.AaagGetColor()} / {aaagShape.AaagGetArea()}");
    }
  }
}