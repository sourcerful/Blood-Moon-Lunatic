using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class DialogKillingCharles : DialogTreeScript<DialogKillingCharles>
{
	public IEnumerator OnStart()
	{
		yield return E.Break;
	}

	public IEnumerator OnStop()
	{
		yield return E.Break;
	}

	IEnumerator Option1(IDialogOption option)
	{
		yield return C.InnerThoughts.Say("Head");
		yield return C.Display("Luna lifts the bottle and hits Charles on his head");
		yield return C.Display("The glass shatters against his skull... he's dazed!");
		yield return C.Charles.Say("Eahhhhhhhhhhhhhhhhhhhhhh");
		yield return C.Display("Your bottle has been broken, you got a broken bottle!");
		yield return C.Display("You are now able to stab Charles");
		
		C.Charles.LookAtPoint = C.Player.Position;
		
		D.KillingCharles.OptionOff(1);
		D.KillingCharles.OptionOn(2);
		yield return E.Break;
	}


	IEnumerator Option2( IDialogOption option )
	{
		Globals.m_stabCounter++;
		
		switch ( Globals.m_stabCounter){
			case 1:
			yield return C.InnerThoughts.Say("Lungs");
			yield return C.Charles.Say("Ghk—!");
			break;
			case 2:
			yield return C.InnerThoughts.Say("Kidneys");
			yield return C.Charles.Say("Ack... h-hah...");
			break;
			case 3:
			yield return C.InnerThoughts.Say("Eyes");
			yield return C.Charles.Say("AGHHH-! MY EYES! I CAN'T—!");
				break;
			case 4:
			yield return C.InnerThoughts.Say("Heart");
			yield return C.Charles.Say("...ghhh...");
				break;
			case 5:
			yield return C.InnerThoughts.Say("Heart");
				break;
			case 6:
			yield return C.InnerThoughts.Say("Heart");
			yield return E.Wait(1);
		
			yield return C.InnerThoughts.Say("I did it, He is finally dead... I am free");
			yield return C.InnerThoughts.Say("I-I saved the town...");
			yield return E.Wait((float) 0.5);
			yield return C.Display("A book falls from Charles's coat, it reads:\nThe Blood Moon - By Charles Smith");
			D.KillingCharles.Stop();
			yield return E.Wait((float) 1.5);
		
			yield return C.Elton.ChangeRoom(R.Workshop);
			C.Elton.Enable();
			C.Elton.SetPosition(Point("EntryPoint"));
			yield return C.Elton.Say("You have made a grave mistake little one...");
			//C.Elton.Position=Point("Entry2");
			break;
		}
		yield return E.Break;
		
	}
}