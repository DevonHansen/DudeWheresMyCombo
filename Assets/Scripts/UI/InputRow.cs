using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputRow : MonoBehaviour
{
	public Row row;
	public UnityEvent onIncorrectInput;

	public void ResetButtons()
	{
		foreach (var btn in row.buttons)
		{
			btn.buttonSelector.interactable = false; // Will cause transition animation.
		}
	}

	public void ActivateButton(string input, int button)
	{
		Sprite s = ImageMap.instance.GetSprite(input);
		row.buttons[button].button.sprite = s;
		row.buttons[button].buttonSelector.interactable = true;
	}
}
