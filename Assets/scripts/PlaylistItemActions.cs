using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaylistItemActions : MonoBehaviour {

	public Playlist playlist;
	public FileBrowser fileBrowser;

	public GameObject soundStatus;
	public InputField soundPath;
	public Button soundSelectButtton;
	
	private AudioClip clip;
	private WWW w;
	private float fileLoadTime = 0f;
	private float fileLoadTimeStep = 0.1f;
	
	void Awake()
	{
		//Debug.Log ("PlaylistItemActions.Awake()");
	}
	
	public void ChooseFile()
	{
		//Debug.Log("PlaylistItemActions.ChooseFile(): BEGIN");
		
		string fileName = soundPath.GetComponentInChildren<Text>().text;
		//StartCoroutine( LoadSound(fileName) );

		StartCoroutine (PickFile ());
		
		//Debug.Log("PlaylistItemActions.ChooseFile(): END");
	}


	IEnumerator PickFile()
	{
		Debug.Log("PlaylistItemActions.PickFile()");

		while ( ! fileBrowser.IsDone() )
		{
			Debug.Log("file not selected yet");
			yield return new WaitForSeconds(1);
		}
		Debug.Log("FILE IS SELECTED !");
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
