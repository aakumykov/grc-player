using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBList : MonoBehaviour {
	
	public int headerHeight;
	public int footerHeight;
	
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
		Debug.Log ("FBList.Awake(), transform.position: "+transform.position);
		
		//SaveScreenState();
		
		CalcParams();
	}
	
	void Start()
	{
		//StartCoroutine( CheckScreenSize() );
	}
	
	/*IEnumerator CheckScreenSize()
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
	}*/
	
	/*void SaveScreenState()
	{
		oldScrollValue = scrollbar.value;
		
		oldScreenWidth = Screen.width;
		oldScreenHeight = Screen.height;
	}*/
	
	public void CalcParams()
	{
		panelRect = gameObject.GetComponent<RectTransform>().rect;
		
		float parentHeight = transform.parent.GetComponent<RectTransform>().rect.height;
		float rectHeight = panelRect.height;
		
		y0 = parentHeight - headerHeight;
		y1 = rectHeight + footerHeight;
		yOverlap = y1 - y0;
		y = y0;
		
		Debug.Log ("==============CalcParams===============");
		Debug.Log ("parentHeight: "+parentHeight);
		Debug.Log ("rectHeight: "+rectHeight);
		Debug.Log ("y0, y1, yOverlap: "+y0+", "+y1+", "+yOverlap);
		Debug.Log ("==============CalcParams===============");
	}
	
	public void Move(float value)
	{
		float newY = y0 + yOverlap * value;
		
		transform.position = new Vector3(
			transform.position.x,
			newY
			);
		
		//Debug.Log("---------------");
	}
}
