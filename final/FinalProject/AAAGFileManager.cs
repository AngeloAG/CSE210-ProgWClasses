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

  public void AAAGSave()
  {

  }

  public List<AAAGTool> AAAGLoadInventory()
  {
    return new List<AAAGTool>();
  }

  public List<AAAGUser> AAAGLoadUsers()
  {
    return new List<AAAGUser>();
  }
}