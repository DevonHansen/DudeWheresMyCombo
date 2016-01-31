using UnityEngine;
using System.Collections;
using DWMCGameLogicDtos;
using JetBrains.Annotations;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public float delayBeforeDamage = 2;
	public Slider slider;
	public float animationTime = 1;
	public UnityEvent onDeath;
	public string side = "Bad side/Player Input";

	void Start()
	{
		var inputGO = GameObject.Find(side);
		if (inputGO == null)
			Debug.LogWarning("Could not find " + side);

		var input = inputGO.GetComponent<Input>();
	}

	public void OnAttack(Attack atk)
	{
		if(atk.Value > 0)
			StartCoroutine(DoAttack(atk));
	}

	public IEnumerator DoAttack(Attack atk)
	{
		yield return new WaitForSeconds(delayBeforeDamage);

		float dmg = 10f / (float)atk.Value;
		float healthAfterHit = slider.value - dmg;

		while (slider.value > healthAfterHit)
		{
			Mathf.MoveTowards(slider.value, healthAfterHit, Time.deltaTime * dmg);
			yield return 0;
		}

		if(healthAfterHit <= 0)
			onDeath.Invoke();
	}
}
