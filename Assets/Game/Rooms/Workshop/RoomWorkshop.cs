using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;
using System.Collections.Generic;

public class RoomWorkshop : RoomScript<RoomWorkshop>
{

	private HashSet<IProp> _interactToProceed;
	IEnumerator OnEnterRoomAfterFade()
	{
		this._interactToProceed = new HashSet<IProp> { Prop("NameList"), Prop("WorkTable") };
        Globals.m_progressExample = eProgress.Room2;
		C.Plr.SetPosition(Point("EntryPoint"));
		C.Elton.Disable();
		C.Charles.Disable();
		yield return E.Break;
	}

	IEnumerator OnInteractPropCloset( IProp prop )
	{
		if (Globals.m_charlesArrive == true)
		{
			E.StartCutscene();
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
			C.Plr.WalkSpeed = new Vector2(80,80);
			yield return C.Plr.WalkToClicked(true);
			yield return C.Plr.FaceClicked();
			yield return C.Plr.WalkToClicked();
			C.Plr.ResetWalkSpeed();
			E.EndCutscene();
		
			yield return E.Wait(1);
		
			E.StartCutscene();
			yield return C.Charles.ChangeRoom(R.Workshop);
			C.Charles.Enable();
            C.Charles.SetPosition(Point("EntryPoint"));
			yield return C.Charles.FaceLeft(true);
			yield return E.Wait(1);
		
			yield return C.Charles.Say("That's weird, Did I forgot to lock the room?");
			yield return C.Charles.Say("Luna are you in here?");
			yield return C.InnerThoughts.Say("I have to keep quiet, If he finds me in here I am DONE");
			yield return E.Wait((float) 0.5);
			yield return C.Charles.Say("Anyway, I have to get the list again. I can't keep Elton waiting");
			yield return C.InnerThoughts.Say("Dear god, He killed another one...");
			C.Charles.WalkSpeed = new Vector2(50,50);
			yield return C.Charles.WalkTo(Prop("NameList"));
			yield return C.Charles.Face(eFace.Up);
			C.Charles.Cursor="Left";
		
			yield return E.Wait(1);
			yield return C.InnerThoughts.Say("He is looking away");
			yield return C.InnerThoughts.Say("This is it. I still got the bottle. It has to be now...");
			yield return C.InnerThoughts.Say("I have to kill this fiend NOW");
			Prop("Closet").Clickable=false;
			E.EndCutscene();
		}
		else{
			yield return C.WalkToClicked();
			yield return C.FaceClicked();
			yield return C.InnerThoughts.Say("A closet, It's empty");
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtPropNameList( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.Plr.Say("Huh?");
		yield return C.InnerThoughts.Say("Looks like a page, with some writings on it.");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("I should check it out.");
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
		yield return C.Plr.Say("Some of the names are checked...");
		yield return C.Plr.Say("Perhaps... Victims?");
		yield return C.InnerThoughts.Say("Wait... are they... DEAD?!?");
		yield return C.InnerThoughts.Say("HE MURDERED SO MANY PEOPLE?!?");
		yield return C.InnerThoughts.Say("THIS ROOM IS FULL OF THEIR BLOOD!");
		yield return E.WaitSkip();
		yield return C.Plr.Say("This has to stop!");
		yield return E.WaitSkip();
		yield return E.WaitFor(()=> this.tryToProceed(prop) );
		
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
		
		
		yield return C.InnerThoughts.Say("The blood of his victims!");
		yield return C.InnerThoughts.Say("He uses their blood to write the journal!");
		yield return E.WaitSkip();
		yield return C.Plr.Say("I must read his plans. I must know the truth.");
		yield return C.Display("\"To unleash the inner beast, one must not hesitate to spill blood.\"");
		yield return C.Display("A sacrifice of a maiden is required to become immortal.\"");
		yield return C.InnerThoughts.Say("Immortal...");
		yield return C.InnerThoughts.Say("He confesses it on the very page.");
		yield return C.InnerThoughts.Say("A maiden... I was wrong all along...");
		yield return C.InnerThoughts.Say("He needs me to complete his ritual");
		yield return C.InnerThoughts.Say("This lunatic kept me unconverted just to use me as a sacrifice!");
		yield return E.WaitSkip();
		yield return E.WaitFor(()=> this.tryToProceed(prop) );
		yield return E.Break;
	}

	IEnumerator tryToProceed(IProp prop)
	{

		if (this._interactToProceed.Remove(prop))
		{
            if (this._interactToProceed.Count == 0)
			{
				yield return C.InnerThoughts.Say("He is watching. I can feel his cold eyes from the shadows.");
				yield return E.WaitSkip();
				C.Plr.Visible = false;
				yield return E.ChangeRoom(R.Bedroom);

                C.Charles.Enable();
                C.Charles.Visible = false;
                C.Charles.SetPosition(Point("EntryWalk"));
                yield return C.Charles.FaceRight(true);

				yield return E.WaitSkip();
				C.Charles.Visible = true;
				Globals.m_charlesArrive = true;
				yield return E.Wait();
				Audio.Play("Bucket"); // bedroom door closes
				yield return E.WaitSkip();
				yield return C.Charles.Say("I shall finish my work");
				C.Charles.WalkToBG(Point("WorkshopDoor"));
				yield return E.Wait(1);

				yield return E.ChangeRoom(R.Workshop);
				C.Plr.SetPosition(Point("WorkTable"));
				C.Plr.Visible = true;

				yield return E.WaitSkip();
				yield return C.Plr.FaceRight();
				yield return C.InnerThoughts.Say("Oh god, he's here!");
				yield return E.WaitSkip();
				yield return C.InnerThoughts.Say("I must hide, FAST");
				yield return C.Display("HIDE IN THE CLOSET");
				Prop("NameList").Clickable = false;
				Prop("WorkTable").Clickable = false;
			}
		}
        yield return E.Break;
    }
}