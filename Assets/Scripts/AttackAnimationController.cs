using UnityEngine;
using System.Collections;
using DWMCGameLogicDtos;
using UnityEngine.Events;

public class AttackAnimationController : MonoBehaviour
{
	public string path;
	public UnityEvent onFire;
	public UnityEvent onHit;
	public float time = 1.5f;
	public GameObject projectile;
	GameObject instantiatedProj;

	[ContextMenu("Fire")]
	public void Fire()
	{
		onFire.Invoke();

		instantiatedProj = Instantiate(projectile) as GameObject;

		iTween.MoveTo(instantiatedProj, iTween.Hash("path", iTweenPath.GetPath(path), "time", time, "easetype", iTween.EaseType.easeInExpo));
		Invoke("OnHit", time);
	}

	void OnHit()
	{
		onHit.Invoke();
		Destroy(instantiatedProj);
	}
}
