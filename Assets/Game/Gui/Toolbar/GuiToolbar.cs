using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class GuiToolbar : GuiScript<GuiToolbar>
{
	
	IEnumerator OnAnyClick( IGuiControl control )
	{

		yield return E.Break;
	}

	void Update()
	{
	}


	void OnPostRestore( int version )
	{	
	}


	void OnShow()
	{
		// Disable 'save' button in title screen
		if ( R.Current != null && R.Current.ScriptName.Contains("Title") )
			Button("Save").Clickable = false;
		else
			Button("Save").Clickable = true;
	}

	IEnumerator OnClickQuit( IGuiControl control )
	{
		
		GuiPrompt.Script.Show("Really Save and Quit?", "Yes", "Cancel", ()=>
		{
			if ( R.Current != R.Title )
				E.Save(1,"Autosave");
		
			Application.Quit();
		});
		yield return E.Break;
	}

	IEnumerator OnClickOptions( IGuiControl control )
	{
		G.Options.Show();
		yield return E.Break;
	}

	IEnumerator OnClickSave( IGuiControl control )
	{
		GuiSave.Script.ShowSave();
		yield return E.Break;
	}

	IEnumerator OnClickRestore( IGuiControl control )
	{
		GuiSave.Script.ShowRestore();
		yield return E.Break;
	}
}
