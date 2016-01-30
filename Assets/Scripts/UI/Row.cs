using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Row : MonoBehaviour
{
	//[HideInInspector]
	public List<Button> buttons;

	void Awake()
	{
		buttons = GetComponentsInChildren<Button>().ToList();
		foreach (var btn in buttons)
		{
			btn.buttonSelector.interactable = false;
		}
	}
}
