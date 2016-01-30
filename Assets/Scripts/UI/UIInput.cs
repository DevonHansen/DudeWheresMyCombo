using UnityEngine;
using System.Collections;
using System.Text;
using Assets.Scripts;

public class UIInput : MonoBehaviour
{
	public string playerInput;
	
	void Start ()
	{
		var plyInput = GameObject.Find(playerInput);
		if (plyInput == null)
		{
			Debug.LogWarning("Could not find " + playerInput) ;
		}
		else
		{
			var input = plyInput.GetComponent<PlayerComponent>();
			input.
		}
	}
	
}
