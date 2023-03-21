/*
Author: Alberto Angelo Arellano Gaona
Date: 
Description:
This is the blueprint for a tool, Contains the attributes and behaviors all tools have in common and defines the methods that should be implmenented by all tools

Attributes:
Name of the tool
Date it was created
Who has it right now
If it is in stock
When it was taken out

Behaviors:
ToString
Withdraw
ReturnTool
GetIsInStock
*/

public abstract class AAAGTool
{
  protected String _aaagName;
  protected DateTime _aaagCreatedDate;
  protected AAAGUser _aaagHolder;
  protected bool _aaagInStock;
  protected DateTime _aaagDateOfLastWithdrawal;
  protected DateTime _aaagDateOfLastReturn;
  public AAAGTool(String name)
  {
    _aaagName = name;
    _aaagCreatedDate = DateTime.Now;
    _aaagInStock = true;
  }

  public abstract String AAAGToString();
  public virtual void AAAGWithdraw(AAAGUser user)
  {
    if (_aaagInStock)
    {
      _aaagHolder = user;
      _aaagInStock = false;
      _aaagDateOfLastWithdrawal = DateTime.Now;
    }
  }

  public virtual void AAAGReturnTool()
  {
    if (!_aaagInStock)
    {
      _aaagHolder = null;
      _aaagInStock = true;
      _aaagDateOfLastReturn = DateTime.Now;
    }
  }

  public bool AAAGGetIfInStock()
  {
    return _aaagInStock;
  }
}