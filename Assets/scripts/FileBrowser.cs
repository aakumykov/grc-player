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

	public string[] GetList(string path, string filter="")
	{
		Debug.Log ("FSReader.GetList('"+path+"','"+filter+"')");
		
		string[] dirs = Directory.GetDirectories (path);
		string[] files = Directory.GetFiles (path,filter);

		string[] list = new string[dirs.Length + files.Length];
		dirs.CopyTo (list, 0);
		files.CopyTo (list, dirs.Length);

		for (int i=0; i<list.Length; i+=1)
		{
			list[i] = list[i].Replace("\\","/");
		}

		return list;
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
		return list;
	}

	public string[] ApplyFilter(string[] list)
	{
		return ApplyFilter (list);
	}
}


public class FileBrowser : MonoBehaviour {

	public BOXActions box;
	public Player player;
	public FBTitle fbTitle;
	public FBList fbList;
	
	private FSReader fsReader;
	private FSFilter fsFilter;

	public string path = "c:/";
	public string filter = "*";

	private string currentPath = "";
	private bool isDone = false;
	private string fileName;
	private string filePath;

	void Awake()
	{
		//Debug.Log ("FileBrowser.Awake()");
		fsReader = new FSReader ();
		fsFilter = new FSFilter();
	}

	void Start()
	{

	}


	public void OpenDir(string path, string filter)
	{
		Debug.Log ("FileBrowser.OpenDir('"+path+"','"+filter+"')");

		if (""!=currentPath) currentPath = currentPath + "/" ;
		string fullPath = currentPath + path;
		Debug.Log ("FileBrowser.OpenDir(), fullPath: '"+fullPath);

		string[] wetList = fsReader.GetList (fullPath,filter);
		//string[] strictList = fsFilter.ApplyFilter (wetList);
		string[] strictList = wetList;

		DisplayList (strictList);

		currentPath = path;
	}

	private void DisplayList(string[] list)
	{
		Debug.Log ("FileBrowser.DisplayList()");

		// Получение объекта
		GameObject[] listItems = GameObject.FindGameObjectsWithTag ("FBListItem");
		GameObject initialListItem = listItems[0];

		// Удаление старого списка, кроме 1-ого элемента
		for(int i=1; i<listItems.Length; i+=1)
		{
			Debug.Log("FileBrowser.DisplayList(), удаляю элемент "+i);
			Destroy(listItems[i]);
		}

		// Создание нового списка
		initialListItem.GetComponent<FBListItem> ().SetName ("..");

		int y = -30;
		int dY = 30;
		for (int i=0; i<list.Length; i+=1)
		{
			string name = list[i];
			GameObject newItem = Instantiate(
				initialListItem,
				new Vector3(0,y,0),
				new Quaternion()
				) as GameObject;
			newItem.GetComponent<FBListItem>().SetName(name);
			newItem.transform.SetParent(fbList.transform,false);
			y -= dY;
		}
	}


	public void Ok()
	{
		Debug.Log ("FileBrowser.Ok()");
		//newSerialNumber = 2;
		//oldSerialNumber = 1;
	}

	public void Cancel()
	{
		Debug.Log ("FileBrowser.Cancel()");
		box.ChangeScreen ("playlist");
	}

	public bool IsDone()
	{
		//Debug.Log ("FileBrowser.IsFileSelected()");
		return isDone;
	}

	public void Appear()
	{
		Debug.Log ("FileBrowser.Appear()");

		isDone = false;

		fbTitle.SetTitle ("Каталог \""+path+"\"");
		OpenDir(path,filter);

		box.ChangeScreen ("files");
	}

	public void FilePick(string path)
	{
		Debug.Log ("FileBrowser.FilePick('" + path + "')");

		if (".."==path)
		{
			OpenDir(path,filter);
		}
		else
		{
			filePath = path;
			fileName = path;
			isDone = true;
		}
	}

	public string File()
	{
		Debug.Log ("FileBrowser.File()");
		return filePath;
	}
}





