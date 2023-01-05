using System;
/*
Author: Alberto Angelo Arellano Gaona
Date: 1/05/2022
Write a program that determines the letter grade for a course according to the following scale:

A >= 90
B >= 80
C >= 70
D >= 60
F < 60
*/

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello to the Grade Letter Calculator");
    Console.Write("Please enter your grade percentaje (just numbers, whole numbers): ");
    int aaagGrade = int.Parse(Console.ReadLine());
    string aaagMessage = "Congratulations!";
    string aaagLetterGrade;
    string aaagSign = "";

    if (!(aaagGrade >= 97) && !(aaagGrade < 60))
    {
      int aaagGradeSecondDigit = aaagGrade % 10;
      if (!(aaagGradeSecondDigit == 0))
      {
        if (aaagGradeSecondDigit >= 7)
        {
          aaagSign = "+";
        }
        else if (aaagGradeSecondDigit < 3)
        {
          aaagSign = "-";
        }
      }
    }

    if (aaagGrade >= 90)
    {
      aaagLetterGrade = "A";
    }
    else if (aaagGrade >= 80)
    {
      aaagLetterGrade = "B";
    }
    else if (aaagGrade >= 70)
    {
      aaagLetterGrade = "C";
    }
    else if (aaagGrade >= 60)
    {
      aaagLetterGrade = "D";
    }
    else
    {
      aaagLetterGrade = "F";
      aaagMessage = "Sorry for that, keep trying!";
    }

    Console.WriteLine($"Your letter grade is {aaagLetterGrade}{aaagSign}");
    Console.WriteLine(aaagMessage);
  }
}