using UnityEngine;
using System.Collections;

public class BOXActions : MonoBehaviour {

	public Canvas musicScreen;
	public Canvas playlistScreen;
	
	void Awake()
	{
		ChangeScreen ("playlist");
	}
	
	public void ChangeScreen(string name)
	{
		Debug.Log ("BOXActions.ChangeScreen('"+name+"')");
		switch (name)
		{
			case "playlist":
				musicScreen.enabled = false;
				playlistScreen.enabled = true;
				break;
			default:
				musicScreen.enabled = true;
				playlistScreen.enabled = false;
				break;
		}
	}
}
