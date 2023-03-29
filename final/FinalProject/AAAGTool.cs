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

  protected String _aaagId;
  public AAAGTool(String name)
  {
    _aaagName = name;
    _aaagCreatedDate = DateTime.Now;
    _aaagInStock = true;
    Guid aaagGuid = Guid.NewGuid();
    String id = aaagGuid.ToString();
    _aaagId = id.Split("-")[0];
  }

  public AAAGTool(String name, DateTime createdDate, AAAGUser holder, bool inStock, DateTime dateOfLastWithdrawal, DateTime dateOfLastReturn, String id)
  {
    _aaagName = name;
    _aaagCreatedDate = createdDate;
    _aaagInStock = inStock;
    _aaagHolder = holder;
    _aaagDateOfLastWithdrawal = dateOfLastWithdrawal;
    _aaagDateOfLastReturn = dateOfLastReturn;

    _aaagId = id;
  }

  public AAAGTool(String name, DateTime createdDate, bool inStock, DateTime dateOfLastWithdrawal, DateTime dateOfLastReturn, String id)
  {
    _aaagName = name;
    _aaagCreatedDate = createdDate;
    _aaagInStock = inStock;
    _aaagDateOfLastWithdrawal = dateOfLastWithdrawal;
    _aaagDateOfLastReturn = dateOfLastReturn;

    _aaagId = id;
  }

  public abstract String AAAGToString();

  public abstract String AAAGGetSaveString();
  public virtual void AAAGWithdraw(AAAGUser user, int amount = 1)
  {
    if (_aaagInStock)
    {
      _aaagHolder = user;
      _aaagInStock = false;
      _aaagDateOfLastWithdrawal = DateTime.Now;
    }
  }

  public virtual void AAAGReturnTool(AAAGUser user, int amount = 1)
  {
    if (!_aaagInStock)
    {
      _aaagHolder = null;
      _aaagInStock = true;
      _aaagDateOfLastReturn = DateTime.Now;
    }
  }

  public virtual bool AAAGIsUserAHolder(AAAGUser user)
  {
    if (_aaagHolder == user)
    {
      return true;
    }
    return false;
  }

  public bool AAAGGetIfInStock()
  {
    return _aaagInStock;
  }

  public String AAAGGetId()
  {
    return $"{_aaagId}";
  }

  public virtual String AAAGGetToolDescription()
  {
    return $"{_aaagName}";
  }

  public virtual bool AAAGAreEnoughToWithdraw(int amount)
  {
    if (_aaagInStock)
    {
      return true;
    }
    return false;
  }

  public virtual bool AAAGCanReturnAmount(int amount)
  {
    if (amount == 1 && _aaagInStock == false)
    {
      return true;
    }
    return false;
  }

  public virtual bool AAAGCanBeReturned()
  {
    if (_aaagInStock == false)
    {
      return true;
    }
    return false;
  }
}