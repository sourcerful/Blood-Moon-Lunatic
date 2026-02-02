using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class DialogChatWithCharles : DialogTreeScript<DialogChatWithCharles>
{
	public IEnumerator OnStart()
	{
		yield return C.Charles.Say("I shall be absent this evening.");
		yield return C.InnerThoughts.Say("This blood sucking fiend");
		yield return C.InnerThoughts.Say("He always lurks out at night to feed off the blood of the townsfolk");
		yield return C.InnerThoughts.Say("But this doesn't match his usual routine...");
		yield return C.Plr.Say("Is everything alright?");
		yield return E.WaitSkip();
		yield return C.Charles.Say("Indeed. The Blood Moon’s arrival is nigh.");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("O Lord...");
		yield return E.WaitSkip();
		yield return E.Break;
	}

	public IEnumerator OnStop()
	{
		
		yield return E.Break;
	}

	IEnumerator Option1( IDialogOption option )
	{
		yield return C.Plr.Say(option.Description);
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("Again... He has blood on his hands...");
		yield return C.InnerThoughts.Say("This fiend sucked another victim of their blood...");
		yield return C.Plr.Say("Y-You are covered in red again... My Lord, it's... it's all over your sleeve.");
		
		if(option.TimesUsed > 2)
			yield return C.Charles.Say("Are you deaf?");
		yield return E.WaitSkip();
		if(!option.FirstUse)
			yield return C.Charles.Say(" As I said...");
		yield return C.Charles.Say("Luna, as you know, what I do can get quite...");
		yield return E.WaitSkip();
		yield return C.Charles.Say("messy sometimes.");
		yield return C.Charles.Say("You already know me, sometimes my calling controls me more than I control it.");
		yield return E.WaitSkip();
		
		if(Option(2).Used)
			OptionOn(3);
		yield return E.Break;
	}

	IEnumerator OptionBye( IDialogOption option )
	{
		Stop();
		yield return E.Break;
	}

	IEnumerator OptionEnd( IDialogOption option )
	{
		yield return C.Charles.Say("Luna, before I leave");
		yield return C.Charles.Say("I'd be glad if you could clean this room for tomorrow's big event.");
		yield return C.Charles.Say("As usual, do NOT go into my office!");
		yield return E.WaitSkip();
		yield return C.Plr.Say("Of course my lord.");
		yield return E.WaitSkip();
		C.Charles.WalkToBG(Point("EntryWalk"));
		yield return E.Wait(2);
		yield return C.Plr.Face(C.Charles);
		yield return E.Wait(2);
		yield return C.Charles.FaceUp();
		yield return E.Wait(2);
		yield return C.Charles.FaceDownRight();
		yield return E.WaitSkip();
		yield return C.Charles.Say("I'd appreciate if you could clean my bed by the time I'm back.");
		yield return E.WaitSkip();
		yield return C.Plr.Say("Yes my lord.");
		C.Charles.WalkToBG(-140, -100);
		yield return E.Wait(2);
		yield return C.Plr.FaceDownLeft();
		Audio.Play("Handle");
		yield return E.Wait(1);
		Audio.Play("DoorOpen");
		yield return E.Wait(2.5f);
		C.Charles.Disable();
		Audio.Play("DoorClose");
		Stop();
		yield return C.InnerThoughts.Say("Why would he still insist on me not entering his office?");
		yield return C.InnerThoughts.Say("There must be a way to stop him in there");
		yield return C.InnerThoughts.Say("His spare key should be here somewhere");
		yield return C.Display("Left Click to Walk & Interact\nRight Click to Look At");
		yield return E.Break;
	}

	IEnumerator Option2( IDialogOption option )
	{
		Vector2 slowWalkSpeed = new Vector2(20,20);
		
		yield return C.Plr.Say(option.Description);
		
		if(option.TimesUsed > 2)
			yield return C.Charles.Say("Are you deaf?");
		yield return E.WaitSkip();
		if(!option.FirstUse)
			yield return C.Charles.Say(" As I said...");
		yield return E.WaitSkip();
		yield return C.Charles.Say("I have some final preparations to make in town, for the Blood Moon.");
		yield return C.Charles.Say("There are certain...");
		yield return C.Charles.Say("arrangements that must be handled in person.");
		yield return E.WaitSkip();
		
		if(option.FirstUse)
		{
			C.Plr.PlayAnimationBG("WalkUR");
			C.Plr.WalkSpeed = slowWalkSpeed;
			yield return C.Plr.MoveTo(C.Player.Position.x - 15, C.Player.Position.y -15, true);
			C.Plr.StopAnimation();
			C.Plr.ResetWalkSpeed();
			yield return C.Plr.Say("And then... what will you do?");
			yield return C.Charles.Say("I must mark the shops and the square.");
			yield return C.Charles.Say("By tomorrow morning, no one will be able to walk down the main street without seeing the signs of what is coming.");
			yield return C.Charles.Say("I want the town to wake up and feel the weight of the Blood Moon before it even arrives.");
		}
		
		if(Option(1).Used)
			OptionOn(3);
		yield return E.Break;
	}

	IEnumerator Option3( IDialogOption option )
	{
		yield return C.Plr.Say(option.Description);
		
		if(option.TimesUsed > 2)
			yield return C.Charles.Say("Are you deaf?");
		yield return E.WaitSkip();
		if(!option.FirstUse)
			yield return C.Charles.Say(" As I said...");
		yield return E.WaitSkip();
		
		yield return C.Charles.Say("Tomorrow, The Blood Moon shall be out.");
		yield return E.WaitSkip();
		yield return C.Charles.Say("It is the moment I step out of the shadows and into the public eye.");
		yield return C.Charles.Say("I want them to be paralyzed!");
		yield return C.Charles.Say("I want their hearts to race");
		yield return C.Charles.Say("their breath to catch in their throats");
		yield return E.WaitSkip();
		yield return C.Charles.Say("and their sleep... to be haunted by my horror.");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("Tomorrow...?");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("If the blood moon starts... He will drain the entire town of their blood.");
		yield return C.InnerThoughts.Say("Everyone's life is at stake here.");
		yield return C.InnerThoughts.Say("I must find a way to stop this upcoming massacre, and fast.");
		yield return E.WaitSkip();
		OptionOn("End");
		yield return E.Break;
	}
}