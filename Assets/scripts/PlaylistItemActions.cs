using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaylistItemActions : MonoBehaviour {

	public PlaylistScreenActions playlistScreen;
	public FileBrowser fileBrowser;

	public GameObject soundStatus;
	public InputField soundPath;
	public Button soundSelectButtton;

	public Playlist playlist;

	private string filePath;
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
		Debug.Log("PlaylistItemActions.ChooseFile()");
		
		//string fileName = soundPath.GetComponentInChildren<Text>().text;
		//StartCoroutine( LoadSound(fileName) );

		StartCoroutine (ChooseFileStart ());
	}


	IEnumerator ChooseFileStart()
	{
		Debug.Log("PlaylistItemActions.ChooseFileStart()");

		fileBrowser.Appear ();

		while ( ! fileBrowser.IsDone() )
		{
			Debug.Log("ChooseFileStart(): file not selected yet");
			yield return new WaitForSeconds(1);
		}
		Debug.Log("ChooseFileStart(): FILE IS SELECTED !");

		filePath = fileBrowser.File ();
		Debug.Log ("ChooseFileStart(), filePath: " + filePath);

		playlistScreen.Appear ();
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
