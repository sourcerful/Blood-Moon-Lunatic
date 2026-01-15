using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class DialogChatWithElton : DialogTreeScript<DialogChatWithElton>
{
	public IEnumerator OnStart()
	{
		yield return C.Elton.Say("Moron, Lunatic, You killed my future bestseller");
		yield return C.Elton.Say("I know he was eccentric but he didn't deserve to die");
		yield return C.Elton.Say("I am gonna go bankrupt because of you");
		yield return C.Elton.Say("And you are going to be charged for murder");
		yield return E.Break;
	}

	public IEnumerator OnStop()
	{
		yield return E.Break;
	}

	IEnumerator Option1( IDialogOption option )
	{
		yield return C.Elton.Say("I am Elton, a book publisher from a town nearby");
		yield return C.Elton.Say("And you just killed my most promising author");
		yield return C.Elton.Say("He was supposed to make me filthy rich with his book, it was unlike anything else I have read");
		
		C.Elton.Description= "Elton";
		
		if(Option(2).Used){
			OptionOn(3);
			OptionOn(4);
		}
		yield return E.Break;
	}

	IEnumerator Option2( IDialogOption option )
	{
		yield return C.Elton.Say("I came over to help Charles with the final arrangements for the book");
		
		if(Option(1).Used){
			OptionOn(3);
			OptionOn(4);
		}
		yield return E.Break;
	}

	IEnumerator Option4( IDialogOption option )
	{
		yield return C.Elton.Say("What Kill list? The list of preorders?");
		yield return C.Elton.Say("Are you insane? Those people are ALIVE");
		yield return C.Elton.Say("They just paid in advance to receive an early copy of the book");
		
		if(Option(3).Used){
			OptionOn(5);
		}
		
		yield return E.Break;
	}

	IEnumerator Option3( IDialogOption option )
	{
		yield return C.Elton.Say("You live with him and you never heard of his book? The Blood Moon");
		yield return C.Elton.Say("It was supposed to be released tomorrow");
		yield return C.Elton.Say("I know he is a private guy, but I assumed he would at least tell his maid about the book he wrote");
		
		if(Option(4).Used){
			OptionOn(5);
		}
		
		yield return E.Break;
	}

	IEnumerator Option5( IDialogOption option )
	{
		D.ChatWithElton.Stop();
		
		yield return C.Luna.Say("The End");
		yield return E.Break;
	}
}