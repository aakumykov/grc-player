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

	private int index;
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
		StartCoroutine (ChooseFileCoroutine ());
	}

	IEnumerator ChooseFileCoroutine()
	{
		Debug.Log("PlaylistItemActions.ChooseFileCoroutine()");

		fileBrowser.Appear ();

		while ( ! fileBrowser.IsDone() )
		{
			//Debug.Log("ChooseFileCoroutine(): file not selected yet");
			yield return new WaitForSeconds(1);
		}
		Debug.Log("PlaylistItemActions.ChooseFileCoroutine(): file is selected");

		filePath = fileBrowser.File ();
		Debug.Log ("PlaylistItemActions.ChooseFileCoroutine(), filePath: " + filePath);

		SetSoundPath (filePath);
		playlistScreen.Appear ();

		StartCoroutine( LoadSound(filePath) );
	}

	IEnumerator LoadSound(string fileName)
	{
		Debug.Log("PlaylistItemActions.LoadSound('"+fileName+"')");
		
		fileName = fileBrowser.protocolPrefix + fileName;

		w = new WWW(fileName);
		while (!w.isDone)
		{
			soundStatus.SetStatus("wait");
			yield return new WaitForSeconds(fileLoadTimeStep);
		}
		Debug.Log("PlaylistItemActions.LoadSound(), load complete '"+fileName+"'");

		clip = w.audioClip;

		soundStatus.SetStatus("ready");
		
		int newIndex = playlist.Add (fileName,clip);
		Debug.Log ("PlaylistItemActions.LoadSound(), added index: "+index);

		index = newIndex;
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

	public int Index()
	{
		return index;
	}

}
