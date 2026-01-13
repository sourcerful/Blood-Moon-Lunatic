using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerTools;

namespace PowerTools.Quest
{

/// If you want to add your own functions/variables to PowerQuest stuff, add them here. 
/**
 * Variables added to non-component classes are automatically saved, and will show up in the "Data" of objects in the inspecor
 * Adding functions to the interfaces will make them accessable in QuestScript editor.
 * You can hook into game events using the "partial functions" (ones that start with 'Ex', eg ExOnMainLoop()). If you need more exposed, ask me (Dave), I'm just adding them as needed.
 * This file is just an example, you can move the partial classes elsewhere
 */

/// Functions/Properties added here are accessable from the 'E.' object in quest script
public partial interface IPowerQuest
{
	
}

public partial class PowerQuest
{
	/* Partial functions you can use here to extend functionality. If you need more hooks, Dave can add them
		// Called on Start, just before "OnGameStart" is called in global script
		partial void ExOnGameStart() {}
		partial void ExUpdate() {}
		// Called in the main blocking loop. After queued sequences are resumed, but before interactions are processed, etc.
		partial void ExOnMainLoop() {}
		partial void ExHandleSkipDialogKeyPressed() {}
		partial void ExBlock() {}
		partial void ExUnblock() {}
		partial void ExProcessClick(eQuestVerb verb, IQuestClickable clickable, Vector2 mousePosition, bool interactionFound) {}
		partial void ExOnEndCutscene();
	*/
}

/// Functions/Properties added here are accessable from the 'C.<characterName>.' object in quest script
public partial interface ICharacter
{
	/** Example: Adding health variable to characters /
	bool IsDead();
	float HealthPoints { get; set; }
	/**/
}

public partial class Character
{
	
	/* Partial functions you can use here to extend functionality
		void ExOnInteraction(eQuestVerb verb) {}
		void ExOnCancelInteraction(eQuestVerb verb) {}
	*/

	/** Example: Adding health to characters /
	[SerializeField] float m_healthPoints = 0;
	public bool IsDead() { return m_healthPoints <= 0; }
	public float HealthPoints { get { return m_healthPoints; } set { m_healthPoints = value; } }
	/**/
}

public partial class CharacterComponent
{
	/* Partial functions you can use here to extend functionality
	partial void ExAwake();
	partial void ExStart();
	partial void ExOnDestroy();
	partial void ExUpdate();
	*/
}

/// Functions/Properties added here are accessable from the 'R.<RoomName>.' object in quest script
public partial interface IRoom
{
}

public partial class Room
{
	/* Partial functions you can use here to extend functionality
		partial void ExAwake() {}
		partial void ExStart() {}
		partial void ExUpdate() {}
		// Called once room and everything in it has been created and PowerQuest has initialised references. After Start, Before OnEnterRoom.
		partial void ExOnLoadComplete(){}
	*/
}

/// Functions/Properties added here are accessable from the 'Props.<name>.' object in quest script
public partial interface IProp
{	
}

public partial class Prop
{
	/* Partial functions you can use here to extend functionality
	partial void ExOnInteraction(eQuestVerb verb) {}
	partial void ExOnCancelInteraction(eQuestVerb verb) {}
	*/
}

/// Functions/Properties added here are accessable from the 'Hotspots.<name>.' object in quest script
public partial interface IHotspot
{
}

public partial class Hotspot
{
	/* Partial functions you can use here to extend functionality
	void ExOnInteraction(eQuestVerb verb) {}
	void ExOnCancelInteraction(eQuestVerb verb) {}
	*/
}

/// Functions/Properties added here are accessable from the 'Regions.<name>.' object in quest script
public partial interface IRegion
{
}

public partial class Region
{
}

/// Functions/Properties added here are accessable from the 'I.<itemName>.' object in quest script
public partial interface IInventory
{
}

public partial class Inventory
{
	/* Partial functions you can use here to extend functionality
	void ExOnInteraction(eQuestVerb verb) {}
	void ExOnCancelInteraction(eQuestVerb verb) {}
	*/
}

// Gui and gui control Functions/Properties
public partial interface IGui
{
}

public partial class Gui
{
}

public partial class GuiControl
{
}

// Function/properties that all "clickables" share. 
public partial interface IQuestClickable
{
}


public partial class QuestSettings
{	
	/* Partial functions you can use here to extend functionality
	partial void ExOnInitialise(){}
	*/

	/* Example: how to add your own settings- in this case a "max framerate" setting
	public int m_targetFrameRate = -1;
	public int TargetFrameRate 
	{ 
		get => m_targetFrameRate; 
		set 
		{
			m_targetFrameRate = value;			
			Application.targetFrameRate = m_targetFrameRate;
		} 
	}

	// This is called when settings is initialised, or when settings are loaded from a file
	partial void ExOnInitialise()
	{		
		TargetFrameRate = m_targetFrameRate;
	}
	*/
}

/*
public partial class QuestControl
{
	// partial void ExStart(){}
	// partial void ExOnShow(){}
	// partial void ExOnHide(){}
	// partial void ExOnVisibilityChange(bool visible){}
}
*/

}
