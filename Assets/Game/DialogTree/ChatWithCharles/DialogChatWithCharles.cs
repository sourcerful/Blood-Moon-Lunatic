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
		yield return C.Plr.Say("Is everything alright?");
		yield return E.WaitSkip();
		yield return C.Charles.Say("Indeed. The Blood Moon’s arrival is nigh.");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("Dear god...");
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
		yield return C.Plr.Say("Y-You are covered in red again... My Lord, it's... it's all over your sleeve.");
		
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
		yield return C.Charles.Say("As usual, Do NOT go into my office!");
		yield return E.WaitSkip();
		yield return C.Plr.Say("Of course my lord.");
		yield return E.WaitSkip();
		yield return C.Charles.WalkTo(-250, -54);
		yield return C.Plr.Face(C.Charles);
		C.Charles.Disable();
		yield return C.Plr.ChangeRoom(R.Workshop);
		Stop();
		yield return C.InnerThoughts.Say("Why would he still insist on me not entering his office?");
		yield return C.InnerThoughts.Say("There must be a way to stop him in there");
		yield return C.InnerThoughts.Say("His spare key should be somewhere in this room");
		yield return C.Display("Left Click to Walk & Interact\nRight Click to Look At");
		yield return E.Break;
	}

	IEnumerator Option2( IDialogOption option )
	{
		yield return C.Plr.Say(option.Description);
		if(!option.FirstUse)
			yield return C.Charles.Say(" As I said...");
		yield return E.WaitSkip();
		yield return C.Charles.Say("I have some final preparations to make in town, for the Blood Moon.");
		yield return C.Charles.Say("There are certain...");
		yield return C.Charles.Say("arrangements that must be handled in person.");
		yield return E.WaitSkip();
		
		if(option.FirstUse)
			yield return C.Plr.WalkTo(C.Player.Position.x - 10, C.Player.Position.y, true);
			yield return C.Plr.Face(C.Charles);
			yield return C.Plr.Say("And then... what will you do?");
			yield return C.Charles.Say("I must mark the shops and the square.");
			yield return C.Charles.Say("By tomorrow morning, no one will be able to walk down the main street without seeing the signs of what is coming.");
			yield return C.Charles.Say("I want the town to wake up and feel the weight of the Blood Moon before it even arrives.");
		
		if(Option(1).Used)
			OptionOn(3);
		yield return E.Break;
	}

	IEnumerator Option3( IDialogOption option )
	{
		yield return C.Plr.Say(option.Description);
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
		yield return C.InnerThoughts.Say("If the blood moon starts... This town would be no more than a big bloodshed.");
		yield return C.InnerThoughts.Say("I must do something, and fast.");
		yield return E.WaitSkip();
		OptionOn("End");
		yield return E.Break;
	}
}