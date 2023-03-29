/*
Author: Alberto Angelo Arellano Gaona
Date: 
Description:
Holds information about the employees that use the inventory

Attributes:
userId
first name and last name

Behaviors:
To string and getId
*/

public class AAAGUser
{
  private String _aaagUserId;
  private String _aaagFirstName;
  private String _aaagLastName;
  public AAAGUser(String userId, String firstName, String lastName)
  {
    _aaagUserId = userId;
    _aaagFirstName = firstName;
    _aaagLastName = lastName;
  }

  public AAAGUser(String firstName, String lastName)
  {
    Guid aaagGuid = Guid.NewGuid();
    String id = aaagGuid.ToString();
    _aaagUserId = id.Split("-")[0];
    _aaagFirstName = firstName;
    _aaagLastName = lastName;
  }

  public String AAAGToString()
  {
    return $"{_aaagFirstName} {_aaagLastName}";
  }

  public String AAAGGetId()
  {
    return $"{_aaagUserId}";
  }
  public String AAAGGetSaveString()
  {
    return $"{_aaagUserId}|{_aaagFirstName}|{_aaagLastName}";
  }
}