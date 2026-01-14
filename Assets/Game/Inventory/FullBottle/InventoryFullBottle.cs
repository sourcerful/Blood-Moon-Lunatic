using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryFullBottle : InventoryScript<InventoryFullBottle>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.InnerThoughts.Say("A bottle filled with blood");
		yield return C.InnerThoughts.Say("Charles doesn't strike like someone that would drink from a bottle");
		yield return E.Break;
	}
}