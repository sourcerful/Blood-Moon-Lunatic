using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterTest : CharacterScript<CharacterTest>
{


	IEnumerator OnInteract()
	{

		yield return E.Break;
	}
}