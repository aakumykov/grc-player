using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBListItem : MonoBehaviour {

	public FileBrowser fileBrowser;

	private int id;
	private bool isDir;
	private string fileName;
	private Text text;

	void Awake()
	{
		text = GetComponentInChildren<Text> ();
	}

	public void Fill(bool isDirectory, string name)
	{
		isDir = isDirectory;
		fileName = name;
		text.text = name;
	}

	public string GetName()
	{
		Debug.Log (fileName);
		return fileName;
	}

	public bool IsDir()
	{
		return isDir;
	}

	public void FilePick()
	{
		Debug.Log("FBListItem.FilePick()");
		fileBrowser.FilePick (isDir,fileName);
	}
	
	
	public void ShowSize()
	{
		Debug.Log ("FBListItem size: "+gameObject.GetComponent<RectTransform>().rect.size);
	}
}
