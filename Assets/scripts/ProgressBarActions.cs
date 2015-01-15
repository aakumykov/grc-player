using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBarActions : MonoBehaviour {

	public Player player;
	public MusicItemActions musicItem;
	private bool isDragged = false;
	
	
	public bool Dragged()
	{
		return isDragged;
	}
	
	
	public void DragStart()
	{
		Debug.Log ("ProgressBarActions.DragStart()");
		isDragged = true;
	}
	
	
	public void DragEnd()
	{
		Slider sl = GetComponentInParent<Slider>();
		float value = sl.value;
		Debug.Log ("ProgressBarActions.DragEnd(), id: "+musicItem.GetId()+", value: "+value);
		
		player.Seek (
			musicItem.GetId(),
			value
		);
		
		isDragged = false;
	}
	
	
}
