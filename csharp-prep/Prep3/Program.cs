/*
Author: Alberto Angelo Arellano Gaona
Date: 1/08/2022
Description:
In the Guess My Number game the computer picks a magic number, and then the user tries to guess it. After each guess, the computer tells the user to guess "higher" or "lower" until they guess the magic number.
*/
using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("\nIn the Guess My Number game the computer picks a magic number, and then the user tries to guess it. After each guess, the computer tells the user to guess 'higher' or 'lower' until they guess the magic number.\n");

    bool aaag_keep_playing = true;

    do
    {
      Console.WriteLine("The magic number is a whole number between 1 and 100, try guessing it!");
      Random aaag_rand = new Random();
      int aaag_magic_number = aaag_rand.Next(1, 100);
      bool aaag_is_user_right = false;
      List<int> aaag_user_guesses = new List<int>();

      while (!aaag_is_user_right)
      {
        Console.Write("\nWhat is your guess? ");
        int aaag_user_guess = int.Parse(Console.ReadLine());
        aaag_user_guesses.Add(aaag_user_guess);
        if (aaag_user_guess == aaag_magic_number)
        {
          aaag_is_user_right = true;
        }
        else if (aaag_user_guess > aaag_magic_number)
        {
          Console.WriteLine("Too high!");
        }
        else if (aaag_user_guess < aaag_magic_number)
        {
          Console.WriteLine("Too low!");
        }
      }

      Console.WriteLine($"Congratulations! You guessed it in {aaag_user_guesses.Count()} attempts");
      Console.Write("\nDo you want to play again? y/n: ");
      string aaag_user_decision = Console.ReadLine();

      if (aaag_user_decision != "y")
      {
        aaag_keep_playing = false;
      }


    } while (aaag_keep_playing);
    Console.WriteLine("\nThanks for playing this game.");
  }
}