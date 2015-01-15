using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BOXActions_old : MonoBehaviour {
/*
	// ================ Классы в классе =====================
	public class Engine
	{
		public void Test() { Debug.Log("Engine.Test()"); }
	}
	
	public class List
	{
		private PlaylistItem[] playlist;
		
		public List(int size)
		{
			playlist = new PlaylistItem[size];
		}
		
		public void Test() { Debug.Log("List.Test()"); }
	}

	class PlaylistItem
	{
		private int index;
		private string title;
		private AudioClip clip;
		
		public PlaylistItem(int anIindex, string aTitle, AudioClip aClip)
		{
			Debug.Log("PlaylistItem("+anIindex+","+aTitle+","+aClip+")");
			index = anIindex;
			title = aTitle;
			clip = aClip;
		}
		
		public int GetIndex() {
			return index;
		}
		public string GetTitle() {
			return title;
		}
		public AudioClip GetClip() {
			return clip;
		}
	}

	// =================== Свойства ========================
	public Canvas musicScreenCanvas;
	public Canvas settingsScreenCanvas;
	private MusicScreenActions musicScreen;
	
	private Engine playerEngine;
	private List playerList;
	
	public int playlistSize = 10;


	// ==================== Методы =========================
	void Awake()
	{
		Application.runInBackground = true;
		
		playerEngine = new Engine();
		playerList = new List(playlistSize);
		
		musicScreen = musicScreenCanvas.GetComponent<MusicScreenActions>();
		//settingsScreen = settingsScreenCanvas.GetComponent<SettingsScreenActions>();
		
		musicScreenCanvas.enabled = true;
		settingsScreenCanvas.enabled = false;
	}
	
	public Engine engine()
	{
		return playerEngine;
	}
	
	public List list()
	{
		return playerList;
	}
	
	
	public void ChangeScreen(string mode)
	{
		Debug.Log ("PlayerActions.ChangeScreen('"+mode+"')");
		
		switch (mode)
		{
			case "settings":
				settingsScreenCanvas.enabled = true;
				musicScreenCanvas.enabled = false;
				break;
			
			case "music":
				musicScreen.GenerateList();
				
				settingsScreenCanvas.enabled = false;
				musicScreenCanvas.enabled = true;
				
				break;
			
			default:
				Debug.Log("PlayerActions.ChangeScreen(): unknown mode '"+mode+"'");
				break;
		}
	}
	
	public AudioClip[] GetClips()
	{
		Debug.Log ("PlayerActions.GetClips()");
		
		/*AudioClip[] clips = new AudioClip[playlistSize];
		
		for (int i=0; i<playlistSize; i+=1)
		{
			PlaylistItem item = playlist[i];
			
			if (null!=item)
			{
				clips[item.GetIndex()] = item.GetClip();
			}
		}*/
		
		//return new AudioClip[playlistSize];
		//return clips;
//	}

	//public void AddSong(string title, AudioClip clip)
	//{
		/*Debug.Log ("PlayerActions.AddSong('"+title+"',"+clip+")");
		playlist[playlistIndex] = new PlaylistItem(playlistIndex,title,clip);
		playlistIndex += 1;*/
	//}

}
