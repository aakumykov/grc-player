using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class PlaylistItemActions : MonoBehaviour {

	public PlaylistScreenActions playlistScreen;
	public FileBrowser fileBrowser;

	public Image soundStatus;
	public Sprite inactiveIcon;
	public Sprite waitIcon;
	public Sprite readyIcon;
	
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
		
		fileName = "file:///" + fileName;
		//Debug.Log (fileName);

		w = new WWW(fileName);
		while (!w.isDone)
		{
			//fileLoadTime += fileLoadTimeStep;
			//Debug.Log("LoadSound: still loading '"+fileName+"'");
			SetStatus("wait");
			yield return new WaitForSeconds(fileLoadTimeStep);
		}
		//Debug.Log("PlaylistItemActions.LoadSound: LOAD COMPLETE '"+fileName+"', "+fileLoadTime+" sec ");
		Debug.Log("PlaylistItemActions.LoadSound(), COMPLETE '"+fileName+"'");
		SetStatus("ready");
		
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
	
	public void SetStatus(string mode)
	{
		Debug.Log ("PlaylistItemActions.SetStatus('"+mode+"')");
		if ("wait"==mode) soundStatus.sprite = waitIcon;
		else if ("ready"==mode) soundStatus.sprite = readyIcon;
		else soundStatus.sprite = inactiveIcon;
	}
}
