using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public Playlist playlist;
	
	private int currentId = 10000000; //нереальное для листа число как признак начала
	private AudioSource music;
	
	void Awake()
	{
		Application.runInBackground = true;

		music = GetComponent<AudioSource>();
		music.panLevel = 0;
	}
	
	public void SetCLip(int id)
	{
		Debug.Log("Player.SetCLip("+id+")");

		AudioClip clip = playlist.Id2Clip(id);
		Debug.Log("Player.SetCLip(), clip: "+clip);

		music.clip = clip;
		currentId = id;
	}
	
	
	public void PlayPause(GameObject musicItem)
	{
		Debug.Log ("Player.PlayPause()");
		if (music.isPlaying)
		{
			Pause(musicItem);
		}
		else
		{
			Play (musicItem);
		}
	}
	
	public void Play(GameObject musicItem)
	{
		int id = Object2Id(musicItem);
		Debug.Log("Player.Play(), id: "+id);
		
		if (id != currentId) 
		{
			Debug.Log("Player.Play(), changing clip from id "+currentId+" to id "+id);
			SetCLip (id);
		}
		
		music.Play();
	}
	
	public void Pause(GameObject musicItem)
	{
		int id = Object2Id(musicItem);
		Debug.Log("Player.Pause(), id: "+id);
		
		if (id==currentId) 
		{
			music.Pause();
		}
		else
		{
			Debug.Log("Player.Pause(): cannot pause other song!");
		}
	}
	
	public void Stop(GameObject musicItem)
	{
		int id = Object2Id(musicItem);
		Debug.Log ("Player.Stop(" + id + ")");

		if (id==currentId)
		{
			music.Stop();
		}
		else
		{
			Debug.Log("Player.Stop(): cannot stop other's id ("+currentId+")");
		}
	}

	
	public void LinearStart(GameObject musicItem)
	{
		Debug.Log("Player.LinearStart()");
	}
	
	public void LinearStop(GameObject musicItem)
	{
		Debug.Log("Player.LinearStop()");
	}
	
	public void CurvedStart(GameObject musicItem)
	{
		Debug.Log("Player.CurvedStart()");
	}
	
	public void CurvedStop(GameObject musicItem)
	{
		Debug.Log("Player.CurvedStop()");
	}
	
	
	
	public void Seek(int id, float time)
	{
		Debug.Log("Player.Seek()");
	}
	
	public void SkipToBegin(GameObject musicItem)
	{
		Debug.Log("Player.SkipToBegin()");
	}
	
	
	public void SetVolume(float level)
	{
		
	}
	
	
	public bool Played()
	{
		Debug.Log ("Player.Played()");
		return music.isPlaying;
	}
	
	public float GetCurrentTime()
	{
		Debug.Log ("Player.GetCurrentTime()");
		return music.time;
	}
	
	public void GetIndex()
	{
	
	}

	
	public int Object2Id(GameObject musicItem)
	{
		Debug.Log("Player.Object2Id()");
		int id = musicItem.GetComponent<MusicItemActions>().GetId();
		return id;
	}
}
