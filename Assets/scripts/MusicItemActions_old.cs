using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicItemActions_old : MonoBehaviour {

	/*private MusicScreenActions musicScreen;
	
	public Slider volumeBar;
	public Slider progressBar;
	public bool progressBarIsDragged = false;
	
	private AudioClip clip;
	private float progressUpdateStep;
	
	void Start()
	{
		musicScreen = GetComponentInParent <MusicScreenActions> ();
		Debug.Log ("MusicItemActions.Start(): "+musicScreen);
	}
	
	void Update()
	{
		if (musicScreen.IsPlaying())
		{
			Debug.Log ("MusicItemActions.Update()");
			UpdateProgressBar();
		}
	}
	
	public void SetClip(AudioClip arg)
	{
		Debug.Log("MusicItemActions.SetClip('"+arg+"')");
		clip = arg;
		
		progressUpdateStep = 1 / clip.length;
		Debug.Log ("progress update step: "+progressUpdateStep);
	}
	
	public AudioClip GetClip()
	{
		Debug.Log("MusicItemActions.GetClip()");
		return clip;
	}
	
	public void SetProgress(float percent)
	{
		//float p = percent * progressUpdateStep;
		Debug.Log ("MusicItemActions.SetProgress("+percent+")");
		progressBar.value = percent;
	}
	
	public void GuiAction(string mode)
	{
		Debug.Log ("MusicItemActions.GuiAction('"+mode+"')");
		
		switch (mode)
		{
			case "PlayPause":
				musicScreen.SetClip(clip);
				musicScreen.PlayPause();
				break;
			
			case "Stop":
				musicScreen.Stop();
				break;
			
			case "LinearPlay":
				musicScreen.LinearPlay();
				break;
			
			case "LinearStop":
				musicScreen.LinearStop();
				break;
			
			case "CurvedPlay":
				musicScreen.CurvedPlay();
				break;
			
			case "CurvedStop":
				musicScreen.CurvedStop();
				break;
			
			case "SkipToBegin":
				musicScreen.SkipToBegin();
				break;
			
			case "ChangeVolume":
				musicScreen.ChangeVolume(clip,volumeBar.value);
				break;
			
			default:
				Debug.Log ("MusicItemActions.GuiAction: unknown mode '"+mode+"'");
				break;
		}
	}
	
	void UpdateProgressBar()
	{
		if (!progressBarIsDragged)
		{
			if (musicScreen.IsSameClip(clip)) 
			{
				float currentTime = musicScreen.GetTime();
				if (currentTime==clip.length) {
					currentTime = 0f;
				}
				progressBar.value = currentTime * progressUpdateStep;
			}
		}
	}
	
	public void ProgressChangeStart()
	{
		progressBarIsDragged = true;
	}
	
	public void ProgressChangeEnd()
	{
		progressBarIsDragged = false;
		musicScreen.Seek(progressBar.value / progressUpdateStep);
	}
	*/
}
