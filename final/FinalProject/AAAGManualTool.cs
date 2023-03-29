/*
Author: Alberto Angelo Arellano Gaona
Date: 
Description:
Holds the information for a manual tool in the inventory

Attributes:
Name of the tool
Date it was created
Who has it right now
If it is in stock
When it was taken out

Behaviors: 
ToString
Withdraw
*/

public class AAAGManualTool : AAAGTool
{

  public AAAGManualTool(String name) : base(name)
  {

  }

  public AAAGManualTool(String name, DateTime createdDate, AAAGUser holder, bool inStock, DateTime dateOfLastWithdrawal, DateTime dateOfLastReturn, String id) : base(name, createdDate, holder, inStock, dateOfLastWithdrawal, dateOfLastReturn, id)
  {

  }
  public override string AAAGToString()
  {
    if (base._aaagInStock)
    {
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||Warehouse||";
    }
    else
    {
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||{base._aaagHolder.AAAGToString()}|{base._aaagDateOfLastWithdrawal.ToShortDateString()}|";
    }
  }

  public override string AAAGGetSaveString()
  {
    if (base._aaagInStock)
    {
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||Warehouse|{base._aaagDateOfLastWithdrawal.ToString()}|{base._aaagDateOfLastReturn.ToString()}|{base._aaagCreatedDate.ToString()}|manual";
    }
    else
    {
      return $"{base._aaagId}|{base._aaagName}|{base._aaagInStock}||{base._aaagHolder.AAAGGetId()}|{base._aaagDateOfLastWithdrawal.ToString()}|{base._aaagDateOfLastReturn.ToString()}|{base._aaagCreatedDate.ToString()}|manual";
    }
  }
}