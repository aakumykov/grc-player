using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;


public class FSReader
{
	public FSReader()
	{
		Debug.Log ("FSReader.__construct()");
	}

	public string[][] GetList(string path, string filter="")
	{
		Debug.Log ("FSReader.GetList('"+path+"','"+filter+"')");

		//Debug.Log ("Current directory: "+Directory.GetCurrentDirectory ());
		//Debug.Log ("Some full path: "+Path.GetFullPath("C:/Users/Администратор/../"));

		string[] dirs = Directory.GetDirectories (path);
		string[] files = Directory.GetFiles (path,filter);

		for (int i=0; i<dirs.Length; i+=1)
		{
			dirs[i] = dirs[i].Replace ("\\","/");
		}

		for (int i=0; i<files.Length; i+=1)
		{
			files[i] = files[i].Replace ("\\","/");
		}

		string[][] list = new string[][] { dirs, files };

		return list;
	}
}


/*public class FSFilter
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
}*/


public class FileBrowser : MonoBehaviour {

	public BOXActions box;
	public Player player;
	public FBTitle fbTitle;
	public FBList fbList;
	public GameObject fbFooter;
	public Scrollbar scrollbar;
	
	private FSReader fsReader;
	//private FSFilter fsFilter;

	public string initialPath = "c:/";
	public string filter = "*";

	private string currentPath = "";
	private string workPath = "";
	private string lastPath = "";

	private string fileName;
	private string filePath;


	private bool isDone = false;

	void Awake()
	{
		//Debug.Log ("FileBrowser.Awake()");
		fsReader = new FSReader ();
		//fsFilter = new FSFilter();
		fbList.Init (new Vector4 (30f, 50f, 50f, 0f));
	}

	public void Appear()
	{
		Debug.Log ("FileBrowser.Appear()");
		
		isDone = false;

		if ("" != lastPath) initialPath = lastPath;

		fbTitle.SetTitle ("Каталог \""+initialPath+"\"");
		OpenDir(initialPath,filter);
		
		box.ChangeScreen ("files");
	}

	public void OpenDir(string reqPath, string filter)
	{
		Debug.Log ("FileBrowser.OpenDir('"+reqPath+"','"+filter+"')");

		/*reqPath = reqPath.Replace ("\\", "/");
		reqPath = reqPath.TrimEnd ('/');
		reqPath = reqPath.TrimStart ('/');
		Debug.Log ("Trimmed path: " + reqPath);*/

		if (".."==reqPath)
		{
			workPath = Regex.Replace(reqPath,"[^/]+/?$","");
		}
		else
		{
			//workPath = currentPath + reqPath;
			workPath = reqPath;
		}
		Debug.Log ("workPath: "+workPath);
		
		lastPath = workPath;

		fbTitle.SetTitle ("Каталог: "+workPath);

		string[][] list = fsReader.GetList (workPath,filter);

		DisplayList (list);
	}

	private void DisplayList(string[][] list)
	{
		Debug.Log ("FileBrowser.DisplayList()");

		// Получение объекта
		GameObject[] listItems = GameObject.FindGameObjectsWithTag ("FBListItem");
		GameObject initialListItem = listItems[0];

		// Удаление старого списка, кроме 1-ого элемента
		for(int i=1; i<listItems.Length; i+=1)
		{
			Destroy(listItems[i]);
		}

		// Создание нового списка
		initialListItem.GetComponent<FBListItem> ().Fill (true,"..");

		string[] dirs = new string[list[0].Length];
		string[] files = new string[list[1].Length];
		list[0].CopyTo (dirs, 0);
		list[1].CopyTo (files, 0);

		int y = -30;
		int dY = 30;

		for (int i=0; i<dirs.Length; i+=1)
		{
			string name = dirs[i];
			GameObject newItem = Instantiate(
				initialListItem,
				new Vector3(0,y,0),
				new Quaternion()
				) as GameObject;
			newItem.GetComponent<FBListItem>().Fill(true,name);
			newItem.transform.SetParent(fbList.transform,false);
			y -= dY;
		}

		for (int i=0; i<files.Length; i+=1)
		{
			string name = files[i];
			GameObject newItem = Instantiate(
				initialListItem,
				new Vector3(0,y,0),
				new Quaternion()
				) as GameObject;
			newItem.GetComponent<FBListItem>().Fill(false,name);
			newItem.transform.SetParent(fbList.transform,false);
			y -= dY;
		}
		
		fbList.CalcParams (dirs.Length + files.Length);
		fbList.ResetScrollbar ();
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

	public void FilePick(bool isDir, string path)
	{
		Debug.Log ("FileBrowser.FilePick('" + path + "')");

		if (isDir)
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





