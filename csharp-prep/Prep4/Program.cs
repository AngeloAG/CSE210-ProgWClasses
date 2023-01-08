/*
Author: Alberto Angelo Arellano Gaona
Date: 1/08/2022
Description:
Ask the user for a series of numbers, and append each one to a list. Stop when they enter 0.

Once you have a list, have your program do the following:

Compute the sum, or total, of the numbers in the list.

Compute the average of the numbers in the list.

Find the maximum, or largest, number in the list.
*/

using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Welcome to the list exercise. Enter a series of numbers, to stop adding more numbers enter a 0.");
    bool aaag_keep_reading = true;
    List<int> aaag_user_list = new List<int>();

    do
    {
      Console.Write("\nEnter a number: ");
      int aaag_user_number = int.Parse(Console.ReadLine());
      if (aaag_user_number == 0)
      {
        aaag_keep_reading = false;
        int aaag_sum = 0;
        foreach (int aaag_number in aaag_user_list)
        {
          aaag_sum += aaag_number;
        }
        float aaag_average = ((float)aaag_sum) / aaag_user_list.Count();
        int aaag_highest = aaag_user_list.Max();

        List<int> aaag_positive_numbers = new List<int>();
        foreach (int aaag_number in aaag_user_list)
        {
          if (aaag_number > 0)
          {
            aaag_positive_numbers.Add(aaag_number);
          }
        }
        int aaag_lower_number = aaag_positive_numbers.Min();

        aaag_user_list.Sort();

        Console.WriteLine($"The sum is: {aaag_sum}");
        Console.WriteLine($"The average is: {aaag_average}");
        Console.WriteLine($"The largest number is: {aaag_highest}");
        Console.WriteLine($"The smallest positive number is: {aaag_lower_number}");
        Console.WriteLine($"The sorted list is: ");
        foreach (int aaag_number in aaag_user_list)
        {
          Console.WriteLine(aaag_number);
        }
      }
      else
      {
        aaag_user_list.Add(aaag_user_number);
      }
    } while (aaag_keep_reading);
  }
}