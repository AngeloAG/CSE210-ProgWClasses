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

  public override string AAAGToString()
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