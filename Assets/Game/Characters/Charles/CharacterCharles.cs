using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterCharles : CharacterScript<CharacterCharles>
{


	public IEnumerator OnInteract()
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		if(R.Workshop.Active)
		{
			D.KillingCharles.Start();
			C.Charles.Clickable=false;
		}
		else
		{
			D.ChatWithCharles.Start();
		}
		yield return E.Break;
	}
}
