using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class DialogStabbingCharles : DialogTreeScript<DialogStabbingCharles>
{
	public IEnumerator OnStart()
	{
		yield return E.Break;
	}

	public IEnumerator OnStop()
	{
		yield return E.Break;
	}

	IEnumerator Option1( IDialogOption option )
	{
		Globals.m_stabCounter++;
		
		switch ( Globals.m_stabCounter){
			case 1:
				yield return C.InnerThoughts.Say("*Lungs*");
				Camera.Shake();
				yield return C.Charles.Say("Ghk—!");
				break;
			case 2:
				yield return C.InnerThoughts.Say("*Kidneys*");
				Camera.Shake();
				yield return C.Charles.Say("Ack... h-hah...");
				break;
			case 3:
				yield return C.InnerThoughts.Say("*Eyes*");
				Camera.Shake();
				yield return C.Charles.Say("AGHHH-! MY EYES! I CAN'T—!");
				break;
			case 4:
				yield return C.InnerThoughts.Say("*Heart*");
				Camera.Shake();
				yield return C.Charles.Say("...ghhh...");
				break;
			case 5:
				yield return C.InnerThoughts.Say("*Heart!*");
				Camera.Shake();
				break;
			case 6:
				yield return C.InnerThoughts.Say("*STAB. THE. HEART!*");
				Camera.Shake();
				yield return E.Wait(1);
		
			yield return C.InnerThoughts.Say("I did it, He is finally dead... I am free");
			yield return C.InnerThoughts.Say("I-I saved the town...");
			yield return E.Wait((float) 0.5);
			yield return C.Display("A book falls from Charles's coat, it reads:\nThe Blood Moon - By Charles Smith");
			D.HittingCharles.Stop();
			C.Charles.Clickable = false;
			yield return E.Wait((float) 1.5);
		
			yield return C.Elton.ChangeRoom(R.Workshop);
			C.Elton.Enable();
			C.Elton.SetPosition(Point("EntryPoint"));
			yield return C.Elton.Say("You have made a grave mistake little one...");
			break;
		}
		
		R.Current.ActiveWalkableArea = 0;
		yield return E.Break;
		
	}
}