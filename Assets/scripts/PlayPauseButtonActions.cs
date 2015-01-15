using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayPauseButtonActions : MonoBehaviour {
	
	public Player player;
	public float animationPeriod = 0.5f;
	
	private Text label;
	private bool animated = false;

	void Start ()
	{
		label = GetComponentInChildren<Text> ();
	}

	public void ToggleIcon()
	{
		Debug.Log ("PlayPauseButtonActions.ToggleIcon()");

		if (player.Played())
		{	
			label.text = ">";
			animated = false;
		}
		else
		{
			label.text = "||";
			animated = false;
			AnimatePause();
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
	}
}
