using UnityEngine;
using System.Collections;
using System.Linq;

public class ImageMap : MonoBehaviour
{
	public static ImageMap instance
	{
		get
		{
			if (_instance == null)
				_instance = FindObjectOfType<ImageMap>();
			return _instance;
		}
	}
	static ImageMap _instance;

	[System.Serializable]
	public class MappedImage
	{
		public string inputName;
		public Sprite sprite;
	}

	public MappedImage[] images;

	void Awake()
	{
		if (_instance != null)
		{
			Debug.LogWarning("Too many image maps found. This is a singleton");
			Destroy(this);
		}
		else
			_instance = this;
	}

	public Sprite GetSprite(string input)
	{
		var result = images.First(o => o.inputName == input);
		if (result != null)
		{
			return result.sprite;
		}
		else
		{
			Debug.LogWarning("Could not find input: " + input);
			return null;
		}
	}
}
