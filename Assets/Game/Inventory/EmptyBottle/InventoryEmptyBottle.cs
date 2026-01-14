using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryEmptyBottle : InventoryScript<InventoryEmptyBottle>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.InnerThoughts.Say("An empty bottle");
		yield return E.Break;
	}
}