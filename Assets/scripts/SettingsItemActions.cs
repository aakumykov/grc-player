using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsItemActions : MonoBehaviour {

	public Playlist playlist;
	public GameObject soundStatus;
	public InputField soundPath;
	public Button soundSelectButtton;
	
	private AudioClip clip;
	private WWW w;
	public float fileLoadWaitStep = 0.1f;
	
	void Awake()
	{
		//Debug.Log ("SettingsItemActions.Awake()");
	}
	
	public void ChooseFile()
	{
		Debug.Log("SettingsItemActions.ChooseFile(): BEGIN");
		
		string fileName = soundPath.GetComponentInChildren<Text>().text;
		StartCoroutine( LoadSound(fileName) );
		
		Debug.Log("SettingsItemActions.ChooseFile(): END");
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
		
		clip = w.audioClip;
		
		playlist.Add (fileName,clip);
	}
}
