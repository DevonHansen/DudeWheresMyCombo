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
			top.buttons[i].sprite = middle.buttons[i].sprite;
			top.buttons[i].color = middle.buttons[i].color;
			middle.buttons[i].sprite = bottom.buttons[i].sprite;
			middle.buttons[i].color = bottom.buttons[i].color;
		}
	}
}
