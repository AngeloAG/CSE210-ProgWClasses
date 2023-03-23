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

    const String AAAGMenuLbl = "Select typing the option number and then press Enter.";

    //Inventory submenu options
    const String AAAGWithdrawToolLbl = "Withdraw Tool";
    const String AAAGReturnToolLbl = "Return Tool";

    //Users submenu options
    const String AAAGAddUserLbl = "Add User";
    const String AAAGRemoveUserLbl = "Remove User";

    AAAGMenu aaagMenu = new AAAGMenu(
      AAAGMenuLbl,
      new List<String>() {
        AAAGSeeInventoryLbl,
        AAAGLoadInventoryLbl,
        AAAGSaveInventoryLbl,
        AAAGSeeUsersLbl,
        AAAGQuitLbl
      });
    AAAGMenu aaagInventorySubmenu = new AAAGMenu(
      AAAGMenuLbl,
      new List<String>() {
        AAAGWithdrawToolLbl,
        AAAGReturnToolLbl,
        AAAGQuitLbl
      });
    AAAGMenu aaagUsersSubmenu = new AAAGMenu(
      AAAGMenuLbl,
      new List<String>() {
        AAAGAddUserLbl,
        AAAGRemoveUserLbl,
        AAAGQuitLbl
      });

    bool aaagContinueProgramLoop = true;
    while (aaagContinueProgramLoop)
    {
      Console.Clear();
      Console.WriteLine("Inventory System!\n");
      AAAGPrint(aaagMenu.AAAGToString());
      AAAGPrint("\n");
      String aaagUserMenuChoice = AAAGRead();

      String aaagUserMenuChoiceString = AAAGGetChoiceFromMenu(aaagUserMenuChoice, aaagMenu);

      switch (aaagUserMenuChoiceString)
      {
        case AAAGSeeInventoryLbl:
          AAAGPrint("See inventory");
          AAAGRead();
          break;
        case AAAGLoadInventoryLbl:
          AAAGPrint("Load inventory");
          AAAGRead();
          break;
        case AAAGSaveInventoryLbl:
          AAAGPrint("Save inventory");
          AAAGRead();
          break;
        case AAAGSeeUsersLbl:
          AAAGPrint("See users");
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

  /// <summary>
  /// This function exists because menu options are constansts and the user enters the number of the option. This transforms the number input into the option text
  /// </summary>
  /// <param name="userChoiceInput">The number as string the user typed.</param>
  /// <param name="menu">The menu object that has the options.</param>
  /// <returns>The option as text that the number entered represents.</returns>
  static String AAAGGetChoiceFromMenu(String userChoiceInput, AAAGMenu menu)
  {

    String aaagUserMenuChoiceString;
    int aaagUserChoiceAsInt;

    bool aaagParseSuccessful = int.TryParse(userChoiceInput, out aaagUserChoiceAsInt);

    if (aaagParseSuccessful)
    {
      aaagUserMenuChoiceString = menu.AAAGGetOptionStringFromNumber(aaagUserChoiceAsInt);
    }
    else
    {
      aaagUserMenuChoiceString = "";
    }
    return aaagUserMenuChoiceString;
  }
}