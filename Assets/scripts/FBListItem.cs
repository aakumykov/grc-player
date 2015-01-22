using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBListItem : MonoBehaviour {

	private string fileName;
	private Text text;

	void Awake()
	{
		text = GetComponentInChildren<Text> ();
	}

	public void SetName(string name)
	{
		fileName = name;
		text.text = name;
	}

	public string GetName()
	{
		Debug.Log (fileName);
		return fileName;
	}

	public void ClickTest()
	{
		Debug.Log (fileName);
	}
}
