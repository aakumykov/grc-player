using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundStatus : MonoBehaviour {

	public Sprite inactiveIcon;
	public Sprite waitIcon;
	public Sprite readyIcon;

	private Image image;

	void Awake()
	{
		image = GetComponent<Image>();
	}

	public void SetStatus(string mode="")
	{
		Debug.Log ("SoundStatus.SetStatus('"+mode+"')");
		if ("wait"==mode) image.sprite = waitIcon;
		else if ("ready"==mode) image.sprite = readyIcon;
		else image.sprite = inactiveIcon;
	}


}
