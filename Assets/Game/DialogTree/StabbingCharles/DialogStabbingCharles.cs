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
				Audio.Play("Stab1");
				Camera.Shake(1, 0.5f);
				yield return C.Charles.Say("Ghk—!");
				option.Description = "Stab Kidneys";
				break;
			case 2:
				Audio.Play("Stab2");
				Camera.Shake(1, 0.5f);
				yield return C.Charles.Say("Ack... h-hah...");
				option.Description = "Stab Eyes";
				break;
			case 3:
				Audio.Play("Stab3");
				Camera.Shake(1, 0.5f);
				yield return C.Charles.Say("AGHHH-! MY EYES! I CAN'T—!");
				option.Description = "Stab Heart";
				break;
			case 4:
				Audio.Play("Stab2");
				Camera.Shake(1, 0.5f);
				yield return C.Charles.Say("...ghhh...");
				option.Description = "STAB HEART";
				break;
			case 5:
				Audio.Play("Stab1");
				Camera.Shake(1, 0.5f);
				option.Description = "STAB. HIS. HEART!";
				break;
			case 6:
				yield return C.Luna.Say("AGHHHH!!!!");
				Audio.Play("Stab3");
				Camera.Shake(1, 0.5f);
				Audio.StopMusic(2f);
				yield return E.WaitSkip();
				Audio.Play("Stab3");
				Camera.Shake(1, 0.5f);
				yield return E.WaitSkip();
				Audio.Play("Stab3");
				Camera.Shake(2, 1f);
				yield return E.Wait(2);
			yield return C.Display("A book falls from Charles's coat, it reads:\nThe Blood Moon - By Charles Smith");
			Audio.PlayMusic("relief",2f);
			yield return C.Plr.Say("I did it, He is finally dead...");
			yield return C.Plr.Say("The town is safe");
			yield return C.Plr.Say("I-I saved the town...");
			yield return E.WaitSkip();
			yield return C.Plr.Say("I am a HERO");
			yield return C.InnerThoughts.Say("He made citizens disappear for decades");
			yield return C.InnerThoughts.Say("Now that my lips aren't sealed, I will tell them everything");
			yield return C.InnerThoughts.Say("Maybe this way the families will find closure");
			yield return E.Wait(1f);
			yield return C.Plr.Say("*Sigh*");
			yield return C.Plr.Say("What a relief");
			yield return C.InnerThoughts.Say("After so many years of serving him");
			yield return C.InnerThoughts.Say("No more cleaning and mopping");
			yield return C.InnerThoughts.Say("no more watching, while he performs his habitual kill for blood");
			yield return C.InnerThoughts.Say("No more listening to his sadistic jabbering");
			yield return C.Plr.Say("I am FREE!");
			D.HittingCharles.Stop();
			C.Charles.Clickable = false;
			yield return E.Wait(1.5f);
		
			Region("Scale").Enabled = true;
			yield return C.Elton.ChangeRoom(R.Workshop);
			C.Elton.Enable();
			C.Elton.SetPosition(Point("EntryPoint"));
			yield return C.Elton.WalkTo(C.Elton.Position.x + 80, C.Elton.Position.y - 10);
			Audio.StopMusic(1f);
			Audio.Play("VinylStop");
			yield return C.Elton.Say("W-What have you done?!?");
			yield return C.Player.FaceLeft();
			yield return C.InnerThoughts.Say("Who's that?");
			break;
		}
		
		R.Current.ActiveWalkableArea = 0;
		yield return E.Break;
		
	}
}