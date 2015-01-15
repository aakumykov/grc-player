using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicScreenActions : MonoBehaviour {

	public Player player;
	public Playlist playlist;
	public GameObject aMusicItem;
	
	void Awake()
	{
		Debug.Log ("MusicScreenActions.Awake()");
	}
	
	void Start()
	{
		DisplayList();
	}

	public void DisplayList()
	{
		GameObject[] allItems = GameObject.FindGameObjectsWithTag("MusicItem");
		string title = playlist.Id2Title(0);
		allItems[0].GetComponent<MusicItemActions>().Fill(0,title);
		
		int dY = 110;
		int y = -dY;
		for (int i=1; i<playlist.Size(); i+=1)
		{
			GameObject item = Instantiate(
									aMusicItem,
									new Vector3(0,y,0),
									new Quaternion()
								) as GameObject;
			item.GetComponent<MusicItemActions>().Fill(i,playlist.Id2Title(i));
			item.transform.SetParent(transform,false);
			y -= dY;
		}
		
		/*int i = 1;
		foreach (GameObject item in allItems)
		{
			item.GetComponent<MusicItemActions>().SetTitle(i+"");
			i += 1;
		}*/
	}
	
	
}
