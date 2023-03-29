/*
Author: Alberto Angelo Arellano Gaona
Date: 
Description:
Holds the information for a power tool in the inventory

Attributes:
Name of the tool
Date it was created
Who has it right now
If it is in stock
When it was taken out
If it has uses a battery

Behaviors: 
ToString
Withdraw
*/

public class AAAGPowerTool : AAAGTool
{
  private bool _aaagUsesBattery;

  public AAAGPowerTool(String name, bool usesBattery) : base(name)
  {
    _aaagUsesBattery = usesBattery;
  }

  public AAAGPowerTool(String name, bool usesBattery, DateTime createdDate, AAAGUser holder, bool inStock, DateTime dateOfLastWithdrawal, DateTime dateOfLastReturn, String id) : base(name, createdDate, holder, inStock, dateOfLastWithdrawal, dateOfLastReturn, id)
  {
    _aaagUsesBattery = usesBattery;
  }

  public override String AAAGToString()
  {
    if (base._aaagInStock)
    {
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}|{_aaagUsesBattery}|Warehouse||";
    }
    else
    {
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}|{_aaagUsesBattery}|{base._aaagHolder.AAAGToString()}|{base._aaagDateOfLastWithdrawal.ToShortDateString()}|";
    }
  }

  public override string AAAGGetSaveString()
  {
    if (base._aaagInStock)
    {
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}|{_aaagUsesBattery}|Warehouse|{base._aaagDateOfLastWithdrawal.ToString()}|{base._aaagDateOfLastReturn.ToString()}|{base._aaagCreatedDate.ToString()}|power";
    }
    else
    {
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}|{_aaagUsesBattery}|{base._aaagHolder.AAAGGetId()}|{base._aaagDateOfLastWithdrawal.ToString()}|{base._aaagDateOfLastReturn.ToString()}|{base._aaagCreatedDate.ToString()}|power";
    }
  }
}