using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PowerTools.Quest;

namespace PowerScript
{	
	// Shortcut access to SystemAudio.Get
	public class Audio : SystemAudio
	{
	}

	public static partial class C
	{
		// Access to specific characters (Auto-generated)
		public static ICharacter Luna           { get { return PowerQuest.Get.GetCharacter("Luna"); } }
		public static ICharacter Charles         { get { return PowerQuest.Get.GetCharacter("Charles"); } }
		public static ICharacter InnerThoughts          { get { return PowerQuest.Get.GetCharacter("InnerThoughts"); } }
		public static ICharacter Test           { get { return PowerQuest.Get.GetCharacter("Test"); } }
		// #CHARS# - Do not edit this line, it's used by the system to insert characters
	}

	public static partial class I
	{		
		// Access to specific Inventory (Auto-generated)
		public static IInventory Bucket         { get { return PowerQuest.Get.GetInventory("Bucket"); } }
		// #INVENTORY# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	public static partial class G
	{
		// Access to specific gui (Auto-generated)
		public static IGui DialogTree     { get { return PowerQuest.Get.GetGui("DialogTree"); } }
		public static IGui SpeechBox      { get { return PowerQuest.Get.GetGui("SpeechBox"); } }
		public static IGui HoverText  { get { return PowerQuest.Get.GetGui("HoverText"); } }
		public static IGui DisplayBox    { get { return PowerQuest.Get.GetGui("DisplayBox"); } }
		public static IGui Prompt         { get { return PowerQuest.Get.GetGui("Prompt"); } }
		public static IGui Toolbar          { get { return PowerQuest.Get.GetGui("Toolbar"); } }
		public static IGui InventoryBar   { get { return PowerQuest.Get.GetGui("InventoryBar"); } }
		public static IGui Options        { get { return PowerQuest.Get.GetGui("Options"); } }
		public static IGui Save           { get { return PowerQuest.Get.GetGui("Save"); } }
		// #GUI# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	public static partial class R
	{
		// Access to specific room (Auto-generated)
		public static IRoom Title          { get { return PowerQuest.Get.GetRoom("Title"); } }
		public static IRoom Forest         { get { return PowerQuest.Get.GetRoom("Forest"); } }
		public static IRoom Bedroom        { get { return PowerQuest.Get.GetRoom("Bedroom"); } }
		public static IRoom WritingRoom    { get { return PowerQuest.Get.GetRoom("WritingRoom"); } }
		// #ROOM# - Do not edit this line, it's used by the system to insert rooms for easy access
	}

	// Dialog
	public static partial class D
	{
		// Access to specific dialog trees (Auto-generated)
		public static IDialogTree ChatWithBarney       { get { return PowerQuest.Get.GetDialogTree("ChatWithBarney"); } }
		public static IDialogTree ChatWithCharles      { get { return PowerQuest.Get.GetDialogTree("ChatWithCharles"); } }
		// #DIALOG# - Do not edit this line, it's used by the system to insert rooms for easy access	    	    
	}


}
