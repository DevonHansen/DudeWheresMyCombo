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
			top.button[i].sprite = middle.button[i].sprite;
			top.button[i].color = middle.button[i].color;
			middle.button[i].sprite = bottom.button[i].sprite;
			middle.button[i].color = bottom.button[i].color;
		}
	}
}
