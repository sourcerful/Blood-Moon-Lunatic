using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomWorkshop : RoomScript<RoomWorkshop>
{


	IEnumerator OnEnterRoomAfterFade()
	{
		// Put things here that happen when you enter a room
		
		C.Plr.SetPosition(Point("EntryPoint"));
		
		yield return E.Break;
	}

	IEnumerator OnInteractPropCloset( IProp prop )
	{
		if (Globals.m_charlesArrive == false)
			yield return C.Plr.FaceRight();
			yield return E.WaitSkip();
			yield return C.Plr.FaceDown();
			yield return E.WaitSkip();
			yield return C.Plr.FaceLeft();
			yield return E.WaitSkip();
			yield return C.Plr.FaceClicked();
			yield return E.WaitSkip();
			yield return C.Plr.Say("The closet!");
			yield return E.WaitSkip();
			yield return C.Plr.WalkToClicked(true);
		if (Globals.m_charlesArrive == false)
			yield return C.Plr.FaceClicked();
			yield return C.Plr.WalkToClicked();
		yield return E.Break;
	}

	IEnumerator OnLookAtPropNameList( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.Plr.Say("Huh?");
		yield return C.InnerThoughts.Say("Looks like a page, with some writings on it.");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("I Should check it out.");
		yield return E.Break;
	}

	IEnumerator OnInteractPropNameList( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.WalkToClicked();
		yield return C.InnerThoughts.Say("Wha-");
		yield return C.InnerThoughts.Say("Are those... NAMES?!?");
		yield return E.WaitSkip();
		yield return C.Plr.Say("Is he...");
		yield return E.WaitSkip();
		yield return C.Plr.Say("Some of the names are checked, are they... DEAD?!?");
		yield return C.Plr.Say("Perhaps... Victims?");
		yield return C.InnerThoughts.Say("HE MURDERED THEM!!");
		yield return C.InnerThoughts.Say("THIS ROOM IS FULL OF THEIR BLOOD!");
		yield return E.WaitSkip();
		yield return C.Plr.Say("This has to stop, I need to save the rest of them.");
		yield return E.WaitSkip();
		Globals.m_workshop_pagesExplored = true;
		yield return E.Break;
	}

	IEnumerator OnLookAtPropCloset( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.InnerThoughts.Say("Looks like a filthy closet...");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("His filthy closet.");
		yield return E.Break;
	}

	IEnumerator OnLookAtPropWorkTable( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.Plr.Say("A table");
		yield return E.WaitSkip();
		yield return C.Plr.Say("with some pages on it.");
		yield return E.Break;
	}

	IEnumerator OnInteractPropWorkTable( IProp prop )
	{
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Plr.Say("Looks like a journal of his.");
		yield return C.InnerThoughts.Say("What kind of sick things does this monster have here?");
		yield return C.Plr.Say("The quill... it is resting on the page.");
		yield return E.WaitSkip();
		yield return C.Plr.Say("Red.");
		yield return C.Plr.Say("A single, heavy drop. It glistens in the candlelight.");
		yield return C.Plr.Say("It is not ink... it is too thick. Too dark.");
		
		if (Globals.m_workshop_pagesExplored == true)
			yield return C.InnerThoughts.Say("The blood of his victims!");
			yield return C.InnerThoughts.Say("He uses their blood to write the journal!");
			yield return E.WaitSkip();
			yield return C.Plr.Say("I must read his plans. I must know the truth.");
			yield return C.Display("\"To summon the beast, one must not hesitate to spill blood.\"");
			yield return C.Display("The narrative demands a sacrifice to become immortal.\"");
			yield return C.InnerThoughts.Say("Immortal...");
			yield return C.InnerThoughts.Say("He confesses it on the very page.");
			yield return C.InnerThoughts.Say("The 'narrative'... that is what he calls the ritual.");
			yield return C.InnerThoughts.Say("That's what the blood moon is all about!");
			yield return E.WaitSkip();
			yield return C.InnerThoughts.Say("He is watching. I can feel his cold eyes from the shadows.");
			yield return E.WaitSkip();
			yield return C.Charles.FaceRight(true);
			yield return E.ChangeRoom(R.Forest);
			C.Charles.Enable();
			Audio.Play("Bucket"); // bedroom door closes
			Globals.m_charlesArrive = true;
			yield return E.ChangeRoom(R.Workshop);
			yield return C.InnerThoughts.Say("Oh god, he's here!");
			yield return E.WaitSkip();
			yield return C.InnerThoughts.Say("I must hide.");
			yield return C.Display("HIDE IN THE CLOSET");
		yield return E.Break;
	}
}