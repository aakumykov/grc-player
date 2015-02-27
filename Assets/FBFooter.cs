using UnityEngine;
using System.Collections;

public class FBFooter : MonoBehaviour {

	public GameObject fbList;

	public void ShowXY()
	{
		Debug.Log ("FBList, screen: "+Screen.width+"x"+Screen.height);
		Debug.Log ("FBList.xy: " + fbList.transform.position.x + ", " + fbList.transform.position.y);
	}
}
