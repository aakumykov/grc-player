using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class PlaylistItemActions : MonoBehaviour {

	public PlaylistScreenActions playlistScreen;
	public FileBrowser fileBrowser;
	public SoundStatus soundStatus;

	public InputField soundPath;
	public Button soundSelectButtton;

	public Playlist playlist;

	private string filePath;
	private AudioClip clip;
	private WWW w;
	private float fileLoadTime = 0f;
	private float fileLoadTimeStep = 0.1f;
	
	void Start()
	{
		//Debug.Log ("@@@@@@@@@@@@@@ PlaylistItemActions.Start() @@@@@@@@@@@@@@@");
		soundStatus.SetStatus ("inactive");
		transform.SetParent (playlistScreen.transform, false);
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
			//Debug.Log("ChooseFileStart(): file not selected yet");
			yield return new WaitForSeconds(1);
		}
		Debug.Log("PlaylistItemActions.ChooseFileStart(): file is selected");

		filePath = fileBrowser.File ();
		Debug.Log ("PlaylistItemActions.ChooseFileStart(), filePath: " + filePath);

		SetSoundPath (filePath);
		playlistScreen.Appear ();

		StartCoroutine( LoadSound(filePath) );
	}

	
	IEnumerator LoadSound(string fileName)
	{
		Debug.Log("PlaylistItemActions.LoadSound('"+fileName+"')");
		
		fileName = fileBrowser.protocolPrefix + fileName;
		//Debug.Log (fileName);

		w = new WWW(fileName);
		while (!w.isDone)
		{
			//fileLoadTime += fileLoadTimeStep;
			//Debug.Log("LoadSound: still loading '"+fileName+"'");
			soundStatus.SetStatus("wait");
			yield return new WaitForSeconds(fileLoadTimeStep);
		}
		//Debug.Log("PlaylistItemActions.LoadSound: LOAD COMPLETE '"+fileName+"', "+fileLoadTime+" sec ");
		Debug.Log("PlaylistItemActions.LoadSound(), COMPLETE '"+fileName+"'");
		soundStatus.SetStatus("ready");
		
		clip = w.audioClip;
		//Debug.Log ("PlaylistItemActions.LoadSound(), clip: "+clip);
		//Debug.Log ("PlaylistItemActions.LoadSound(), clip length: "+clip.length);
		//Debug.Log ("PlaylistItemActions.LoadSound(), clip frequency: "+clip.frequency);
		
		playlist.Add (fileName,clip);
	}

	public void SetSoundPath(string path)
	{
		Debug.Log ("PlaylistItemActions.SetSoundPath('" + path + "')");
		soundPath.text = path;
	}
	
	public void Remove()
	{
		Debug.Log ("PlaylistItemActions.Remove()");
		Destroy (gameObject);
	}
}
