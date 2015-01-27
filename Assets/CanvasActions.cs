using UnityEngine;
using System.Collections;

public class CanvasActions : MonoBehaviour {

	public void Test()
	{
		Debug.Log ("Canvas test");

		AudioSource boxAudio = GameObject.Find ("BOX").GetComponent<AudioSource> ();
		Debug.Log (boxAudio);
		Debug.Log (boxAudio.clip);
		Debug.Log (boxAudio.clip.frequency);
		Debug.Log (boxAudio.clip.length);
		boxAudio.Play ();
	}
}
