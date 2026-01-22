using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class RoomBedroom : RoomScript<RoomBedroom>
{
    // This area is where you can put variables you want to use for game logic in your room

    // Here's an example variable, an integer which is used when clicking the sky.
    // The 'm_' at the start is just a naming convention so you can tell it's not just a 'local' variable
    int m_timesClickedSky = 0;

    // enums like this are a nice way of keeping track of what's happened in a room. eg. `E.Set(eThingsYouveDone.LoadedCrossbow)` or `if (E.At(eThingsYouveDone.Start) )...`
    public enum eThingsYouveDone { Start, InsultedChimp, EatenSandwich, LoadedCrossbow, AttackedFlyingNun, PhonedAlbatross }
    public eThingsYouveDone m_thingsDone = eThingsYouveDone.Start;

    public void OnEnterRoom()
    {
		// Put things here that you need to set up BEFORE the room fades in (but nothing "blocking")
		// Note, you can also just do this at the top of OnEnterRoomAfterFade
		
		//C.Charles.SetPosition(Point("WorkshopDoor"), eFace.DownLeft);
 }

    public IEnumerator OnEnterRoomAfterFade()
    {
		// Put things here that happen when you enter a room
		
		//if ( FirstTimeVisited && EnteredFromEditor == false ) // Only run this part the first time you visit, and not when debugging
		//{
		//Audio.PlayMusic("MusicExample");
		//}
		Debug.Log(Globals.m_progressExample);
		if (Globals.m_progressExample != eProgress.Room2)
		{
			E.StartCutscene();
			yield return E.Wait();
			yield return C.Plr.WalkTo((Prop("Bed")));
			yield return C.Player.Face(Prop("Bed"));
			yield return E.Wait(((float)1.5));
			yield return C.Charles.WalkTo(Point("WorkshopDoor"));
			yield return E.WaitSkip();
			yield return C.Charles.Say("Luna, come now.");
			yield return C.Charles.FaceLeft();
			yield return E.Wait(1);
			yield return C.InnerThoughts.Say("I must speak to Lord Charles or I will suffer the consequences...");
			//Audio.PlayMusic("MusicExample");
			yield return C.Player.WalkTo(Point("CharlesDialog"));
			yield return C.Charles.Face(C.Luna);
			yield return C.Plr.Face(C.Charles);
			yield return C.Luna.Say("Yes my lord?");
			E.EndCutscene();
		}
		yield return E.Break;
		
 }

    public IEnumerator OnInteractHotspotForest(Hotspot hotspot)
    {
        // Here the player just walks to where the mouse is, rather than a particular walk-to point
        yield return C.Plr.WalkTo(E.GetMousePosition());
        yield return C.Plr.FaceUp();

        yield return C.Plr.Say("Feels impenetrable");

        // Use to quickly check if something's been done before. See also E.FirstOccurrence(...)
        // The string "useForest" can be anything you want, as long as it's unique the the "occurrence'
        if (E.Occurrence("useForest") == 2)
        {
            yield return C.Plr.Say("Same as it did the last two times");
        }

        yield return E.Break;

    }

    public IEnumerator OnInteractPropKeg(Prop prop)
    {
        yield return C.WalkToClicked();
        yield return C.FaceClicked();

        yield return C.InnerThoughts.Say("T-This keg is filled with blood...");
        yield return C.InnerThoughts.Say("I wonder how many he has killed to fill it up...");

        yield return E.Break;

    }

    public IEnumerator OnInteractHotspotWorkshopDoor(Hotspot hotspot)
    {
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		if (I.Key.Owned)
		{
			yield return C.InnerThoughts.Say("It fits");
			yield return E.Wait(1);
			yield return C.Display("*Click*");
			//C.Plr.ChangeRoom(R.Workshop);
			yield return R.Workshop.Enter();
		}
		else
		{
			yield return E.WaitSkip();
			yield return C.InnerThoughts.Say("Lord Charles' Workshop...");
			yield return C.InnerThoughts.Say("I never dared to set foot in there...");
			yield return C.InnerThoughts.Say("Maybe I will find a way to stop him in there");
			yield return C.Luna.FaceDown();
			yield return E.WaitSkip();
			yield return C.InnerThoughts.Say("It's locked");
			yield return C.InnerThoughts.Say("His spare key must be somewhere in here");
		}
		yield return E.Break;
		
 }


    public IEnumerator OnInteractPropBucket(Prop prop)
    {
        yield return C.WalkToClicked();
        yield return C.FaceClicked();
        yield return C.InnerThoughts.Say("What is this empty bottle doing here?");
        Audio.Play("Bucket");
        prop.Disable();
        I.EmptyBottle.AddAsActive();
        yield return E.WaitSkip();
        yield return C.Plr.FaceDown();
        yield return E.WaitSkip();
        yield return C.Display("Access your Inventory from the top of the screen");

        yield return E.Break;

    }

    public IEnumerator OnUseInvPropKeg(Prop prop, Inventory item)
    {
        // NB: You need to check they used the correct item!
        if (item == I.EmptyBottle && Globals.m_progressExample == eProgress.GotBottle)
        {
            yield return C.WalkToClicked();
            yield return C.FaceClicked();
            yield return C.InnerThoughts.Say("I hope it's a good idea");
            yield return C.Display("Luna lowers the bottle down, and fills it with fresh blood from the keg");
            Globals.m_progressExample = eProgress.FilledBottle;
            yield return E.Wait(1);
            yield return C.Luna.Say("God, please have mercy on those poor souls");
            I.EmptyBottle.Remove();
            I.FullBottle.AddAsActive();
            yield return E.WaitSkip();
            yield return C.Plr.FaceDown();
            yield return E.WaitSkip();
        }
        if (item == I.FullBottle)
        {
            yield return C.InnerThoughts.Say("I already filled the bottle");
        }
        yield return E.Break;

    }

    public IEnumerator OnInteractHotspotSky(Hotspot hotspot)
    {
        // Increment the room's variable
        m_timesClickedSky++;
        // Show some text including the variable. Use {braces} to include variables in text
        yield return C.Display($"You've clicked the sky {m_timesClickedSky} times");

    }


    public IEnumerator OnLookAtHotspotForest(IHotspot hotspot)
    {
        yield return C.Plr.FaceUp();

        // YOu can use FirstLook, FirstUse, LookCount, and UseCount to change what happens on subsequent clicks
        if (hotspot.FirstLook)
            yield return C.Plr.Say("Looks impenetrable");
        else
            yield return C.Plr.Say("Still looks impenetrable");
        yield return E.Break;
    }

    public IEnumerator OnEnterRegionCorner(IRegion region, ICharacter character)
    {
        // Here the player has entered a region. Regions can also just be used to scale or tint the character

        yield return E.WaitSkip();
        C.Plr.StopWalking();
        yield return E.WaitSkip();
        yield return C.Plr.FaceDown();
        yield return E.WaitSkip();
        yield return C.Plr.Say("This corner gives me the heebie jeebies");
        yield return E.WaitSkip(0.25f);
        yield return C.Charles.Face(C.Plr);
        yield return C.Charles.Say("Yeah, stay away from that corner dude, it has a Tint colour.");
        yield return E.WaitSkip(0.25f);
        yield return C.Plr.FaceUp();
        yield return C.Plr.Say("Good idea, Let's set it's Walkable property to false so I'll never make the same mistake again");
        yield return C.Plr.WalkTo(124, -67);

        // Setting a region's Walkable" as false will stop the player walking there
        Region("Corner").Walkable = false;
    }

    public IEnumerator OnLookAtPropKeg(IProp prop)
    {
        yield return C.FaceClicked();
        yield return C.InnerThoughts.Say("Why does he have a keg in his room?");
        yield return E.Break;
    }


    IEnumerator OnInteractCharacterCharles(ICharacter character)
    {
		// You can add character interactions like this one to a room script
		
		// In that room, clicking the character will call the room script first
		// If the room script doesn't do anything, it will fall back to the Charcter Script
		
		// In this case you're haven't 'EatenSandwich', so nothing happens here,
		// and the OnInteract function in Barney's main script will be called instead
		D.ChatWithCharles.Start();
		yield return E.Break;
		
 }

    IEnumerator OnUseInvPropBucket(IProp prop, IInventory item)
    {

        yield return E.Break;
    }

    IEnumerator OnLookAtPropBucket(IProp prop)
    {

        yield return E.Break;
    }

    IEnumerator OnLookAtPropBed(IProp prop)
    {

		yield return C.InnerThoughts.Say("Lord Charles' bed");
		yield return E.Break;
 }

    IEnumerator OnInteractPropBed(IProp prop)
    {
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.Display("You searched the bed, then cleaned it.");
		yield return C.Display("Under the blanket, you found an empty wine bottle.");
		Prop("Bed").Animation = "Bed";
		Prop("EmptyBottle").Visible = true;
		yield return E.Break;
		
 }

    IEnumerator OnInteractPropDresser(IProp prop)
    {
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.InnerThoughts.Say("It has an empty chalice on top");
		yield return C.InnerThoughts.Say("It's stuck to the dresser");
		yield return C.InnerThoughts.Say("The top drawer is locked");
		yield return E.Break;
		
 }

    IEnumerator OnLookAtPropDresser(IProp prop)
    {
		yield return C.InnerThoughts.Say("The drawer has an empty chalice on top");
		yield return E.Break;
		
 }

    IEnumerator OnLookAtPropEmptyBottle(IProp prop)
    {

		yield return C.InnerThoughts.Say("What is this empty bottle doing here?");
		yield return E.Break;
 }

    IEnumerator OnInteractPropEmptyBottle(IProp prop)
    {
		yield return C.WalkToClicked();
		yield return C.FaceClicked();
		yield return C.InnerThoughts.Say("What is this empty bottle doing here?");
		Audio.Play("Bucket");
		prop.Disable();
		I.EmptyBottle.AddAsActive();
		yield return E.WaitSkip();
		yield return C.Plr.FaceDown();
		yield return E.WaitSkip();
		Globals.m_progressExample = eProgress.GotBottle;
		yield return C.Display("Access your Inventory from the top of the screen");
		
		yield return E.Break;
 }

    IEnumerator OnUseInvPropDresser(IProp prop, IInventory item)
    {
        // NB: You need to check they used the correct item!
        if (item == I.FullBottle && Globals.m_progressExample == eProgress.FilledBottle)
        {
            yield return C.WalkToClicked();
            yield return C.FaceClicked();
            yield return C.InnerThoughts.Say("I hope it's a good idea");
            yield return C.Display("You fill the chalice with blood...");
            Globals.m_progressExample = eProgress.Room2;
            yield return E.Wait(1);
            yield return C.Display("*Click*");
            yield return C.InnerThoughts.Say("It actually worked, the spare key was in here");
            yield return C.InnerThoughts.Say("I can now access the workshop");
            I.Key.Add();
            yield return E.WaitSkip();
            yield return C.Luna.FaceDown();
            yield return E.WaitSkip();
        }
        else
        {
            if (item == I.FullBottle)
            {
                yield return C.InnerThoughts.Say("I got the key, I should enter the workshop");
            }
        }
        yield return E.Break;

    }

    IEnumerator OnUseInvPropEmptyBottle(IProp prop, IInventory item)
    {

        yield return E.Break;
    }

    IEnumerator OnUseInvHotspotWorkshopDoor(IHotspot hotspot, IInventory item)
    {
        yield return E.Break;
    }

	IEnumerator OnLookAtHotspotSky( IHotspot hotspot )
	{

		yield return E.Break;
	}

	IEnumerator OnEnterRegionScale( IRegion region, ICharacter character )
	{

		yield return E.Break;
	}

	void OnEnterRegionBGScale( IRegion region, ICharacter character )
	{
	}

	IEnumerator OnExitRegionScale( IRegion region, ICharacter character )
	{

		yield return E.Break;
	}

	void OnExitRegionBGScale( IRegion region, ICharacter character )
	{
	}

	IEnumerator OnEnterRegionTriggerDialog( IRegion region, ICharacter character )
	{
		Region("TriggerDialog").Enabled = false;
		D.ChatWithCharles.Start();
		yield return E.Break;
	}
}
