using UnityEngine;
using System.Collections;

public class ListTest : MonoBehaviour {

	void Awake () 
	{
		Debug.Log ("=========================================");
		Debug.Log ("SCREEN: "+Screen.width+"x"+Screen.height);
		Debug.Log ("transform.position: " + transform.position);

		Rect rect = gameObject.GetComponent<RectTransform> ().rect;
		Debug.Log ("rect.position: " + rect.position);
		Debug.Log ("rect.size: " + rect.size);
		Debug.Log ("=========================================");
	}

}
