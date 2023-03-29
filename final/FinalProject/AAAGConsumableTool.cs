/*
Author: Alberto Angelo Arellano Gaona
Date: 
Description:
Holds the information for a consumable tool in the inventory like bolts or screws

Attributes:
Name of the tool
Date it was created
Who has it right now
If it is in stock
When it was taken out
And how many there are

Behaviors: 
ToString
Withdraw
Return
*/

public class AAAGConsumableTool : AAAGTool
{
  private int _aaagAmountOfUnits;
  private String _aaagUnit;
  private int _aaagCurrentAmountOfUnits;
  private List<AAAGUser> _aaagHolders = new List<AAAGUser>() { new AAAGUser("Warehouse", "Warehouse", ".") };

  public AAAGConsumableTool(String name, int amountOfUnits, String unit) : base(name)
  {
    _aaagAmountOfUnits = amountOfUnits;
    _aaagUnit = unit;
    _aaagCurrentAmountOfUnits = amountOfUnits;
  }

  public AAAGConsumableTool(String name, int amountOfUnits, String unit, int currentAmount, DateTime createdDate, List<AAAGUser> holders, bool inStock, DateTime dateOfLastWithdrawal, DateTime dateOfLastReturn, String id) : base(name, createdDate, inStock, dateOfLastWithdrawal, dateOfLastReturn, id)
  {
    _aaagAmountOfUnits = amountOfUnits;
    _aaagUnit = unit;
    _aaagCurrentAmountOfUnits = currentAmount;
    _aaagHolders = holders;
  }

  public override string AAAGToString()
  {
    if (base._aaagInStock)
    {
      if (_aaagCurrentAmountOfUnits < _aaagAmountOfUnits)
      {
        var holdersList = from holder in _aaagHolders select holder.AAAGGetId();
        string holdersString = string.Join(",", holdersList);
        return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||{holdersString}|{base._aaagDateOfLastWithdrawal.ToShortDateString()}|{_aaagCurrentAmountOfUnits}/{_aaagAmountOfUnits} {_aaagUnit}";
      }
      else
      {
        return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||Warehouse||{_aaagCurrentAmountOfUnits}/{_aaagAmountOfUnits} {_aaagUnit}";
      }
    }
    else
    {
      var holdersList = from holder in _aaagHolders select holder.AAAGGetId();
      string holdersString = string.Join(",", holdersList);
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||{holdersString}|{base._aaagDateOfLastWithdrawal.ToShortDateString()}|{_aaagCurrentAmountOfUnits}/{_aaagAmountOfUnits} {_aaagUnit}";
    }
  }

  public override string AAAGGetSaveString()
  {
    if (base._aaagInStock)
    {
      if (_aaagCurrentAmountOfUnits < _aaagAmountOfUnits)
      {
        var holdersList = from holder in _aaagHolders select holder.AAAGGetId();
        string holdersString = string.Join(",", holdersList);
        return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||{holdersString}|{base._aaagDateOfLastWithdrawal.ToString()}|{base._aaagDateOfLastReturn.ToString()}|{base._aaagCreatedDate.ToString()}|{_aaagCurrentAmountOfUnits}|{_aaagAmountOfUnits}|{_aaagUnit}|consumable";
      }
      else
      {
        return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||Warehouse|{base._aaagDateOfLastWithdrawal.ToString()}|{base._aaagDateOfLastReturn.ToString()}|{base._aaagCreatedDate.ToString()}|{_aaagCurrentAmountOfUnits}|{_aaagAmountOfUnits}|{_aaagUnit}|consumable";
      }
    }
    else
    {
      var holdersList = from holder in _aaagHolders select holder.AAAGGetId();
      string holdersString = string.Join(",", holdersList);
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||{holdersString}|{base._aaagDateOfLastWithdrawal.ToString()}|{base._aaagDateOfLastReturn.ToString()}|{base._aaagCreatedDate.ToString()}|{_aaagCurrentAmountOfUnits}|{_aaagAmountOfUnits}|{_aaagUnit}|consumable";
    }
  }

  public override void AAAGWithdraw(AAAGUser user, int amount)
  {
    if (_aaagInStock && amount <= _aaagCurrentAmountOfUnits)
    {
      _aaagHolders.Add(user);
      _aaagDateOfLastWithdrawal = DateTime.Now;
      _aaagCurrentAmountOfUnits -= amount;
      if (_aaagCurrentAmountOfUnits == 0)
      {
        _aaagInStock = false;
      }
    }
  }

  public override void AAAGReturnTool(AAAGUser user, int amount)
  {
    if (amount <= _aaagAmountOfUnits)
    {
      _aaagHolders.Remove(user);
      _aaagDateOfLastReturn = DateTime.Now;
      _aaagCurrentAmountOfUnits += amount;
      if (_aaagCurrentAmountOfUnits > 0)
      {
        _aaagInStock = true;
      }
    }
  }

  public override bool AAAGIsUserAHolder(AAAGUser user)
  {
    int aaagUserIndex = _aaagHolders.FindIndex((AAAGUser listUser) => listUser == user);
    if (aaagUserIndex >= 0)
    {
      return true;
    }
    return false;
  }
  public override string AAAGGetToolDescription()
  {
    return $"{base._aaagName}, Available {_aaagCurrentAmountOfUnits}/{_aaagAmountOfUnits} {_aaagUnit}";
  }

  public override bool AAAGAreEnoughToWithdraw(int amount)
  {
    if (_aaagInStock && amount <= _aaagCurrentAmountOfUnits)
    {
      return true;
    }
    return false;
  }

  public override bool AAAGCanReturnAmount(int amount)
  {
    if (amount <= (_aaagAmountOfUnits - _aaagCurrentAmountOfUnits))
    {
      return true;
    }
    return false;
  }

  public override bool AAAGCanBeReturned()
  {
    if (_aaagCurrentAmountOfUnits <= _aaagAmountOfUnits)
    {
      return true;
    }
    return false;
  }
}