using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class CharacterCharles : CharacterScript<CharacterCharles>
{


	public IEnumerator OnInteract()
	{
		yield return C.FaceClicked();
		yield return C.Charles.Say("Luna, come.");
		yield return C.Charles.Face(C.Player);
		yield return C.WalkToClicked();
		yield return C.Plr.Face(C.Charles);
		yield return C.Plr.Say("Yes my lord?");
		D.ChatWithCharles.Start();
		Globals.m_spokeToCharles= true;
		yield return E.Break;
		
	}
}
