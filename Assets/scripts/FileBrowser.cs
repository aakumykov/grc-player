using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;


public class FSReader
{
	public FSReader()
	{
		Debug.Log ("FSReader.__construct()");
	}

	public string[] GetList(string path)
	{
		Debug.Log ("FSReader.GetList('"+path+"')");
		return new string[1];
	}
}


public class FSFilter
{
	public FSFilter()
	{
		Debug.Log ("FSFilter.__construct()");
	}

	public string[] ApplyFilter(string[] list, string pattern)
	{
		Debug.Log ("FSFilter.ApplyFilter()");
		return new string[1];
	}

	public string[] ApplyFilter(string[] list)
	{
		string[] list2 = ApplyFilter (list, "");
		return list2;
	}
}


public class FileBrowser : MonoBehaviour {

	public Player player;

	public FBTitle fbTitle;
	public FBList fbList;

	private FSReader fsReader;
	private FSFilter fsFilter;

	void Awake()
	{
		Debug.Log ("FileBrowser.Awake()");
		fsReader = new FSReader ();
		fsFilter = new FSFilter();
	}

	void Start()
	{
		fbTitle.SetTitle ("Путь:");
	}

	public void ShowDirectory(string path, string filter="")
	{
		Debug.Log ("FileBrowser.ShowDirectory()");

		string[] wetList = fsReader.GetList (path);
		string[] strictList = fsFilter.ApplyFilter (wetList);

		DisplayList (strictList);
	}


	public void Ok()
	{
		Debug.Log ("FileBrowser.Ok()");
	}

	public void Cancel()
	{
		Debug.Log ("FileBrowser.Cancel()");
	}


	private void DisplayList(string[] list)
	{
		Debug.Log ("FileBrowser.DisplayList()");
	}


}





