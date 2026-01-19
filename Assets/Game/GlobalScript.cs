using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PowerScript;
using PowerTools.Quest;

///	Global Script: The home for your game specific logic
/**		
 * - The functions in this script are used in every room in your game.
 * - Add your own variables and functions in here and you can access them with `Globals.` (eg: `Globals.m_myCoolInteger`)
 * - If you've used Adventure Game Studio, this is equivalent to the Global Script in that
*/
public partial class GlobalScript : GlobalScriptBase<GlobalScript>
{	
	////////////////////////////////////////////////////////////////////////////////////
	// Global Game Variables
	
	/// Just an example of using an enum for game state.
	/// This can be accessed from other scripts, eg: `if ( E.Is(eProgress.DrankWater) )...`
	public enum eProgress
	{
		None,
		GotBottle,
		FilledBottle,
		Room2,
	};
	
	
	public HashSet<IProp> m_interacted_props = new HashSet<IProp>();
	public eProgress m_progressExample = eProgress.None;
	/// Just an example of using a global variable that can be accessed in any room with `Globals.m_spokeToBarney`.
	/// All variables like this in Quest Scripts are automatically saved
	public bool m_spokeToCharles = false;
	public bool m_workshop_pagesExplored = false;
	public bool m_charlesArrive = false;
	public bool m_hidden = false;
	public int m_interactionCounter = 0;
	public int m_stabCounter=0;
	
	////////////////////////////////////////////////////////////////////////////////////
	// Global Game Functions
	
	/// Called when game first starts
	public void OnGameStart()
	{     
	} 

	/// Called after restoring a game. Use this if you need to update any references based on saved data.
	public void OnPostRestore(int version)
	{
	}

	/// Blocking script called whenever you enter a room, before fading in. Non-blocking functions only
	public void OnEnterRoom()
	{
	}

	/// Blocking script called whenever you enter a room, after fade in is complete
	public IEnumerator OnEnterRoomAfterFade()
	{
		yield return E.Break;
	}

	/// Blocking script called whenever you exit a room, as it fades out
	public IEnumerator OnExitRoom( IRoom oldRoom, IRoom newRoom )
	{
		yield return E.Break;
	} 

	/// Blocking script called every frame when nothing's blocking, you can call blocking functions in here that you'd like to occur anywhere in the game
	public IEnumerator UpdateBlocking()
	{
		// Add anything that should happen every frame when nothing's blocking the script here.
		yield return E.Break;
	}

	/// Called every frame. Non-blocking functions only
	public void Update()
	{
		// Add anything that should happen every frame here.
	}	

	/// Called every frame, even when paused. Non-blocking functions only
	public void UpdateNoPause()
	{	
		// Add anything that should happen every frame, even when paused, here.
		
		// Update keyboard/mouse shortcuts
		UpdateInput();
			
	}
 	
	/// Update keyboard and mouse shortcuts
	void UpdateInput()
	{	
		// Add any custom keyboard/mouse shortcuts here
		
		// Set up a debug key
		bool debugKeyHeld = E.IsDebugBuild && (Input.GetKey(KeyCode.BackQuote) || Input.GetKey(KeyCode.Backslash));
		
		if ( E.Paused == false )
		{
			// Skip cutscene if escape key released. (done on release, so that it can also be used to skip dialog while down)
			if ( Input.GetKeyUp(KeyCode.Escape) )
				E.SkipCutscene();
		
			// Skip dialog buttons
			if ( Input.GetMouseButtonDown(0) )
				E.SkipDialog(true); // Skip dialog with left click (if it's been up for long enough)
			if ( Input.GetKey(KeyCode.Escape) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space) )
				E.SkipDialog(false); // Alternate skip buttons don't have the delay built in. Hold escape to skip through really quick
		}
		
		if ( E.GetBlocked() == false && E.Paused == false )
		{
			// Show menu gui
			if ( Input.GetKeyDown(KeyCode.F1) )
				G.Options.Show();
		
			// Quicksave
			if ( Input.GetKeyDown(KeyCode.F5) )
				E.Save(1, "Quicksave");
		
			// Quickload
			if (  Input.GetKeyDown(KeyCode.F7) )
				E.RestoreSave(1);
		
			// Restart
			if ( Input.GetKeyDown(KeyCode.F9) )
			{
				if ( debugKeyHeld ) // Holding ~ + F9 sets flag to restart at current room
					E.Restart( E.GetCurrentRoom(), E.GetCurrentRoom().Instance.m_debugStartFunction );
				else
					E.Restart();
			}
		}
		
		// Call through to gui system for keyboard navigation
		if ( Input.GetKey(KeyCode.UpArrow) )
			E.NavigateGui(eGuiNav.Up);
		if ( Input.GetKey(KeyCode.DownArrow) )
			E.NavigateGui(eGuiNav.Down);
		if ( Input.GetKey(KeyCode.RightArrow) )
			E.NavigateGui(eGuiNav.Right);
		if ( Input.GetKey(KeyCode.LeftArrow) )
			E.NavigateGui(eGuiNav.Left);
		
		if ( Input.GetKeyDown(KeyCode.Return) )
			E.NavigateGui(eGuiNav.Ok);
		if ( Input.GetKeyDown(KeyCode.Escape) )
			E.NavigateGui(eGuiNav.Cancel);
		
		
		// Debug keys
		if ( debugKeyHeld )
		{
			// Cheat to Give all items
			if ( Input.GetKeyDown(KeyCode.I) )
				PowerQuest.Get.GetInventoryItems_SaveFlagNotDirtied().ForEach(item=>item.Owned = true);
		
			// Cheats to speed up/slow down time
			if ( Input.GetKeyDown(KeyCode.PageDown) )
				Systems.Time.SetDebugTimeMultiplier( Systems.Time.GetDebugTimeMultiplier()*0.8f );
			if ( Input.GetKeyDown(KeyCode.PageUp) )
				Systems.Time.SetDebugTimeMultiplier( Systems.Time.GetDebugTimeMultiplier() + 0.2f );
			if ( Input.GetKeyDown(KeyCode.End) )
				Systems.Time.SetDebugTimeMultiplier( 1.0f );
		}
		
		// This one makes holding '.' while debugging speed the game up and skip over text.
		if ( E.IsDebugBuild && Input.GetKeyDown(KeyCode.Period) )
			Systems.Time.SetDebugTimeMultiplier(4);
		else if ( E.IsDebugBuild && Input.GetKeyUp(KeyCode.Period) )
			Systems.Time.SetDebugTimeMultiplier(1);
		if ( E.IsDebugBuild && Input.GetKey(KeyCode.Period) )
			E.SkipDialog(false);
		
	}

	/// Blocking script called whenever the player clicks anywwere. This function is called before any other click interaction. If this function blocks, it will stop any other interaction from happening.
	public IEnumerator OnAnyClick()
	{
		yield return E.Break;
	}

	/// Blocking script called whenever the player tries to walk somewhere. Even if `C.Player.Moveable` is set to false.
	public IEnumerator OnWalkTo()
	{
		yield return E.Break;
	}

	/// Called when the mouse is clicked in the game screen. Use this to customise your game interface by calling E.ProcessClick() with the verb that should be used. By default this is set up for a 2 click interface
	public void OnMouseClick( bool leftClick, bool rightClick )
	{
		bool mouseOverSomething = E.GetMouseOverClickable() != null;
		
		// Check if should clear inventory
		if ( C.Plr.HasActiveInventory && ( rightClick || (mouseOverSomething == false && leftClick ) || Cursor.NoneCursorActive ) )
		{
			// Clear inventory on Right click, or left click on empty space, or on hotspot with cursor set to "None"
			I.Active = null;
		}
		else if ( Cursor.NoneCursorActive ) // Checks if cursor is set to "None"
		{
			// Special case for clickables with cursor set to "None"- Don't do anything
		}
		else if ( E.GetMouseOverType() == eQuestClickableType.Gui )  // Checks if clicked on a gui
		{
			// Clicked on a gui - Don't do anything
		}
		else if ( leftClick ) // Checks if player left clicked
		{
			if ( mouseOverSomething ) // Check if they clicked on anything
			{
				if ( C.Plr.HasActiveInventory && Cursor.InventoryCursorOverridden == false )
				{
					// Left click with active inventory, use the inventory item
					E.ProcessClick( eQuestVerb.Inventory );
				}
				else if ( E.GetMouseOverType() == eQuestClickableType.Inventory )
				{
					// Left clicked on inventory item, make it the active item. Remove this "if statement" if you want to be able to "use" items by clicking on them
					I.Active = (IInventory)E.GetMouseOverClickable();
				}
				else
				{
					// Left click on item, so use it
					E.ProcessClick(eQuestVerb.Use);
				}
			}
			else  // They've clicked empty space
			{
				// Left click empty space, so walk
				E.ProcessClick( eQuestVerb.Walk );
			}
		}
		else if ( rightClick )
		{
			// If right clicked something, look at it (if 'look' enabled in PowerQuest Settings)
			if ( mouseOverSomething )
				E.ProcessClick( eQuestVerb.Look );
		}
	}

	////////////////////////////////////////////////////////////////////////////////////
	// Unhandled interactions

	/// Called when player interacted with something that had not specific "interact" script
	public IEnumerator UnhandledInteract(IQuestClickable mouseOver)
	{		
		// This function is called when the player interacts with something that doesn't have a response
		
		if ( mouseOver.ClickableType == eQuestClickableType.Inventory )
		{
			// If clicking an inventory item, select it as the active inventory
			E.ActiveInventory = (IInventory)mouseOver;
		}
		else
		{
			// This bit of logic cycles between three options. The '% 3' makes it cycle between 3 options.
			int option = E.Occurrence("unhandledInteract") % 3;
			if ( option == 0 )
				yield return C.Display("You can't use that");
			else if ( option == 1 )
				yield return C.Display("That doesn't work");
			else if ( option == 2 )
				yield return C.Display("Nothing happened");
		}
	}

	/// Called when player looked at something that had not specific "Look at" script
	public IEnumerator UnhandledLookAt(IQuestClickable mouseOver)
	{
		// This function is called when the player looks at something that doesn't have a response
		
		// In the title screen we don't want any response when looking at things, so we 'return' to stop the script
		if ( R.Current.ScriptName == "Title")
			yield break;
		
		// This bit of logic randomly chooses between three options
		int option = Random.Range(0,3);
		if ( option == 0 )
			yield return C.Display("It's nothing interesting");
		else if ( option == 1 )
			yield return C.Display("You don't see anything");
		else if ( option == 2 ) // in this one we do some fancy manipulation to include the name of what was clicked
			yield return C.Display($"The {mouseOver.Description.ToLower()} isn't very interesting");
	}

	/// Called when player used one inventory item on another that doesn't have a response
	public IEnumerator UnhandledUseInvInv(Inventory invA, Inventory invB)
	{
		// Called when player used one inventory item on another that doesn't have a response
		yield return C.Display( "You can't use those together" );
	}

	/// Called when player used inventory on something that didn't have a response
	public IEnumerator UnhandledUseInv(IQuestClickable mouseOver, Inventory item)
	{		
		// This function is called when the uses an item on things that don't have a response
		yield return C.Display( "You can't use that" ); 
	}


}
