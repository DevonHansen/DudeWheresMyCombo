using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputRow : Row
{
	public Selectable[] buttonSelectors;

	void Awake()
	{
		buttonSelectors = new Selectable[buttons.Count];
		for (int i = 0; i < buttons.Count; ++i)
		{
			var selector = buttons[i].GetComponent<Selectable>();
			if(selector == null)
				Debug.LogWarning(buttons[i].name + " missing selector", buttons[i].gameObject);

			buttonSelectors[i] = selector;
		}
	}

	public void ResetButtons()
	{
		foreach (var btn in buttons)
		{
			
		}
	}
}
