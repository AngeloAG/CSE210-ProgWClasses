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
using ConsoleTables;

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
    const String AAAGCancelLbl = "Cancel";

    const String AAAGMenuLbl = "Select typing the option number and then press Enter.";
    const String AAAGAddToolMenuLbl = "Select the type of tool you want to create by typing the option number and then press Enter.";

    //Inventory submenu options
    const String AAAGWithdrawToolLbl = "Withdraw Tool";
    const String AAAGReturnToolLbl = "Return Tool";
    const String AAAGAddToolLbl = "Add Tool";
    const String AAAGRemoveToolLbl = "Remove Tool";

    //Add Tool menu options
    const String AAAGPowerToolLbl = "Power Tool";
    const String AAAGManualToolLbl = "Manual Tool";
    const String AAAGConsumableToolLbl = "Consumable Tool";

    //Users submenu options
    const String AAAGAddUserLbl = "Add User";
    const String AAAGRemoveUserLbl = "Remove User";

    //Save files names
    const String AAAGInventorySaveFileName = "InventorySave.txt";
    const String AAAGUsersSaveFileName = "UsersSave.txt";

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
        AAAGAddToolLbl,
        AAAGRemoveToolLbl,
        AAAGCancelLbl
      });
    AAAGMenu aaagAddToolMenu = new AAAGMenu(
      AAAGAddToolMenuLbl,
      new List<String>(){
        AAAGPowerToolLbl,
        AAAGManualToolLbl,
        AAAGConsumableToolLbl,
        AAAGCancelLbl
      }
    );
    AAAGMenu aaagUsersSubmenu = new AAAGMenu(
      AAAGMenuLbl,
      new List<String>() {
        AAAGAddUserLbl,
        AAAGRemoveUserLbl,
        AAAGCancelLbl
      });

    List<AAAGTool> aaagTools = new List<AAAGTool>();
    AAAGFileManager aaagFileManager = new AAAGFileManager(AAAGInventorySaveFileName, AAAGUsersSaveFileName);
    List<AAAGUser> aaagUsers = new List<AAAGUser>();
    aaagUsers.Add(new AAAGUser("Warehouse", "Warehouse", "."));

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
          bool aaagKeepInventorySubMenu = true;
          while (aaagKeepInventorySubMenu)
          {
            Console.Clear();
            AAAGPrint("Inventory\n");
            ConsoleTable aaagInventoryTable = new ConsoleTable("Id", "Name", "In Stock", "Battery", "Holder", "Withdrawn", "Units");
            foreach (AAAGTool aaagTool in aaagTools)
            {
              aaagInventoryTable.AddRow(aaagTool.AAAGToString().Split("|"));
            }
            aaagInventoryTable.Write(Format.Alternative);

            AAAGPrint($"\n\n{aaagInventorySubmenu.AAAGToString()}\n");
            String aaagInventorySubmenuChoice = AAAGRead();
            String aaagInventorySubmenuChoiceString = AAAGGetChoiceFromMenu(aaagInventorySubmenuChoice, aaagInventorySubmenu);

            switch (aaagInventorySubmenuChoiceString)
            {
              case AAAGWithdrawToolLbl:
                bool aaagKeepAskingWithdraw = true;
                while (aaagKeepAskingWithdraw)
                {
                  AAAGPrint("\nWithdrawing tool.");
                  String aaagToolId = AAAGInput("\nEnter the id of the tool to withdraw: ");
                  int aaagToolIndex = aaagTools.FindIndex((AAAGTool tool) => tool.AAAGGetId() == aaagToolId);

                  if (aaagToolIndex >= 0)
                  {
                    aaagKeepAskingWithdraw = false;
                    if (aaagTools[aaagToolIndex].AAAGGetIfInStock())
                    {
                      bool aaagKeepAskingWithdrawUser = true;
                      Console.Clear();
                      while (aaagKeepAskingWithdrawUser)
                      {
                        AAAGPrint($"\nWithdrawing {aaagTools[aaagToolIndex].AAAGGetToolDescription()}");
                        string aaagWithdrawUserId = AAAGInput("\nEnter the id of the user that will withdraw the tool (Enter u to show users): ");
                        if (aaagWithdrawUserId == "u")
                        {
                          ConsoleTable aaagUsersTable = new ConsoleTable("Id", "Name");
                          foreach (AAAGUser user in aaagUsers)
                          {
                            string[] userRow = { user.AAAGGetId(), user.AAAGToString() };
                            aaagUsersTable.AddRow(userRow);
                          }
                          aaagUsersTable.Write(Format.Alternative);
                          AAAGPrint("\n Press enter to continue...");
                          AAAGRead();
                        }
                        else
                        {
                          int aaagUserIndex = aaagUsers.FindIndex((AAAGUser user) => user.AAAGGetId() == aaagWithdrawUserId);

                          if (aaagUserIndex >= 0)
                          {
                            aaagKeepAskingWithdrawUser = false;
                            if (aaagTools[aaagToolIndex] is AAAGConsumableTool)
                            {
                              bool aaagkeepAskingAmount = true;
                              while (aaagkeepAskingAmount)
                              {
                                int aaagAmountToTake = AAAGReadInt("\nHow many are being withdrawn? (whole number): ");
                                if (aaagTools[aaagToolIndex].AAAGAreEnoughToWithdraw(aaagAmountToTake))
                                {
                                  aaagkeepAskingAmount = false;
                                  aaagTools[aaagToolIndex].AAAGWithdraw(aaagUsers[aaagUserIndex], aaagAmountToTake);
                                }
                                else
                                {
                                  string aaagResponse = AAAGInput("\nNot enough units. Try Again.\n Press enter to continue...");
                                }
                              }
                            }
                            else
                            {
                              aaagTools[aaagToolIndex].AAAGWithdraw(aaagUsers[aaagUserIndex]);
                            }
                            AAAGPrint("\nTool Withdrawn!.\n Press enter to continue...");
                            AAAGRead();
                          }
                          else
                          {
                            string aaagResponse = AAAGInput("\nUser not found. Try Again.\n Press enter to continue or c to cancel");
                            if (aaagResponse == "c")
                            {
                              aaagKeepAskingWithdrawUser = false;
                            }
                          }
                        }
                      }
                    }
                    else
                    {
                      AAAGPrint("\nThe tool is out of stock. It cannot be withdrawn at this moment.\n Press enter to continue...");
                      AAAGRead();
                    }
                  }
                  else
                  {
                    AAAGPrint("\nTool not found. Try again.\n Press enter to continue...");
                    AAAGRead();
                  }
                }
                Console.Clear();
                break;
              case AAAGReturnToolLbl:
                bool aaagKeepAskingReturn = true;
                while (aaagKeepAskingReturn)
                {
                  AAAGPrint("\nReturning tool.");
                  String aaagToolId = AAAGInput("\nEnter the id of the tool to return: ");
                  int aaagToolIndex = aaagTools.FindIndex((AAAGTool tool) => tool.AAAGGetId() == aaagToolId);

                  if (aaagToolIndex >= 0)
                  {
                    bool aaagCanbeReturned = aaagTools[aaagToolIndex].AAAGCanBeReturned();

                    if (aaagCanbeReturned)
                    {
                      aaagKeepAskingReturn = false;
                      bool aaagKeepAskingReturnUser = true;
                      Console.Clear();
                      while (aaagKeepAskingReturnUser)
                      {
                        AAAGPrint($"\nReturning {aaagTools[aaagToolIndex].AAAGGetToolDescription()}");
                        string aaagReturnUserId = AAAGInput("\nEnter the id of the user that will return the tool (Enter u to show users): ");
                        if (aaagReturnUserId == "u")
                        {
                          ConsoleTable aaagUsersTable = new ConsoleTable("Id", "Name");
                          foreach (AAAGUser user in aaagUsers)
                          {
                            string[] userRow = { user.AAAGGetId(), user.AAAGToString() };
                            aaagUsersTable.AddRow(userRow);
                          }
                          aaagUsersTable.Write(Format.Alternative);
                          AAAGPrint("\n Press enter to continue...");
                          AAAGRead();
                        }
                        else
                        {
                          int aaagUserIndex = aaagUsers.FindIndex((AAAGUser user) => user.AAAGGetId() == aaagReturnUserId);

                          if (aaagUserIndex >= 0)
                          {
                            bool aaagIsUserAHolder = aaagTools[aaagToolIndex].AAAGIsUserAHolder(aaagUsers[aaagUserIndex]);

                            if (aaagIsUserAHolder)
                            {
                              aaagKeepAskingReturnUser = false;
                              if (aaagTools[aaagToolIndex] is AAAGConsumableTool)
                              {
                                bool aaagkeepAskingAmount = true;
                                while (aaagkeepAskingAmount)
                                {
                                  int aaagAmountToReturn = AAAGReadInt("\nHow many are being returned? (whole number): ");
                                  if (aaagTools[aaagToolIndex].AAAGCanReturnAmount(aaagAmountToReturn))
                                  {
                                    aaagkeepAskingAmount = false;
                                    aaagTools[aaagToolIndex].AAAGReturnTool(aaagUsers[aaagUserIndex], aaagAmountToReturn);
                                  }
                                  else
                                  {
                                    string aaagResponse = AAAGInput("\nTo many units. Try Again.\n Press enter to continue...");
                                  }
                                }
                              }
                              else
                              {
                                aaagTools[aaagToolIndex].AAAGReturnTool(aaagUsers[aaagUserIndex]);
                              }
                              AAAGPrint("\nTool Returned!.\n Press enter to continue...");
                              AAAGRead();
                            }
                            else
                            {
                              string aaagResponse = AAAGInput("\nUser is not a holder. Try Again.\n Press enter to continue or c to cancel");
                              if (aaagResponse == "c")
                              {
                                aaagKeepAskingReturnUser = false;
                              }
                            }
                          }
                          else
                          {
                            string aaagResponse = AAAGInput("\nUser not found. Try Again.\n Press enter to continue or c to cancel");
                            if (aaagResponse == "c")
                            {
                              aaagKeepAskingReturnUser = false;
                            }
                          }
                        }
                      }
                    }
                    else
                    {
                      string aaagResponse = AAAGInput("\nTool cannot be returned.\n Press enter to try again or c to cancel. ");
                      if (aaagResponse == "c")
                      {
                        aaagKeepAskingReturn = false;
                      }
                    }
                  }
                  else
                  {
                    AAAGPrint("\nTool not found. Try again.\n Press enter to continue...");
                    AAAGRead();
                  }
                }
                Console.Clear();
                break;
              case AAAGAddToolLbl:
                bool aaagKeepAddToolMenu = true;
                while (aaagKeepAddToolMenu)
                {
                  AAAGPrint($"\n{aaagAddToolMenu.AAAGToString()}\n");
                  String aaagAddToolChoice = AAAGRead();
                  String aaagAddToolChoiceString = AAAGGetChoiceFromMenu(aaagAddToolChoice, aaagAddToolMenu);
                  String aaagToolName;
                  switch (aaagAddToolChoiceString)
                  {
                    case AAAGPowerToolLbl:
                      Console.Clear();
                      AAAGPrint("Creating Power Tool");
                      aaagToolName = AAAGInput("\nWhat's the name of the Tool: ");
                      String aaagUsesBatteryStr = AAAGInput("\nDoes it use battery? (y/n): ");
                      bool aaagUsesBattery = (aaagUsesBatteryStr.ToLower() == "y") ? true : false;
                      AAAGPowerTool aaagNewPowerTool = new AAAGPowerTool(aaagToolName, aaagUsesBattery);
                      aaagTools.Add(aaagNewPowerTool);
                      AAAGPrint("\nNew Tool Added!\n Press enter to continue...");
                      AAAGRead();
                      Console.Clear();
                      aaagKeepAddToolMenu = false;
                      break;
                    case AAAGManualToolLbl:
                      Console.Clear();
                      AAAGPrint("Creating Manual Tool");
                      aaagToolName = AAAGInput("What's the name of the Tool: ");
                      AAAGManualTool aaagNewManualTool = new AAAGManualTool(aaagToolName);
                      aaagTools.Add(aaagNewManualTool);
                      AAAGPrint("\nNew Tool Added!\n Press enter to continue...");
                      AAAGRead();
                      Console.Clear();
                      aaagKeepAddToolMenu = false;
                      break;
                    case AAAGConsumableToolLbl:
                      Console.Clear();
                      AAAGPrint("Creating Consumable Tool\n");
                      aaagToolName = AAAGInput("What's the name of the Tool: ");
                      String aaagToolUnit = AAAGInput("\nWhat's the unit of the tool?: ");
                      int aaagAmountOfUnits = 0;
                      aaagAmountOfUnits = AAAGReadInt($"\nHow many {aaagToolUnit}(s) are being stored? (Whole number): ");
                      AAAGConsumableTool aaagNewConsumableTool = new AAAGConsumableTool(aaagToolName, aaagAmountOfUnits, aaagToolUnit);
                      aaagTools.Add(aaagNewConsumableTool);
                      AAAGPrint("\nNew Tool Added!\n Press enter to continue...");
                      AAAGRead();
                      Console.Clear();
                      aaagKeepAddToolMenu = false;
                      break;
                    case AAAGCancelLbl:
                      aaagKeepAddToolMenu = false;
                      Console.Clear();
                      break;
                    default:
                      AAAGPrint("\nInvalid option. Try Again.\n Press enter to continue...");
                      AAAGRead();
                      break;
                  }
                }
                break;
              case AAAGRemoveToolLbl:
                bool aaagKeepTryingToDeleteTool = true;
                while (aaagKeepTryingToDeleteTool)
                {
                  String aaagIdToDelete = AAAGInput("\nEnter the Id of the tool to delete or c to cancel: ");
                  if (aaagIdToDelete == "c")
                  {
                    aaagKeepTryingToDeleteTool = false;
                  }
                  else
                  {
                    int aaagToolToDeleteIdx = aaagTools.FindIndex((AAAGTool tool) => tool.AAAGGetId() == aaagIdToDelete);
                    if (aaagToolToDeleteIdx >= 0)
                    {
                      aaagTools.RemoveAt(aaagToolToDeleteIdx);
                      aaagKeepTryingToDeleteTool = false;
                      AAAGPrint("\nTool deleted.\n Press enter to continue...");
                      AAAGRead();
                    }
                    else
                    {
                      AAAGPrint("\nTool not found. Try Again.\n Press enter to continue...");
                      AAAGRead();
                    }
                  }
                }
                break;
              case AAAGCancelLbl:
                aaagKeepInventorySubMenu = false;
                Console.Clear();
                break;
              default:
                AAAGPrint("\nInvalid option. Try Again.\n Press enter to continue...");
                AAAGRead();
                break;
            }
          }
          break;
        case AAAGLoadInventoryLbl:
          AAAGPrint("Loading inventory...");
          aaagUsers = aaagFileManager.AAAGLoadUsers();
          aaagTools = aaagFileManager.AAAGLoadInventory(aaagUsers);
          AAAGPrint("\nInventory Loaded.\n Press enter to continue...");
          AAAGRead();
          break;
        case AAAGSaveInventoryLbl:
          AAAGPrint("Saving inventory...");
          aaagFileManager.AAAGSave(aaagTools, aaagUsers);
          AAAGPrint("\nInventory Saved.\n Press enter to continue...");
          AAAGRead();
          break;
        case AAAGSeeUsersLbl:
          bool aaagKeepUsersSubmenu = true;
          while (aaagKeepUsersSubmenu)
          {
            Console.Clear();
            AAAGPrint("Users\n");
            ConsoleTable aaagUsersTable = new ConsoleTable("Id", "Name");
            foreach (AAAGUser user in aaagUsers)
            {
              string[] userRow = { user.AAAGGetId(), user.AAAGToString() };
              aaagUsersTable.AddRow(userRow);
            }
            aaagUsersTable.Write(Format.Alternative);
            AAAGPrint($"\n\n{aaagUsersSubmenu.AAAGToString()}\n");
            String aaagUsersSubmenuChoice = AAAGRead();
            String aaagUsersSubmenuChoiceString = AAAGGetChoiceFromMenu(aaagUsersSubmenuChoice, aaagUsersSubmenu);
            switch (aaagUsersSubmenuChoiceString)
            {
              case AAAGAddUserLbl:
                Console.Clear();
                AAAGPrint("Adding new user\n");
                String aaagUserFName = AAAGInput("\nWhat's the user first name: ");
                String aaagUserLName = AAAGInput("\nWhat's the user last name: ");
                AAAGPrint("\nCreating user...");
                AAAGUser aaagNewUser = new AAAGUser(aaagUserFName, aaagUserLName);
                aaagUsers.Add(aaagNewUser);
                AAAGPrint("\nUser created successfully.\n Press enter to continue...");
                AAAGRead();
                break;
              case AAAGRemoveUserLbl:
                bool aaagKeepTryingToDeleteUser = true;
                while (aaagKeepTryingToDeleteUser)
                {
                  String aaagIdToDelete = AAAGInput("\nEnter the Id of the user to delete or c to cancel: ");
                  if (aaagIdToDelete == "c")
                  {
                    aaagKeepTryingToDeleteUser = false;
                  }
                  else
                  {
                    int aaagUserToDeleteIdx = aaagUsers.FindIndex((AAAGUser user) => user.AAAGGetId() == aaagIdToDelete);
                    if (aaagUserToDeleteIdx >= 0)
                    {
                      aaagUsers.RemoveAt(aaagUserToDeleteIdx);
                      aaagKeepTryingToDeleteUser = false;
                      AAAGPrint("\nUser deleted.\n Press enter to continue...");
                      AAAGRead();
                    }
                    else
                    {
                      AAAGPrint("\nUser not found. Try Again.\n Press enter to continue...");
                      AAAGRead();
                    }
                  }
                }
                break;
              case AAAGCancelLbl:
                aaagKeepUsersSubmenu = false;
                Console.Clear();
                break;
              default:
                AAAGPrint("\nInvalid option. Try Again.\n Press enter to continue...");
                AAAGRead();
                break;
            }
          }
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

  /// <summary>
  /// This function displays a prompt to the console
  /// </summary>
  /// <param name="prompt">The string to by shown on console</param>
  /// <returns>Nothing</returns>
  static void AAAGPrint(String message)
  {
    Console.Write(message);
  }

  /// <summary>
  /// This function reads a response from the keyboard
  /// </summary>
  /// <returns>The input of the keyboard as string</returns>
  static String AAAGRead()
  {
    return Console.ReadLine();
  }

  /// <summary>
  /// This function displays a prompt and reads the response from the keyboard
  /// </summary>
  /// <param name="prompt">The string to by shown on console</param>
  /// <returns>The input of the keyboard as string</returns>
  static String AAAGInput(String prompt)
  {
    Console.Write(prompt);
    String aaagResponse = Console.ReadLine();
    return aaagResponse;
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

  /// <summary>
  /// This function displays a prompt and reads the response from the keyboard as an integer, and keeps trying until an integer is input
  /// </summary>
  /// <param name="prompt">The string to by shown on console</param>
  /// <returns>The input of the keyboard as int</returns>
  static int AAAGReadInt(String prompt)
  {
    int aaagResponseAsInt = 0;
    bool aaagKeepAsking = true;
    while (aaagKeepAsking)
    {
      String aaagUserResponse = AAAGInput(prompt);
      try
      {
        aaagResponseAsInt = int.Parse(aaagUserResponse);
        aaagKeepAsking = false;
      }
      catch (FormatException)
      {
        AAAGPrint("\nThe value entered is not a whole number.Try again.\nPress Enter to continue...");
        AAAGRead();
      }
      catch (OverflowException)
      {
        AAAGPrint("\nThe value entered is too small or too big.Try again.\nPress Enter to continue...");
        AAAGRead();
      }
    }
    return aaagResponseAsInt;

  }
}