using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayPauseButtonActions : MonoBehaviour {
	
/*	private Text label;
	private bool animated = false;
	public float animationPeriod = 0.5f;

	void Start ()
	{
		label = GetComponentInChildren<Text> ();
	}

	public void ChangeIcon(string mode)
	{
		Debug.Log ("ToggleIcon");

		if ("play"==mode)
		{	
			label.text = ">";
			animated = false;
		}
		else if ("pause"==mode)
		{
			label.text = "||";
			animated = false;
		}
		else
		{
			Debug.Log ("ChangeIcon, invalid mode '" + mode + "'");
		}
	}

	public void AnimatePause()
	{
		Debug.Log ("AnimatePause");
		animated = true;
		StartCoroutine ("AnimatePause_Start");
	}

	IEnumerator AnimatePause_Start()
	{
		Debug.Log ("AnimatePause_Start, "+label.text);

		if (animationPeriod <= 0) animationPeriod = 0.5f;

		while (animated)
		{
			if ("||"==label.text) label.text = ">";
			else label.text = "||";
			yield return new WaitForSeconds(animationPeriod);
		}
	}*/
}
