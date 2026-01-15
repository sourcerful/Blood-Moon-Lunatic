using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterElton : CharacterScript<CharacterElton>
{


	IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		D.ChatWithElton.Start();
		yield return E.Break;
	}

	IEnumerator OnLookAt()
	{
		yield return C.InnerThoughts.Say("Who is this guy");
		yield return E.Break;
	}
}