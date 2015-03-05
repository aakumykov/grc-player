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
	public GameObject fbTitle;
	public GameObject fbFooter;
	public GameObject fbList;
	public Scrollbar scrollbar;
	
	private FSReader fsReader;

	public string protocolPrefix = "file://";
	public string filter = "*";
	//private string workPath = "";
	private string fileName;
	private string filePath;
	private bool isDone = false;

	private Rect listRect;
	 private float rectHeight;
	 private float frameHeight;
	 private float workHeight;
	 private float itemHeight;

	private float topOffset = 0f;
	private float rightOffset = 0f;
	private float bottomOffset = 0f;
	private float leftOffset = 0f;
	private float y0;

	public string initialPath = "";
	private string currentPath = "";
	private string lastPath = "";
	//public string[] pathHistory = new string[1000];



	void Awake()
	{
		Debug.Log ("FileBrowser.Awake()");
		fsReader = new FSReader ();
		InitList (new Vector4 (30f, 50f, 50f, 0f));
	}

	public void InitList(Vector4 offsets)
	{
		Debug.Log ("FBList.Iint(), " + offsets);
		topOffset = offsets.x;
		rightOffset = offsets.y;
		bottomOffset = offsets.z;
		leftOffset = offsets.w;
	}

	public void Appear()
	{
		Debug.Log ("FileBrowser.Appear()");
		
		isDone = false;
		
		OpenDir(true,"",filter);
		
		box.ChangeScreen ("files");
	}

	public void FilePick(bool isDir, string path)
	{
		Debug.Log ("FileBrowser.FilePick('" + path + "')");
		
		if (isDir)
		{
			Debug.Log("FileBrowser.FilePick(), IS DIR");
			OpenDir(false,path,filter);
		}
		else
		{
			filePath = path;
			fileName = path;
			isDone = true;
		}
	}

	public void OpenDir(bool buttonOpen, string path, string filter)
	{
		Debug.Log ("FileBrowser.OpenDir('"+path+"','"+filter+"')");
		
		if (buttonOpen)
		{
			if (""==lastPath)
			{
				Debug.Log ("FileBrowser.OpenDir(), FIRST OPEN, initial");
				currentPath = initialPath;
			}
			else
			{
				Debug.Log ("FileBrowser.OpenDir(), FIRST OPEN, not initial");
				currentPath = lastPath;
			}
			
			Debug.Log ("FileBrowser.OpenDir(), currentPath 1: "+currentPath);
			Debug.Log ("FileBrowser.OpenDir(), lastPath 1: "+lastPath);
		}
		else
		{
			if (".."==path)
			{
				Debug.Log ("FileBrowser.OpenDir(), UP");
				currentPath = GetParentPath(currentPath);
			}
			else
			{
				Debug.Log ("FileBrowser.OpenDir(), SECOND");				
				currentPath = path;;
			}
		}
		
		lastPath = currentPath;
		
		SetTitle(currentPath);
		
		string[][] list = fsReader.GetList(currentPath,filter);
		
		int listLength = ProcessList(list);
		
		SetFBParams(listLength);
	}

	private string GetParentPath(string path)
	{
		Debug.Log ("FileBrowser.GetParentPath('"+path+"')");

		/*path = path.Replace ("\\", "/");
		path = path.TrimEnd ('/');
		path = path.TrimStart ('/');
		Debug.Log ("Trimmed path: " + path);*/

		string workPath = Regex.Replace(path,"[^/]+/?$","");

		return workPath;
	}

	private int ProcessList(string[][] list)
	{
		Debug.Log ("FileBrowser.ProcessList()");

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

		return dirs.Length + files.Length;
	}

	public void SetFBParams(int itemsCount)
	{
		Debug.Log ("FBList.SetFBParams(), itemsCount: "+itemsCount+", screen: " + Screen.width + "," + Screen.height);
		
		listRect = gameObject.GetComponent<RectTransform> ().rect;
		
		itemHeight = FindObjectOfType<FBListItem> ().GetComponent<RectTransform>().rect.height;
		
		rectHeight = itemHeight * itemsCount;
		listRect.height = rectHeight;
		//Debug.Log ("FBList.SetFBParams(), rectHeight="+rectHeight+" (itemsCount="+itemsCount+")");
		
		frameHeight = Screen.height - topOffset - bottomOffset;
		//Debug.Log ("FBList.SetFBParams(), frameHeight=" + frameHeight+" (Screen.height= "+Screen.height+")");
		
		workHeight = rectHeight - frameHeight + topOffset;
		//Debug.Log ("FBList.SetFBParams(), workHeight: " + workHeight);
		//Debug.Log ("FBList.SetFBParams(), fbList.x,y: "+fbList.transform.position.x+","+fbList.transform.position.y);
		
		y0 = Screen.height - topOffset;
		//Debug.Log ("FBList.SetFBParams(), y0: "+y0);
		
		scrollbar.value = 0f;
	}

	public void MoveList()
	{
		Debug.Log ("*** MOVE LIST ***");

		float deltaHeight = scrollbar.value * workHeight;
		float newY = y0 + deltaHeight;
		fbList.transform.position = new Vector3 (fbList.transform.position.x, newY, 0f);

		Debug.Log ("FileBrowser.MoveList(scrollbar.value:"+scrollbar.value+"), deltaHeight: " + deltaHeight+", newY: " + newY);
	}

	public void SetTitle(string aTitle)
	{
		Debug.Log ("FileBrowser.SetTitle('"+aTitle+"')");
		fbTitle.GetComponentInChildren<Text>().text = aTitle;
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

	public string File()
	{
		Debug.Log ("FileBrowser.File()");
		return filePath;
	}
}





