using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryBrokenBottle : InventoryScript<InventoryBrokenBottle>
{


	IEnumerator OnUseInvInventory( IInventory thisItem, IInventory item )
	{

		yield return E.Break;
	}
}