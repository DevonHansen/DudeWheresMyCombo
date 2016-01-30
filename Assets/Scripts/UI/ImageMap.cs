using UnityEngine;
using System.Collections;
using System.Linq;

public class ImageMap : MonoBehaviour
{
	[System.Serializable]
	public class MappedImage
	{
		public string inputName;
		public Sprite sprite;
	}

	public MappedImage[] images;

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
