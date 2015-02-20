using UnityEngine;
using System.Collections;

public class ListTest : MonoBehaviour {
	
	void Awake () 
	{
		Debug.Log ("=========================================");
		Debug.Log ("screen.size: "+Screen.width+"x"+Screen.height);
		Debug.Log ("=========================================");
		Debug.Log ("transform.position: " + transform.position);
		Debug.Log ("transform.localPosition: " + transform.localPosition);

		Rect rect = gameObject.GetComponent<RectTransform> ().rect;
		Debug.Log ("rect.position: " + rect.position);
		Debug.Log ("rect.size: " + rect.size);
		Debug.Log ("=========================================");
	}

}
