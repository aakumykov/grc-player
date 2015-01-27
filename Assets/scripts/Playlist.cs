using UnityEngine;
using System.Collections;

public class Playlist : MonoBehaviour {

	public int listSize = 10;
	private int listIndex = 0;
	private ListItem[] list;
	
	public class ListItem
	{
		private int index;
		private string title;
		private AudioClip clip;
		
		public ListItem(int anIndex, string aTitle, AudioClip aClip)
		{
			index = anIndex;
			title = aTitle;
			clip = aClip;
		}
		
		public int Index() {
			return index;
		}
		public string Title() {
			return title;
		}
		public AudioClip Clip() {
			return clip;
		}
	}
	
	
	void Awake()
	{
		Debug.Log ("Playlist.Awake()");
		list = new ListItem[listSize];
	}


	public void Add(string title, AudioClip clip)
	{
		Debug.Log ("Playlist.Add("+listIndex+", '"+title+"', '"+clip+"')");

		list[listIndex] = new ListItem(
								listIndex,
								title,
								clip
							);
		listIndex += 1;
	}

	
	public AudioClip Title2Clip(string title)
	{
		Debug.Log ("Playlist.Title2Clip('"+""+"')");
		foreach(ListItem item in list)
		{
			if (title==item.Title()) return item.Clip();
		}
		return null;
	}
	
	public AudioClip Id2Clip(int id)
	{
		Debug.Log ("Playlist.Id2Clip('"+id+"')");
		if (null!=list[id]) return list[id].Clip();
		return null;
	}
	
	public AudioClip NextClip()
	{
		Debug.Log ("Playlist.NextClip('"+""+"')");
		if (null!=list[listIndex+1]) return list[listIndex+1].Clip();
		return null;
	}
	
	public AudioClip PrevClip()
	{
		Debug.Log ("Playlist.PrevClip('"+""+"')");
		if (null!=list[listIndex-1]) return list[listIndex-1].Clip();
		return null;
	}
	
	public int CurrentNumber()
	{
		Debug.Log ("Playlist.CurrentNumber()");
		return listIndex;
	}
	
	public int Size()
	{
		Debug.Log ("Playlist.Size()");
		int c=0;
		foreach(ListItem item in list)
		{
			if (null!=item) c += 1;
		}
		return c;
	}
	
	public string Id2Title(int id)
	{
		Debug.Log ("Playlist.Id2Title("+id+")");

		if (null==list[id]) 
		{
			Debug.Log("Playlist.Id2Title(): there is no list["+id+"]");
			return null;
		}

		string title = list [id].Title ();
		Debug.Log ("Playlist.Id2Title(): title "+id+" is '"+title);

		return title;
	}
	
	
	
}
