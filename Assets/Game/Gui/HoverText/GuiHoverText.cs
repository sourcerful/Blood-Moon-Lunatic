using UnityEngine;
using System.Collections;
using PowerTools.Quest;
using PowerScript;
using static GlobalScript;

public class GuiHoverText : GuiScript<GuiHoverText>
{


	void Update()
	{
		Label("Text").Text= E.GetMouseOverDescription();
		
		Label("Text").Visible = !E.GetBlocked();
	}
}
