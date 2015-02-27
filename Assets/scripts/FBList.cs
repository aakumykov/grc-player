using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBList : MonoBehaviour {
	
	public Scrollbar scrollbar;
	
	private float x0;
	private float y0;
	
	private Rect listRect;
	private float rectHeight;
	private float frameHeight;
	private float workHeight;
	private float itemHeight;
		
	private float topOffset = 0f;
	private float rightOffset = 0f;
	private float bottomOffset = 0f;
	private float leftOffset = 0f;

	private float lastY = 10000000f;

	
	void Awake ()
	{
		Debug.Log ("FBList.Awake ()");
	}
	
	public void Init(Vector4 offsets)
	{
		Debug.Log ("FBList.Iint(), " + offsets);
		topOffset = offsets.x;
		rightOffset = offsets.y;
		bottomOffset = offsets.z;
		leftOffset = offsets.w;
	}
	
	public void Scrollbar(string action)
	{
		Debug.Log ("FBList.Scrollbar('"+action+"')");
		switch (action)
		{
			case "reset":
				scrollbar.value = 0f;
				break;
			case "restore":
				scrollbar.value = lastY;
				break;
			default:
				Debug.Log("FBList.Scrollbar(): UNKNOWN MODE '"+action+"'");
				break;
		}
	}

	public void CalcParams(int itemsCount)
	{
		listRect = gameObject.GetComponent<RectTransform> ().rect;
		
		itemHeight = FindObjectOfType<FBListItem> ().GetComponent<RectTransform>().rect.height;

		rectHeight = itemHeight * itemsCount;
		listRect.height = rectHeight;
		Debug.Log ("FBList.CalcParams(), rectHeight="+rectHeight+" (itemsCount="+itemsCount+")");

		frameHeight = Screen.height - topOffset - bottomOffset;
		Debug.Log ("FBList.CalcParams(), frameHeight=" + frameHeight+" (Screen.height= "+Screen.height+")");

		workHeight = rectHeight - frameHeight + topOffset;
		Debug.Log ("FBList.CalcParams(), workHeight: " + workHeight);
		
		lastY = y0;
		y0 = Screen.height - topOffset;
	}

	public void Move()
	{
		Debug.Log ("FBList.Move(scroll value:"+scrollbar.value+")");

		float deltaHeight = scrollbar.value * workHeight;
		Debug.Log ("deltaHeight: " + deltaHeight);

		float newY = y0 + deltaHeight;
		//newY = 50f;
		Debug.Log ("newY: " + newY+", x: "+transform.position.x);

		transform.position = new Vector3 (transform.position.x, newY, 0f);
	}
}
