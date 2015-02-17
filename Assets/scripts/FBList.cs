using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBList : MonoBehaviour {

	public Scrollbar scrollbar;
	public int steps = 10;
	public float checkInterval = 0.1f;
	
	private Rect panelRect;
	private float y0;
	private float y1;
	private float yOverlap;
	private float y;
	private float oldScrollValue;
	private float oldScreenWidth;
	private float oldScreenHeight;
	
	void Awake()
	{
		Debug.Log ("==============FBList.Awake===============");
		Debug.Log ("transform.position: "+transform.position);
		Debug.Log ("==============FBList.Awake===============");
		
		scrollbar.numberOfSteps = steps + 1;
		
		SaveScreenState();
		
		CalcParams();
	}
	
	void Start()
	{
		//StartCoroutine( CheckScreenSize() );
	}
	
	IEnumerator CheckScreenSize()
	{
		while (true)
		{	
			if (oldScrollValue != scrollbar.value)
			{
				SaveScreenState();
				Move ();
			}
			
			if (oldScreenWidth != Screen.width || oldScreenHeight != Screen.height)
			{
				//Debug.Log ("CheckScreenSize(): SIZE CHANGED");
				SaveScreenState();
				CalcParams();
			}
			
			yield return new WaitForSeconds(checkInterval);
		}
	}
	
	void SaveScreenState()
	{
		oldScrollValue = scrollbar.value;
		
		oldScreenWidth = Screen.width;
		oldScreenHeight = Screen.height;
	}
	
	void CalcParams()
	{	
		panelRect = gameObject.GetComponent<RectTransform>().rect;
		
		float parentHeight = transform.parent.GetComponent<RectTransform>().rect.height;
		float rectHeight = panelRect.height;
		
		y0 = parentHeight - 30;
		y1 = rectHeight;
		yOverlap = y1 - y0;
		y = y0;
		
		Debug.Log ("==============CalcParams===============");
		Debug.Log ("parentHeight: "+parentHeight);
		Debug.Log ("rectHeight: "+rectHeight);
		Debug.Log ("y0, y1, yOverlap: "+y0+", "+y1+", "+yOverlap);
		Debug.Log ("==============CalcParams===============");
	}
	
	public void Move()
	{
		float newY = y0 + yOverlap * scrollbar.value;
		
		transform.position = new Vector3(
			transform.position.x,
			newY
			);
		
		oldScrollValue = scrollbar.value;
		
		//Debug.Log("---------------");
	}
}
