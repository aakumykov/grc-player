using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaylistItemActions : MonoBehaviour {

	public Playlist playlist;
	public GameObject soundStatus;
	public InputField soundPath;
	public Button soundSelectButtton;
	
	private AudioClip clip;
	private WWW w;
	private float fileLoadTime = 0f;
	private float fileLoadTimeStep = 0.1f;
	
	void Awake()
	{
		//Debug.Log ("SettingsItemActions.Awake()");
	}
	
	public void ChooseFile()
	{
		//Debug.Log("SettingsItemActions.ChooseFile(): BEGIN");
		
		string fileName = soundPath.GetComponentInChildren<Text>().text;
		StartCoroutine( LoadSound(fileName) );
		
		//Debug.Log("SettingsItemActions.ChooseFile(): END");
	}
	
	
	IEnumerator LoadSound(string fileName)
	{
		Debug.Log("LoadSound('"+fileName+"')");
		
		w = new WWW(fileName);
		while (!w.isDone)
		{
			fileLoadTime += fileLoadTimeStep;
			//Debug.Log("LoadSound: still loading '"+fileName+"'");
			yield return new WaitForSeconds(fileLoadTimeStep);
		}
		Debug.Log("LoadSound: LOAD COMPLETE '"+fileName+"', "+fileLoadTime+" sec ");
		
		clip = w.audioClip;
		
		playlist.Add (fileName,clip);
	}
}
