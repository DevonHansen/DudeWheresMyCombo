using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputRow : MonoBehaviour
{
	public Row row;
	Selectable[] buttonSelectors;

	public UnityEvent onIncorrectInput;

	void Awake()
	{
		buttonSelectors = new Selectable[row.buttons.Count];
		for (int i = 0; i < row.buttons.Count; ++i)
		{
			var selector = row.buttons[i].GetComponent<Selectable>();
			if(selector == null)
				Debug.LogWarning(row.buttons[i].name + " missing selector", row.buttons[i].gameObject);

			buttonSelectors[i] = selector;
		}
	}

	public void ResetButtons()
	{
	}
}
