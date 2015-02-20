using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBList : MonoBehaviour {
	
	public Scrollbar scrollbar;
	
	private float topOffset = 0f;
	private float rightOffset = 0f;
	private float bottomOffset = 0f;
	private float leftOffset = 0f;

	private Rect listRect;
	private float itemHeight;

	private float frameHeight = 320f;
	private float listHeight;
	private float x0;
	private float y0;
	private float y;
	
	void Awake ()
	{
		/*Debug.Log ("=========================================");
		Debug.Log ("SCREEN: "+Screen.width+"x"+Screen.height);
		Debug.Log ("transform.position: " + transform.position);
		
		Rect listRect = gameObject.GetComponent<RectTransform> ().rect;
		Debug.Log ("listRect.position: " + listRect.position);
		Debug.Log ("listRect.size: " + listRect.size);
		Debug.Log ("=========================================");*/

		listRect = gameObject.GetComponent<RectTransform> ().rect;
		itemHeight = FindObjectOfType<FBListItem> ().GetComponent<RectTransform>().rect.height;

		listHeight = listRect.height;
		x0 = transform.position.x;
		y0 = transform.position.y;
		y = y0;

		Debug.Log ("=========================================");
		Debug.Log ("SCREEN: "+Screen.width+"x"+Screen.height);
		Debug.Log ("listHeight:"+listHeight);
		Debug.Log ("x0:"+x0);
		Debug.Log ("y0:"+y0);
		Debug.Log ("=========================================");
	}
	
	public void Init(Vector4 offsets)
	{
		Debug.Log ("FBList.Iint(), " + offsets);
		topOffset = offsets.x;
		rightOffset = offsets.y;
		bottomOffset = offsets.z;
		leftOffset = offsets.w;
	}
	
	public void ResetScrollbar()
	{
		Debug.Log ("FBList.ResetScrollbar()");
		scrollbar.value = 0f;
	}
	
	public void SetHeight(int itemsCount)
	{
		Debug.Log ("FBList.SetHeight(itemsCount:"+itemsCount+")");
		listHeight = itemHeight * itemsCount;
		listRect.height = listHeight;
		Debug.Log ("listHeight: "+listHeight);
	}
	
	public void Move()
	{
		Debug.Log ("FBList.Move(), scrollbar.value="+scrollbar.value);
		Debug.Log ("height delta: "+scrollbar.value * listHeight);
		float newY = y0 + (scrollbar.value * listHeight + frameHeight / 2) + bottomOffset - topOffset;
		Debug.Log ("newY: "+newY);
		transform.position = new Vector3 (x0, newY);
	}
}
