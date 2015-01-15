using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public Playlist playlist;
	private AudioSource music;
	
	void Awake()
	{
		Application.runInBackground = true;
		
		music = GetComponent<AudioSource>();
		music.panLevel = 0;
		
		
	}
	
	public void Load(int index)
	{
	
	}
	
	public void Play(GameObject mi)
	{
		Debug.Log("Player.Play()");
		
		int id = mi.GetComponent<MusicItemActions>().GetId();
		Debug.Log("Player.Play(), id: "+id);
		
		AudioClip clip = playlist.Id2Clip(id);
		Debug.Log("Player.Play(), clip: "+clip);
	}
	
	public void Pause(GameObject mi)
	{
		
	}
	
	public void Stop(GameObject mi)
	{
		
	}
	
	public void PlayPause(GameObject mi)
	{
		
	}
	
	
	public void LinearStart(GameObject mi)
	{
		Debug.Log("Player.LinearStart()");
	}
	
	public void LinearStop(GameObject mi)
	{
		Debug.Log("Player.LinearStop()");
	}
	
	public void CurvedStart(GameObject mi)
	{
		Debug.Log("Player.CurvedStart()");
	}
	
	public void CurvedStop(GameObject mi)
	{
		Debug.Log("Player.CurvedStop()");
	}
	
	
	
	public void Seek(int id, float time)
	{
		Debug.Log("Player.Seek()");
	}
	
	public void SkipToBegin(GameObject mi)
	{
		Debug.Log("Player.SkipToBegin()");
	}
	
	
	public void SetVolume(float level)
	{
		
	}
	
	public float GetCurrentTime()
	{
		Debug.Log ("Player.GetCurrentTime()");
		return music.time;
	}
	
	public void GetIndex()
	{
	
	}

}
