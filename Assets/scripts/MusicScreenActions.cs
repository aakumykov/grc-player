using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicScreenActions : MonoBehaviour {

	public Player player;
	public Playlist playlist;
	public GameObject firstMusicItem;
	
	void Awake()
	{
		Debug.Log ("MusicScreenActions.Awake()");
	}
	
	void Start()
	{
		GenerateList();
	}

	public void GenerateList()
	{
		// Удаляю, начиная со второго
		GameObject[] allItems = GameObject.FindGameObjectsWithTag("MusicItem");

		for (int i=1; i<allItems.Length; i+=1)
		{
			Destroy(allItems[i]);
		}

		// Создаю новый
		Debug.Log ("playlist size = " + playlist.Size ());

		int dY = 110;
		int y = -dY;
		for (int i=1; i<playlist.Size(); i+=1)
		{
			GameObject item = Instantiate(
									firstMusicItem,
									new Vector3(0,y,0),
									new Quaternion()
								) as GameObject;
			item.transform.SetParent(transform,false);
			y -= dY;
			
			item.GetComponent<MusicItemActions>().Fill(
					i,
					playlist.Id2Title(i)
			);
		}
	}
	
	
}
