using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBList : MonoBehaviour {
	
	public Scrollbar scrollbar;
	
	private float topOffset = 0f;
	private float rightOffset = 0f;
	private float bottomOffset = 0f;
	private float leftOffset = 0f;
	
	private float frameHeight;

	private Rect listRect;
	private float listHeight;
	private float itemHeight;
	
	private float x0;
	private float y0;
	
	void Awake ()
	{
		Debug.Log ("FBList.Awake ()");
		x0 = transform.position.x;
		y0 = transform.position.y;
	}
	
	public void Init(Vector4 offsets)
	{
		Debug.Log ("FBList.Iint(), " + offsets);
		topOffset = offsets.x;
		rightOffset = offsets.y;
		bottomOffset = offsets.z;
		leftOffset = offsets.w;

		y0 = y0 + topOffset;
	}
	
	public void ResetScrollbar()
	{
		Debug.Log ("FBList.ResetScrollbar()");
		scrollbar.value = 0f;
	}

	public void CalcParams(int itemsCount)
	{
		frameHeight = Screen.height - topOffset - bottomOffset;
		Debug.Log ("FBList.CalcParams(), Screen.height: " + Screen.height);
		Debug.Log ("FBList.CalcParams(), frameHeight: " + frameHeight);
		
		listRect = gameObject.GetComponent<RectTransform> ().rect;
		itemHeight = FindObjectOfType<FBListItem> ().GetComponent<RectTransform>().rect.height;

		listHeight = itemHeight * itemsCount - frameHeight;
		listRect.height = listHeight;
		Debug.Log ("FBList.CalcParams(itemsCount="+itemsCount+", listHeight="+listHeight);
	}

	public void Move()
	{
		Debug.Log ("FBList.Move(scroll value:"+scrollbar.value+")");

		float deltaHeight = scrollbar.value * listHeight;
		Debug.Log ("deltaHeight: " + deltaHeight);

		float newY = deltaHeight + y0;
		Debug.Log ("newY: " + newY);

		transform.position = new Vector3 (x0, newY);
	}
}
