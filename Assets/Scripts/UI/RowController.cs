using UnityEngine;
using System.Collections;

public class RowController : MonoBehaviour
{
	public Row top;
	public Row middle;
	public Row bottom;

	public void SwitchRows()
	{
		// Copy middle to top and bottom to middle 
		for (int i = 0; i < 8; ++i)
		{
			top.buttons[i].button.sprite = middle.buttons[i].button.sprite;
			top.buttons[i].button.color = middle.buttons[i].button.color;
			middle.buttons[i].button.sprite = bottom.buttons[i].button.sprite;
			middle.buttons[i].button.color = bottom.buttons[i].button.color;
		}

		bottom.SendMessage("ResetButtons");
	}
}
