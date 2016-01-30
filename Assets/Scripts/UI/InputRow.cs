using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using Input = Assets.Scripts.Player.Input;

public class InputRow : MonoBehaviour
{
	public Row row;
	public UnityEvent onIncorrectInput;
	public string side = "Bad side/Player Input";

	void Start()
	{
		var inputGO = GameObject.Find(side);
		if (inputGO == null)
			Debug.LogWarning("Could not find " + side);

		var input = inputGO.GetComponent<Input>();
		input.OnKeyPressed.AddListener(ActivateButton);
	}

	public void ResetButtons()
	{
		foreach (var btn in row.buttons)
		{
			btn.buttonSelector.interactable = false; // Will cause transition animation.
		}
	}

	public void ActivateButton(int button, string input)
	{
		print("ActivateButton");
		Sprite s = ImageMap.instance.GetSprite(input);
		row.buttons[button].button.sprite = s;
		row.buttons[button].buttonSelector.interactable = true;
	}


}
