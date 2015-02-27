using UnityEngine;
using System.Collections;

public class FBFooter : MonoBehaviour {

	public GameObject fbList;

	public void ShowXY()
	{
		Debug.Log ("FBList.xy: " + fbList.transform.position.x + ", " + fbList.transform.position.y);
	}
}
