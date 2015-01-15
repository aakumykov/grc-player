using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicItemActions : MonoBehaviour {

	public Player player;
	public Button playPauseButton;
	public Button stopButton;
	public Button linearStartButton;
	public Button linearStopButton;
	public Button curvedStartButton;
	public Button curvedStopButton;
	public Text title;
	public Slider volumeBar;
	public Slider progessBar;
	public Button skipToBeginButton;
	
	private int id;
	
	
	public void SetId(int anId)
	{
		Debug.Log ("MusicItemActions.SetId("+anId+")");
		id = anId;
	}
	
	public int GetId()
	{
		Debug.Log ("MusicItemActions.GetId()");
		return id;
	}
	
	public void SetPlayState()
	{
		Debug.Log ("MusicItemActions.SetPlayState()");
	}
	
	public void SetPauseState()
	{
		Debug.Log ("MusicItemActions.SetPauseState()");
	}
	
	public void SetStopState()
	{
		Debug.Log ("MusicItemActions.SetStopState()");
	}
	
	public void SetProgressBar(float value)
	{
		Debug.Log ("MusicItemActions.SetProgressBar('"+value+"')");
	}
	
	public void SetTitle(string aTitle)
	{
		Debug.Log ("MusicItemActions.SetTitle('"+aTitle+"')");
		title.GetComponent<Text>().text = aTitle;
	}
	
	public void SetActive()
	{
		Debug.Log ("MusicItemActions.SetActive()");
	}
	
	public void Fill(int id,string title)
	{
		Debug.Log ("MusicItemActions.Fill("+id+","+title+")");
		SetId(id);
		SetTitle(title);
	}
	
	
}
