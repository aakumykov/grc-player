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
		//Debug.Log ("@@@@@@@@@@@@@@ PlaylistItemActions.Start() @@@@@@@@@@@@@@@, "+clip);
		//Debug.Log ("@@@@@@@@@@@@@@ PlaylistItemActions.Start() @@@@@@@@@@@@@@@, "+(clip.length==null));
		//Debug.Log ("@@@@@@@@@@@@@@ PlaylistItemActions.Start() @@@@@@@@@@@@@@@, "+index);
		soundStatus.SetStatus ("inactive");
		soundPath.text = "";
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
		AudioClip newClip = w.audioClip;
		Debug.Log("PlaylistItemActions.LoadSound(), load complete '"+fileName+"'");

		if (IsFilled())
		{
			Debug.Log("PlaylistItemActions.LoadSound(): changing item "+index);
			playlist.Change(index,filePath,newClip);
		}
		else
		{
			index = playlist.Add (fileName,newClip);
			Debug.Log ("PlaylistItemActions.LoadSound(), added new item "+index);
		}

		clip = newClip;
		soundStatus.SetStatus("ready");
	}

	public void SetSoundPath(string path)
	{
		//Debug.Log ("PlaylistItemActions.SetSoundPath('" + path + "')");
		soundPath.text = path;
	}
	
	public void Remove()
	{
		Debug.Log ("PlaylistItemActions.Remove(), index="+index);
		playlist.Del(index);
		Destroy (gameObject);
	}

	public int Index()
	{
		return index;
	}

	public bool IsFilled()
	{
		//Debug.Log ("PlaylistItemActions.IsFilled(), index: "+index);
		//Debug.Log ("PlaylistItemActions.IsFilled(), clip: "+clip);
		//return (null == clip.length);
		if (null!=clip) 
		{
			Debug.Log ("PlaylistItemActions.IsFilled(), FILLED");
			return true;
		}
		else 
		{
			Debug.Log ("PlaylistItemActions.IsFilled(), EMPTY");
			return false;
		}
	}
}
