using UnityEngine;
using System.Collections;
using DWMCGameLogicDtos;
using UnityEngine.Events;
using UnityEngine.UI;
using Input = Assets.Scripts.Player.Input;

public class InputRow : MonoBehaviour
{
	public Row row;
	public UnityEvent onIncorrectInput;
	public string side = "Bad side/Player Input";
	public UnityEvent onAttack;
	public Sprite blank;
	public Color goodColor = Color.blue;
	public Color badColor = Color.black;

	void Start()
	{
		var inputGO = GameObject.Find(side);
		if (inputGO == null)
			Debug.LogWarning("Could not find " + side);

		var input = inputGO.GetComponent<Input>();
		input.OnKeyPressed.AddListener(ActivateButton);
		input.OnAttack.AddListener(DoAttack);
	}

	public void ResetButtons()
	{
		foreach (var btn in row.buttons)
		{
			btn.button.sprite = blank;
			btn.border.color = Color.white;
			btn.buttonSelector.interactable = true;
		}
		index = 0;

	}

	int index = 0;
	public void ActivateButton(int button, string input)
	{
		print("ActivateButton " + index + "-" + input);
		Sprite s = ImageMap.instance.GetSprite(input);
		row.buttons[index].button.sprite = s;
		index++;
	}

	public void DoAttack(Attack atk)
	{
		print("Attack " + atk.Value);
		for (int i = 0; i < atk.Value; ++i)
		{
			row.buttons[i].border.color = goodColor;
		}

		for (int i = atk.Value; i < row.buttons.Count; ++i)
		{
			row.buttons[i].border.color = badColor;
		}
		
		onAttack.Invoke();
	}
}
