/*
Author: Alberto Angelo Arellano Gaona
Date: 
Description:
Keeps track of the current state of the program and handles input and output and calls all other classes

Attributes:
List of Tools in the inventory
List of users in the system

Behaviors:
Calls all other functions to add or remove tools, save and load, and add/remove users
*/

using System;

class Program
{
  static void Main(string[] args)
  {
    // Main list menu options
    const String AAAGSeeInventoryLbl = "See Inventory";
    const String AAAGLoadInventoryLbl = "Load Inventory";
    const String AAAGSaveInventoryLbl = "Save Inventory";
    const String AAAGSeeUsersLbl = "See Users";
    const String AAAGQuitLbl = "Quit";

    AAAGMenu aaagMenu = new AAAGMenu("Select typing the option number and then press Enter.", new List<String>() { AAAGSeeInventoryLbl, AAAGLoadInventoryLbl, AAAGSaveInventoryLbl, AAAGSeeUsersLbl, AAAGQuitLbl });
    AAAGMenu aaagInventorySubmenu = new AAAGMenu("Select typing the option number and then press Enter.", new List<String>() { "Withdraw Tool", "Return Tool", "Quit" });
    AAAGMenu aaagUsersSubmenu = new AAAGMenu("Select typing the option number and then press Enter.", new List<String>() { "Add User", "Remove User", "Quit" });

    bool aaagContinueProgramLoop = true;
    while (aaagContinueProgramLoop)
    {
      Console.Clear();
      Console.WriteLine("Inventory System!\n");
      AAAGPrint(aaagMenu.AAAGToString());
      AAAGPrint("\n");
      String aaagUserMenuChoice = AAAGRead();

      // This is because menu options are constansts and the user enters the number of the option. This transforms the number input into the option text
      String aaagUserMenuChoiceString;
      int aaagUserChoiceAsInt;

      bool aaagParseSuccessful = int.TryParse(aaagUserMenuChoice, out aaagUserChoiceAsInt);

      if (aaagParseSuccessful)
      {
        aaagUserMenuChoiceString = aaagMenu.AAAGGetOptionStringFromNumber(aaagUserChoiceAsInt);
      }
      else
      {
        aaagUserMenuChoiceString = "";
      }
      //-----------------------------------------------------------------

      switch (aaagUserMenuChoiceString)
      {
        case AAAGSeeInventoryLbl:
          AAAGPrint("See inventory");
          AAAGRead();
          break;
        case AAAGQuitLbl:
          AAAGPrint("Thank you for using this program.");
          aaagContinueProgramLoop = false;
          break;
        default:
          AAAGPrint("\nInvalid option. Try Again.\n Press enter to continue...");
          AAAGRead();
          break;
      }
    }
  }

  static void AAAGPrint(String message)
  {
    Console.Write(message);
  }

  static String AAAGRead()
  {
    return Console.ReadLine();
  }
}