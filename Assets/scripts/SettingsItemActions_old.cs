using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsItemActions_old : MonoBehaviour {

/*	public BOXActions player;
	//public SoundStatusActions soundStatus;
	//public SoundPathActions soundPath;
	public float fileLoadWaitStep = 0.1f;
	
	private AudioSource song;
	private WWW w;
	
	void Start()
	{
		song = GetComponent<AudioSource>();
		song.panLevel = 0f;
	}
	
	
	public void ChooseFile()
	{
		//Debug.Log("ChooseFile: BEGIN");

		//string fileName = soundPath.GetName();

		StartCoroutine( LoadSound(fileName) );
		
		//Debug.Log("ChooseFile: END");
	}
	
	
	IEnumerator LoadSound(string fileName)
	{
		Debug.Log("LoadSound('"+fileName+"')");
		
		w = new WWW(fileName);
		while (!w.isDone)
		{
			Debug.Log("LoadSound: still loading '"+fileName+"'");
			yield return new WaitForSeconds(fileLoadWaitStep);
		}
		Debug.Log("LoadSound: LOAD COMPLETE '"+fileName+"' ");
		
		song.clip = w.audioClip;
		
		player.AddSong(fileName,w.audioClip);
	}
	
	*/
}
