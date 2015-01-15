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
			ChangeIcon("pause");
			animated = false;
		}
		else
		{
			ChangeIcon("play");
			AnimatePause();
		}
	}

	private void ChangeIcon(string mode)
	{
		Debug.Log ("PlayPauseButtonActions.ChangeIcon('"+mode+"')");
		switch (mode)
		{
			case "play":
				label.text = ">";
				break;
			
			case "pause":
				label.text = "||";
				animated = false;
				break;
			
			default:
				Debug.Log ("PlayPauseButtonActions.ChangeIcon(): unknown mode '"+mode+"'");
				break;
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
