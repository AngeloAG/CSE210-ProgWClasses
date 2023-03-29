/*
Author: Alberto Angelo Arellano Gaona
Date: 
Description:
Is going to save the list of goals and points from a file.

Attributes:
SaveFiles
LoadFiles

Behaviors:
Saves and returns the points and goals.
*/

public class AAAGFileManager
{

  private String _aaagInventoryFileName;
  private String _aaagUsersFileName;
  public AAAGFileManager(String inventoryFileName, String usersFileName)
  {
    _aaagInventoryFileName = inventoryFileName;
    _aaagUsersFileName = usersFileName;
  }

  public void AAAGSave(List<AAAGTool> tools, List<AAAGUser> users)
  {
    using (StreamWriter aaagOutputFile = new StreamWriter(_aaagInventoryFileName))
    {
      foreach (AAAGTool tool in tools)
      {
        String line = tool.AAAGGetSaveString();
        aaagOutputFile.WriteLine(line);
      }
    }
    using (StreamWriter aaagOutputFile = new StreamWriter(_aaagUsersFileName))
    {
      foreach (AAAGUser user in users)
      {
        String line = user.AAAGGetSaveString();
        aaagOutputFile.WriteLine(line);
      }
    }
  }

  public List<AAAGTool> AAAGLoadInventory(List<AAAGUser> users)
  {
    List<AAAGTool> aaagToolList = new List<AAAGTool>();
    string[] aaagFileLines = System.IO.File.ReadAllLines(_aaagInventoryFileName);
    foreach (string line in aaagFileLines)
    {
      string[] aaagListElems = line.Split("|");
      AAAGUser aaagHolder = new AAAGUser("Warehouse", "Warehouse", ".");
      if (aaagListElems[aaagListElems.Count() - 1] == "power")
      {
        int aaagHolderIndex = users.FindIndex((AAAGUser user) => user.AAAGGetId() == aaagListElems[4]);
        aaagHolder = users[aaagHolderIndex];
        AAAGPowerTool aaagTool = new AAAGPowerTool(
          aaagListElems[1],
          (aaagListElems[3]) == "True",
          DateTime.Parse(aaagListElems[7]),
          aaagHolder,
          (aaagListElems[2]) == "True",
          DateTime.Parse(aaagListElems[5]),
          DateTime.Parse(aaagListElems[6]),
          aaagListElems[0]
        );
        aaagToolList.Add(aaagTool);
      }
      else if (aaagListElems[aaagListElems.Count() - 1] == "manual")
      {
        int aaagHolderIndex = users.FindIndex((AAAGUser user) => user.AAAGGetId() == aaagListElems[4]);
        aaagHolder = users[aaagHolderIndex];
        AAAGManualTool aaagTool = new AAAGManualTool(
          aaagListElems[1],
          DateTime.Parse(aaagListElems[7]),
          aaagHolder,
          (aaagListElems[2]) == "True",
          DateTime.Parse(aaagListElems[5]),
          DateTime.Parse(aaagListElems[6]),
          aaagListElems[0]
        );
        aaagToolList.Add(aaagTool);
      }
      else if (aaagListElems[aaagListElems.Count() - 1] == "consumable")
      {
        string[] aaagHoldersIds = aaagListElems[4].Split(",");
        List<AAAGUser> aaagHolders = new List<AAAGUser>();
        for (int i = 0; i < aaagHoldersIds.Count(); i++)
        {
          int aaagUserIndex = users.FindIndex((AAAGUser user) => user.AAAGGetId() == aaagHoldersIds[i]);
          if (aaagUserIndex >= 0)
          {
            aaagHolders.Add(users[aaagUserIndex]);
          }
        }
        AAAGConsumableTool aaagTool = new AAAGConsumableTool(
          aaagListElems[1],
          int.Parse(aaagListElems[9]),
          aaagListElems[10],
          int.Parse(aaagListElems[8]),
          DateTime.Parse(aaagListElems[7]),
          aaagHolders,
          (aaagListElems[2]) == "True",
          DateTime.Parse(aaagListElems[5]),
          DateTime.Parse(aaagListElems[6]),
          aaagListElems[0]
        );
        aaagToolList.Add(aaagTool);
      }

    }
    return aaagToolList;
  }

  public List<AAAGUser> AAAGLoadUsers()
  {
    List<AAAGUser> users = new List<AAAGUser>();
    string[] aaagFileLines = System.IO.File.ReadAllLines(_aaagUsersFileName);
    foreach (string line in aaagFileLines)
    {
      string[] aaagLineElems = line.Split("|");
      users.Add(new AAAGUser(aaagLineElems[0], aaagLineElems[1], aaagLineElems[2]));
    }
    return users;
  }
}