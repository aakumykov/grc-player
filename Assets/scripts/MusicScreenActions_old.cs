using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicScreenActions_old : MonoBehaviour {

/*	public BOXActions player;
	public GameObject musicItem;
	
	public void GenerateList()
	{
		Debug.Log ("MusicScreenActions.GenerateList()");
		
		// Удаление старого списка
		GameObject[] oldList = GameObject.FindGameObjectsWithTag("MusicItem");
		foreach (GameObject oldItem in oldList)
		{
			Destroy(oldItem);
		}
		
		// Создание нового списка
		//AudioClip[] allClips = player.GetClips();
		Debug.Log ("ЗАГЛУШКА 'allClips'");
		AudioClip[] allClips = new AudioClip[1];
		//Debug.Log("MusicScreenActions.GenerateList(), allClips: "+allClips);
		int y = 0;
		int dY = 110;
		
		foreach (AudioClip clip in allClips)
		{
			if (null!=clip)
			{
				GameObject p = Instantiate(
									musicItem,
									new Vector3(0f,y,0f),
									new Quaternion()
								)as GameObject;
				
				//p.GetComponent<MusicItemActions>().SetClip(clip);
				
				p.transform.SetParent(transform,false);
				
				y-=dY;
			}
		}
	}
	*/
	
	/*public void SetClip(AudioClip arg)
	{
		if (music.clip == arg)
		{
			Debug.Log("MusicScreenActions.SetClip: Clip already loaded");
		}
		else
		{
			music.clip = arg;
			Debug.Log("MusicScreenActions.SetClip: DONE");
		}
	}
	
	
	public float GetTime()
	{
		return music.time;
	}
	
	
	public bool IsSameClip(AudioClip clip)
	{
		if (clip == music.clip) return true;
		else return false;
	}
	
	
	public bool IsPlaying()
	{
		return music.isPlaying;
	}
	
	
	public void PlayPause()
	{
		Debug.Log ("PlayPause");

		if (!music.isPlaying)
		{
			music.Play();
			//playPauseButtonActions.ChangeIcon("pause");
			Debug.Log ("Play");
		}
		else
		{
			music.Pause();
			//playPauseButtonActions.ChangeIcon("play");
			//playPauseButtonActions.AnimatePause();
			Debug.Log ("Pause");
		}
	}


	// ===== Линейное нарастание (начало) =====

	public void LinearPlay()
	{
		Debug.Log ("LinearPlay");

		if (!music.isPlaying)
		{
			if (linearStartLength < volumeChangeInterval) linearStartLength = volumeChangeInterval;

			float linearStartFactor = finalVolume / linearStartLength;
			Debug.Log ("linearStartFactor: "+linearStartFactor);

			StartCoroutine ( LinearPlayStart(linearStartFactor) );

			music.Play();
		}
		else
		{
			Debug.Log ("LinearPlay: MUSIC ALREADY PLAYS");
		}
	}
	
	
	IEnumerator LinearPlayStart(float linearStartFactor)
	{
		Debug.Log ("LinearPlayStart");

		for (float t=0.0f; t <= linearStartLength; t+=volumeChangeInterval)
		{
			float volume = linearStartFactor * t;
			Debug.Log ("t: "+t+", volume: "+volume);

			music.volume = volume;

			yield return new WaitForSeconds(volumeChangeInterval);
		}
	}

	public void LinearStop()
	{
		Debug.Log ("LinearStop");
	}

	// ===== Линейное нарастание (конецъ) =====

	// ===== Нелинейное нарастание (начало) =====

	public void CurvedPlay()
	{
		Debug.Log ("CurvedPlay");

		if (!music.isPlaying)
		{
			if (curvedStartLength < volumeChangeInterval) curvedStartLength = volumeChangeInterval;

			float k = finalVolume / (curvedStartLength * curvedStartLength);
			Debug.Log ("k: "+k);

			StartCoroutine ( CurvedPlayStart(k) );

			music.Play();
		}
		else
		{
			Debug.Log ("CurvedPlay: MUSIC ALREADY PLAYS");
		}
	}

	
	IEnumerator CurvedPlayStart(float k)
	{
		Debug.Log ("CurvedPlayStart");

		for (float t=0.0f; t <= curvedStartLength; t+=volumeChangeInterval)
		{
			float volume = k * t * t;
			Debug.Log ("t: "+t+", volume: "+volume);
			
			music.volume = volume;
			
			yield return new WaitForSeconds(volumeChangeInterval);
		}
	}

	public void CurvedStop()
	{
		Debug.Log ("CurvedStop");
	}

	// ===== Нелинейное нарастание (конецъ) =====
	

	public void Seek(float position)
	{
		music.time = position;
	}


	public void SkipToBegin()
	{
		Seek (0f);
	}


	public void Stop()
	{
		Debug.Log ("Stop");
		music.Stop ();
		musicItemActions.SetProgress(0f);
		Seek (0f);
		//playPauseButtonActions.ChangeIcon("play");		
	}
	
	public void ChangeVolume(AudioClip clip, float level)
	{
		Debug.Log("MusicScreenActions.ChangeVolume("+level+")");
		if ( IsSameClip(clip) ) music.volume = level;
	}
	
	public void ChangeProgress(AudioClip clip, float time)
	{
		Debug.Log("MusicScreenActions.ChangeProgress("+time+")");
		if ( IsSameClip(clip) ) music.time = time;
	}*/
}
