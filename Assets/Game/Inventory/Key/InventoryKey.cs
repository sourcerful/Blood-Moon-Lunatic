using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class InventoryKey : InventoryScript<InventoryKey>
{


	IEnumerator OnLookAtInventory( IInventory thisItem )
	{
		yield return C.InnerThoughts.Say("A key to Charles' workshop");
		yield return E.Break;
	}
}