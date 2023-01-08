/*
Author: Alberto Angelo Arellano Gaona
Date: 1/08/2022
Description:
For this assignment, write a C# program that has several simple functions:

DisplayWelcome - Displays the message, "Welcome to the Program!"
PromptUserName - Asks for and returns the user's name (as a string)
PromptUserNumber - Asks for and returns the user's favorite number (as an integer)
SquareNumber - Accepts an integer as a parameter and returns that number squared (as an integer)
DisplayResult - Accepts the user's name and the squared number and displays them.
Your Main function should then call each of these functions saving the return values and passing data to them as necessary.
*/

using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("This is a function called program!");
    AAAGDisplayWelcome();
    string aaag_user_name = AAAGPromptUserName();
    int aaag_user_number = AAAGPromptUserNumber();
    int aaag_sqrt_number = AAAGSquareNumber(aaag_user_number);
    AAAGDisplayResult(aaag_user_name, aaag_sqrt_number);
  }

  static void AAAGDisplayWelcome()
  {
    Console.WriteLine("Welcome to the Program!");
  }

  static string AAAGPromptUserName()
  {
    Console.Write("Please enter your name: ");
    string aaag_user_name = Console.ReadLine();
    return aaag_user_name;
  }

  static int AAAGPromptUserNumber()
  {
    Console.Write("Please enter your favorite number: ");
    int aaag_user_number = int.Parse(Console.ReadLine());
    return aaag_user_number;
  }

  static int AAAGSquareNumber(int aaag_number)
  {
    return (int)Math.Pow(aaag_number, 2);
  }

  static void AAAGDisplayResult(string aaag_name, int aaag_number)
  {
    Console.WriteLine($"{aaag_name}, the square of your number is {aaag_number}");
  }
}