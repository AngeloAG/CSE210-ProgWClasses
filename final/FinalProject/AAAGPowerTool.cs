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

  public override String AAAGToString()
  {
    if (base._aaagInStock)
    {
      return $"";
    }
    else
    {
      return $"";
    }
  }
}