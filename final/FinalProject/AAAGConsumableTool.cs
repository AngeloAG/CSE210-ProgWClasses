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

  public AAAGConsumableTool(String name, int amountOfUnits, String unit) : base(name)
  {
    _aaagAmountOfUnits = amountOfUnits;
    _aaagUnit = unit;
  }

  public override string AAAGToString()
  {
    return "";
  }

  public override void AAAGWithdraw(AAAGUser user)
  {
    base.AAAGWithdraw(user);
  }

  public override void AAAGReturnTool()
  {
    base.AAAGReturnTool();
  }
}