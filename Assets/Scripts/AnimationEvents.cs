using UnityEngine;
using System.Collections;

public class AnimationEvents : MonoBehaviour
{
	public AttackAnimationController lightAttack;

	public void DoLightAttack()
	{
		lightAttack.Fire();
	}

	public void PlayAudio(AudioClip clip)
	{
		print("Play audio " + clip.name);
	}
}

