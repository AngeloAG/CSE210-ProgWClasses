using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Welcome to the fraction program!");

    AAAGFraction aaagFraction1 = new AAAGFraction(1);
    AAAGFraction aaagFraction2 = new AAAGFraction(5);
    AAAGFraction aaagFraction3 = new AAAGFraction(3, 4);
    AAAGFraction aaagFraction4 = new AAAGFraction();
    aaagFraction4.AAAGSetTop(1);
    aaagFraction4.AAAGSetBottom(3);

    List<AAAGFraction> aaagFractions = new List<AAAGFraction>();
    aaagFractions.Add(aaagFraction1);
    aaagFractions.Add(aaagFraction2);
    aaagFractions.Add(aaagFraction3);
    aaagFractions.Add(aaagFraction4);

    foreach (AAAGFraction aaagFraction in aaagFractions)
    {
      Console.WriteLine($"{aaagFraction.AAAGGetFractionString()}");
      Console.WriteLine($"{aaagFraction.AAAGGetDecimalValue()}");
    }
  }
}