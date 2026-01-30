using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class DialogHittingCharles : DialogTreeScript<DialogHittingCharles>
{
	
	
	public IEnumerator OnStart()
	{
		yield return E.Break;
	}

	public IEnumerator OnStop()
	{
		R.Current.ActiveWalkableArea = 1;
		yield return E.Break;
	}

	IEnumerator Option1(IDialogOption option)
	{
		Vector2 luna_attack_pos = C.Plr.Position;
		Vector2 slow_walk_speed = new Vector2(20,20);
		
		C.Plr.WalkSpeed = slow_walk_speed;
		Audio.PlayMusic("Climax",2f);
		yield return C.Plr.WalkTo(luna_attack_pos.x, luna_attack_pos.y + 20);
		C.Plr.ResetWalkSpeed();
		yield return C.Display("Luna lifts the bottle and hits Charles on his head");
		yield return C.Display("The glass shatters against his skull... he's dazed!");
		
		
		C.Charles.Animation = "FallR";
		C.Charles.SetPosition(C.Charles.Position.x, C.Charles.Position.y - 30);
		yield return C.Charles.Say("Eahhhhhhhhhhhhhhhhhhhhhh");
		yield return C.Display("Your bottle has been broken, you got a broken bottle!");
		yield return C.Display("You are now able to stab Charles");
		
		C.Charles.LookAtPoint = C.Player.Position;
		C.Plr.RemoveInventory(I.FullBottle);
		C.Plr.AddInventory(I.BrokenBottle);
		
		C.Charles.Cursor = "BrokenBottle";
		Stop();
		yield return E.Break;
	}
}