using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsScreenActions_old : MonoBehaviour
{
/*	public BOXActions player;
	public GameObject settingsItem;
	
	private int settingsItemHeight = 40;
	private int settingsItemVerticalPosition = -40;
	

	public AudioClip[] GetAllClips()
	{
		GameObject[] soundtems = GameObject.FindGameObjectsWithTag("SettingsItem");
		//Debug.Log ("ProcessSettings, soundtems: "+soundtems.Length);
		
		int i=0;
		AudioClip[] allClips = new AudioClip[soundtems.Length];
		
		foreach (GameObject item in soundtems)
		{
			AudioSource music = item.GetComponent<AudioSource>();
			AudioClip clip = music.clip;
			
			if (null==clip) Debug.Log("SettingsScreenActions.ProcessSettings, clip "+i+" is null");
			else Debug.Log("SettingsScreenActions.ProcessSettings, clip "+i+" is NOT null");
			
			allClips[i] = clip;
			
			i+=1;
		}
		Debug.Log ("SettingsScreenActions.ProcessSettings, allClips.Length="+allClips.Length);
		return allClips;
	}


	public void AddItem()
	{
		Debug.Log ("SettingsScreenActions.AddItem(), settingsItemVerticalPosition: "+settingsItemVerticalPosition);
		
		GameObject item = Instantiate(
				settingsItem,
				new Vector3(0f,settingsItemVerticalPosition,0f),
				new Quaternion()
		) as GameObject;
		
		item.transform.SetParent(
			transform,
			false
		);

		settingsItemVerticalPosition -= settingsItemHeight;
		
	}*/
}
