using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;
using System.Collections.Generic;
using System;

public class RoomWorkshop : RoomScript<RoomWorkshop>
{

	
	private HashSet<IProp> _interactToProceed;
	private bool _door_closed = false;
	private bool _hit_charles = false;
	IEnumerator OnEnterRoomAfterFade()
	{
		this._interactToProceed = new HashSet<IProp> { Prop("NameList"), Prop("WorkTable"), Prop("Bookcase") };
		C.Plr.SetPosition(Point("EntryPoint"));
		C.Elton.Disable();
		C.Charles.Disable();
		C.Plr.FaceRightBG(true);
		
		Audio.Stop("FireSound");
		
		if (FirstTimeVisited)
		{
			Audio.StopMusic(1f);
			Globals.m_progressExample = eProgress.Room2;
			C.Plr.ClearInventory();
			C.Plr.AddInventory(I.FullBottle);
			C.Plr.AddInventory(I.Key);
			yield return E.Wait(1);
			Audio.Play("DoorClose");
			yield return E.Wait(0.5f);
			yield return C.InnerThoughts.Say("Blood...");
			yield return E.Wait(0.5f);
			Audio.PlayMusic("TheWorkshop", 2.5f);
			yield return E.Wait(0.5f);
			yield return C.InnerThoughts.Say("Everywhere...");
			yield return E.Break;
		}
	}

	IEnumerator OnInteractPropCloset( IProp prop )
	{
		if (Globals.m_progressExample == eProgress.CharlesArrive)
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
			Prop("Bookcase").Clickable = false;
			C.Plr.WalkSpeed = new Vector2(80,80);
			yield return C.Plr.WalkTo(Point("HidingSpot"));
			C.Plr.ResetWalkSpeed();
			E.EndCutscene();
		
			yield return E.Wait(1);
		
			E.StartCutscene();
			C.Charles.Visible = false;
			yield return C.Charles.ChangeRoom(R.Workshop);
			Camera.SetCharacterToFollow(C.Charles);
			yield return E.WaitSkip();
			C.Charles.Enable();
			yield return C.Charles.FaceRight();
			C.Charles.SetPosition(Prop("WorkshopDoor").Position.x + 30, Prop("WorkshopDoor").Position.y - 45);
			yield return E.WaitSkip();
		
		
			if(!this._door_closed)
			{
				C.Charles.Visible = true;
				yield return E.Wait(1);
				yield return C.Charles.FaceLeft(true);
				yield return E.Wait(1);
		
				yield return C.Charles.Say("That's weird, Did I forgot to lock the room?");
				yield return E.Wait(1);
				Audio.Play("DoorClose");
				yield return E.Wait(1);
				yield return C.Charles.FaceRight();
				yield return E.WaitSkip();
				yield return C.Charles.Say("Luna? are you in here?");
				yield return E.WaitSkip();
				Camera.SetCharacterToFollow(C.Luna);
				yield return E.WaitSkip();
				yield return C.InnerThoughts.Say("I have to keep quiet, If he finds me in here I am DONE");
				yield return E.WaitSkip();
				Camera.SetCharacterToFollow(C.Charles);
				yield return E.WaitSkip();
				yield return C.Charles.WalkTo(Point("EntryPoint"));
				yield return C.Charles.Say("Hmm...");
				yield return E.WaitSkip();
				yield return C.Charles.Say("Anyway, I have to get the list again. I can't keep Elton waiting.");
			}
			else
			{
				yield return E.Wait(1);
				Audio.Play("DoorOpen");
				yield return E.Wait(1);
				C.Charles.Visible = true;
				yield return E.Wait(1);
				yield return C.Charles.FaceLeft(true);
				yield return E.Wait(1);
				Audio.Play("DoorClose");
				yield return E.Wait(1);
		
				yield return C.Charles.Say("Hmm...");
				yield return E.WaitSkip();
				yield return C.Charles.FaceRight();
				yield return E.WaitSkip();
				Camera.SetCharacterToFollow(C.Luna);
				yield return E.WaitSkip();
				yield return C.InnerThoughts.Say("I have to keep quiet, If he finds me in here I am DONE");
				yield return E.WaitSkip();
				Camera.SetCharacterToFollow(C.Charles);
				yield return E.WaitSkip();
				yield return C.Charles.WalkTo(Point("EntryPoint"));
				yield return E.WaitSkip();
				yield return C.Charles.Say("I better get to my list again, I can't keep Elton waiting.");
			}
			yield return E.WaitSkip();
			Camera.SetCharacterToFollow(C.Luna);
			yield return E.WaitSkip();
			yield return C.InnerThoughts.Say("He killed another one...");
			yield return C.InnerThoughts.Say("O Lord, Give Elton eternal rest...");
			yield return E.WaitSkip();
			Camera.SetCharacterToFollow(C.Luna);
			C.Charles.WalkSpeed = new Vector2(50,50);
			yield return C.Charles.WalkTo(Prop("NameList"));
			yield return C.Charles.Face(eFace.Up);
			C.Charles.Cursor="Left";
		
			yield return E.Wait(1);
			yield return C.InnerThoughts.Say("He is looking away");
			yield return C.InnerThoughts.Say("This is it. I still got the bottle. It has to be now...");
			yield return C.InnerThoughts.Say("I have to kill this fiend NOW");
			Prop("Closet").Clickable=false;
			C.Charles.Cursor = "FullBottle";
			E.EndCutscene();
			R.Current.ActiveWalkableArea = 1;
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
		C.Plr.FaceUpBG();
		yield return C.Plr.Say("Wha-");
		yield return C.InnerThoughts.Say("Are those... NAMES?!?");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("Is he...");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("Some of the names are checked...");
		yield return C.InnerThoughts.Say("Perhaps... Victims?");
		yield return C.InnerThoughts.Say("Wait... are they... DEAD?!?");
		yield return C.InnerThoughts.Say("HE MURDERED SO MANY PEOPLE?!?");
		yield return C.InnerThoughts.Say("THIS ROOM IS FULL OF THEIR BLOOD!");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("This has to stop!");
		yield return E.WaitSkip();
		yield return E.WaitFor(()=> this.tryToProceed(prop) );
		
 }

    IEnumerator OnLookAtPropCloset( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.InnerThoughts.Say("Looks like his giant filthy closet...");
		yield return E.WaitSkip();
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
		yield return C.InnerThoughts.Say("Looks like a journal of his.");
		yield return C.InnerThoughts.Say("What kind of sick things does this monster have here?");
		yield return C.InnerThoughts.Say("The quill... it is resting on the page.");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("Red.");
		yield return C.InnerThoughts.Say("A single, heavy drop. It glistens in the candlelight.");
		
		
		yield return C.InnerThoughts.Say("The blood of his victims!");
		yield return C.InnerThoughts.Say("He uses their blood to write the journal!");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("I must read his plans. I must know the truth.");
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
				Audio.PlayMusic("Obstacle");
                yield return C.InnerThoughts.Say("He is watching. I can feel his cold eyes from the shadows.");
				yield return E.WaitSkip();
				C.Plr.Visible = false;
				C.Plr.SetPosition(Point("EntryPoint"));
				yield return E.ChangeRoom(R.Bedroom);
		
				C.Charles.Enable();
				C.Charles.Visible = false;
				C.Charles.SetPosition(-145, -85, eFace.Up);
				yield return E.WaitSkip();
				C.Charles.Visible = true;
				Globals.m_progressExample = eProgress.CharlesArrive;
				yield return C.Charles.FaceDownLeft();
				yield return E.Wait(1);
				Audio.Play("DoorClose"); // bedroom door closes
				yield return E.Wait(1.5f);
				yield return C.Charles.FaceRight();
				yield return C.Charles.Say("I shall finish my work");
				C.Charles.WalkToBG(Point("WorkshopDoor"));
				yield return E.Wait(1);
				yield return E.ChangeRoom(R.Workshop);
				yield return C.Plr.FaceLeft();
				C.Plr.Visible = true;
		
				yield return E.WaitSkip();
				yield return C.Plr.FaceRight();
				yield return C.InnerThoughts.Say("No... He's here!");
				if (!this._door_closed)
				{
					yield return C.InnerThoughts.Say("The door, I left it open!");
				}
				yield return C.InnerThoughts.Say("He must not find me here!");
				yield return E.WaitSkip();
				Prop("NameList").Clickable = false;
				Prop("WorkTable").Clickable = false;
			}
		}
		yield return E.Break;
		
 }

	IEnumerator OnInteractCharacterCharles( ICharacter character )
	{
		if(!_hit_charles)
		{
			Vector2 luna_attack_pos = C.Charles.Position;
			luna_attack_pos.y -= 50;
			yield return C.Luna.WalkTo(luna_attack_pos);
			yield return C.Luna.FaceUp();
			D.HittingCharles.Start();
			_hit_charles = true;
		}
		else
		{
			yield return C.WalkToClicked();
			yield return C.Plr.FaceUpRight();
			D.StabbingCharles.Start();
		}
		yield return E.Break;
	}

	IEnumerator OnInteractPropWorkshopDoor( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.InnerThoughts.Say("Going back would be a waste of time, I have to search up the room for clues");
		yield return E.Break;
	}

	IEnumerator OnUseInvPropWorkshopDoor( IProp prop, IInventory item )
	{
		if (item == I.Key)
		{
			if(Globals.m_progressExample == eProgress.CharlesArrive && !this._door_closed)
			{
				yield return C.WalkToClicked();
				yield return C.FaceClicked();
				Audio.Play("Lock");
				yield return E.WaitSkip();
				this._door_closed = true;
				yield return C.Display("Workshop door locked.");
				yield return E.WaitSkip();
				yield return C.Plr.FaceRight();
				yield return C.InnerThoughts.Say("I must hide, AND FAST");
			}
			else if(!this._door_closed)
			{
				yield return C.WalkToClicked();
				yield return C.FaceClicked();
				Audio.Play("Lock");
				yield return E.WaitSkip();
				this._door_closed = true;
				yield return C.Display("Workshop door locked.");
			}
		}
		yield return E.Break;
	}


	IEnumerator OnUseInvCharacterCharles( ICharacter character, IInventory item )
	{
		if (item == I.BrokenBottle)
		{
			D.StabbingCharles.Start();
		}

		yield return E.Break;
	}

	IEnumerator OnInteractPropBookcase( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.WalkToClicked();
		C.Plr.FaceUpBG();
		if(Globals.m_progressExample == eProgress.CharlesArrive)
		{
			yield return C.InnerThoughts.Say("I can't hide in here");
		}
		else
		{
		yield return C.InnerThoughts.Say("Maybe his books will give me more information on how to beat him");
		yield return C.InnerThoughts.Say("This one looks interesting");
		yield return C.Display("Luna flips through the pages of \"Basic Anatomy by Leo Sho\", Trying to gather as much information as possible.");
		yield return C.Display("Luna now somewhat understands the basics of anatomy!");
		yield return E.WaitSkip();
		yield return E.WaitFor(()=> this.tryToProceed(prop) );
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtPropBookcase( IProp prop )
	{

		yield return C.FaceClicked();
		if(Globals.m_progressExample == eProgress.CharlesArrive)
		{
			yield return C.InnerThoughts.Say("I can't hide in here");
		}
		else
		{
		yield return C.InnerThoughts.Say("It's filled to the brim with books");
		}
		yield return E.Break;
	}

	IEnumerator OnLookAtPropWorkshopDoor( IProp prop )
	{
		yield return C.FaceClicked();
		yield return C.InnerThoughts.Say("I lived in this castle for most of my life...");
		yield return C.InnerThoughts.Say("and it's still the first time seeing this door from the opposite side...");
		yield return E.Break;
	}
}