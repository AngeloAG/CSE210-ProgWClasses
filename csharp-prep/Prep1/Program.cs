using System;
/*
Author: Alberto Angelo Arellano Gaona
Date: 1/05/2022
Description:
An iconic line from the James Bond movies is that he would introduce himself as "Bond, James Bond." For this assignment you will write a program that asks for your name and repeats it back in this way.
*/

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Welcome agent.");
    Console.Write("What is your first name? ");
    string aaagFirstName = Console.ReadLine();
    Console.WriteLine();
    Console.Write("What is your last name? ");
    string aaagLastName = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine($"Your name is {aaagLastName}, {aaagFirstName} {aaagLastName}.");


  }
}