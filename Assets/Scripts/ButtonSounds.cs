using UnityEngine;
using System.Collections;

public class ButtonSounds : MonoBehaviour
{
	public AudioClip[] clips;

	int current = 0;

	public void Reset()
	{
		current = 0;
	}

	public void DoButton()
	{ 
		AudioSource.PlayClipAtPoint(clips[current++], new Vector3(3, 5, -10), 10);
		if (current > 7)
			current = 7;
	}
}
