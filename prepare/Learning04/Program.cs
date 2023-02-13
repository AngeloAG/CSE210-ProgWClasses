/*
Author: Angelo Arellano Gaona
DEscription:
A Math assignment may need to store the student's name, the topic (for example, "Fractions"), the textbook section (for example, "7.3"), and the problems from that section (for example, "3-10, 20-21").

The Math assignment should have a constructor that requires a value for each of the items that it stores.

The Math assignment needs to provide a method to return a summary of the assignment that contains the student's name and the topic, and it also needs to provide a method to display the Math homework list including the section number and the problems (for example, "Section 7.3 Problems 8-19").
*/
using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello Learning04 World!");
    AAAGAssignment aaagAssignment = new AAAGAssignment("Angelo", "World");
    Console.WriteLine(aaagAssignment.AAAGGetSummary());
    Console.WriteLine();

    AAAGMathAssignment aaagMathAssignment = new AAAGMathAssignment("Angelo", "World", "7.3", "8-19");
    Console.WriteLine(aaagMathAssignment.AAAGGetHomeworkList());
    Console.WriteLine(aaagMathAssignment.AAAGGetSummary());
    Console.WriteLine();

    AAAGWritingAssignment aaagWritingAssignment = new AAAGWritingAssignment("Angelo", "World", "The Causes of World War II");
    Console.WriteLine(aaagWritingAssignment.AAAGGetWritingInformation());
    Console.WriteLine(aaagWritingAssignment.AAAGGetSummary());
    Console.WriteLine();
  }
}