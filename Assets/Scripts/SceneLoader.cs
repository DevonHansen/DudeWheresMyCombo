using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public string[] scenes;

	void Start()
	{
		foreach (var scn in scenes)
		{
			SceneManager.LoadScene(scn);
		}
	}

}
