using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class DialogChatWithElton : DialogTreeScript<DialogChatWithElton>
{
	public IEnumerator OnStart()
	{
		Audio.PlayMusic("EltonTheme",2f);
		yield return C.Elton.Say("You... You lunatic. Look at what you've done!");
		yield return C.Elton.Say("He was finally finishing it. The book that was going to put this miserable town on the map");
		yield return C.Elton.Say("Charles was a genius! A bit eccentric, sure, but he didn't deserve to be slaughtered in his own home!");
		yield return E.Break;
	}

	public IEnumerator OnStop()
	{
		yield return E.Break;
	}

	IEnumerator Option1( IDialogOption option )
	{
		yield return C.Plr.Say(option.Description);
		yield return C.Elton.Say("My name is Elton, a book publisher from a town nearby");
		yield return C.Elton.Say("Charles spent months coming to my office at night, pitching ideas about his book, The Blood Moon");
		yield return C.Elton.Say("I was the only one who believed in his vision. His horror book ideas were a masterpiece.");
		yield return C.InnerThoughts.Say("He has been helping Charles all this time...");
		yield return C.InnerThoughts.Say("I have to play along for now.");
		C.Elton.Description= "Elton";
		OptionOn(2);
		
		yield return E.Break;
	}

	IEnumerator Option2( IDialogOption option )
	{
		yield return C.Plr.Say(option.Description);
		yield return C.Elton.Say("I came over to help Charles with the final arrangements of the book");
		yield return C.Elton.Say("But YOU killed him.");
		yield return C.InnerThoughts.Say("He sounds genuine, Maybe he doesn't know that Charles is a blood sucking fiend");
		OptionOn(3);
		OptionOn(4);
		yield return E.Break;
	}

	IEnumerator Option4( IDialogOption option )
	{
		yield return C.Plr.Say(option.Description);
		
		yield return C.Elton.Say("What Kill list? The list over there?");
		yield return C.Elton.Say("It's a list of preorders");
		yield return C.Elton.Say("Those people are ALIVE");
		yield return C.Elton.Say("They just paid in advance to receive an early copy of the book");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("They can't be alive... Why would he say that?");
		
		if(Option(3).Used){
			OptionOn(5);
		}
		yield return E.Break;
	}

	IEnumerator Option3( IDialogOption option )
	{
		yield return C.Plr.Say(option.Description);
		
		yield return C.Elton.Say("The Blood Moon");
		yield return C.Elton.Say("He wanted to write a horror story so good that people couldn't sleep. It wasn't a threat... it was an ambition");
		yield return C.Elton.Say("He was a frantic editor. He’d spend all day marking up drafts until he looked like he’d been in a war zone");
		yield return C.Elton.Say("I mean, look at this workshop, red ink scattered everywhere...");
		
		yield return C.InnerThoughts.Say("Charles has fed him so many lies, He can't tell right from wrong...");
		if(Option(4).Used){
			OptionOn(5);
		}
		
		yield return E.Break;
	}

	IEnumerator Option5( IDialogOption option )
	{
		yield return C.Plr.Say(option.Description);
		
		yield return C.Elton.Say("*sigh*");
		yield return C.Elton.Say("Luna... T-That's just wine...");
		yield return E.WaitSkip();
		yield return C.Elton.Say("Your rich imagination sounds unusual...");
		yield return E.WaitSkip();
		yield return C.Elton.Say("I think I am starting to get the full story...");
		yield return C.Elton.Say("Listen, Luna... Have you been diagnosed?");
		yield return C.InnerThoughts.Say("Diagnosed? What does he mean?");
		yield return E.WaitSkip();
		yield return C.Elton.Say("Well, It's too late for that now.");
		OptionOn("End");
		yield return E.Break;
	}

	IEnumerator Option6( IDialogOption option )
	{
		yield return C.Elton.Say("Luna, T-That's wine...");
		yield return C.Elton.Say("I think I am starting to get the full story...");
		yield return C.Elton.Say("Listen... Luna... Have you ever been diagnosed?");
		yield return C.InnerThoughts.Say("Diagnosed?");
		yield return E.Break;
	}

	IEnumerator OptionEnd( IDialogOption option )
	{
		D.ChatWithElton.Stop();
		yield return C.Elton.Say("I have to take you to the authorities.");
		yield return C.Elton.Say("At the end of the day, you killed someone");
		yield return C.Elton.Say("They have places that takes care of people with your condition");
		yield return E.WaitSkip();
		yield return C.InnerThoughts.Say("I don't think I can overpower him. I have to follow him for now");
		yield return C.InnerThoughts.Say("The town will hire investigators and they will find out I saved them all");
		yield return C.Plr.Say("Okay, Lets go.");
		yield return C.Elton.Say("One last thing Before we go, Luna... I don't judge you, but I don't forgive you either...");
		yield return C.Elton.Say("Your condition,It heavily helped your... \"Vivid imagination\"");
		yield return C.InnerThoughts.Say("He's still doesn't understand, I lived with Charles, I know what he capable of...");
		yield return C.Elton.Say("Let's just say... If I was sharing your mind and hearing your thoughts, I would have probably believed your theory about Charles");
		
		Globals.m_progressExample = eProgress.TalkToElton;
		yield return C.Elton.WalkTo(Point("EntryPoint"));
		C.Elton.Disable();
		yield return C.Plr.WalkTo(Point("EntryPoint"));
		C.Plr.Visible = false;
		E.FadeColor = Color.black;
		yield return E.FadeOut(1f);
		yield return C.Display("To Be Continued");
		Audio.StopMusic(1f);
		E.Restart();
		yield return E.Break;
	}
}