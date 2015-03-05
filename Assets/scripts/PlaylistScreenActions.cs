using UnityEngine;
using System.Collections;

public class PlaylistScreenActions : MonoBehaviour {

	public BOXActions box;
	public Playlist playlist;
	public GameObject playlistItem;

	private int y = -40;
	private int dY = 40;

	public void AddItem()
	{
		Debug.Log ("PlaylistScreenActions.AddItem()");

		GameObject item = Instantiate (
							playlistItem,
							new Vector3 (0, y, 0),
							new Quaternion ()
				) as GameObject;

		//item.transform.SetParent (transform, false);

		y -= dY;
	}

	public void Appear()
	{
		Debug.Log ("PlaylistScreenActions.Appear()");
		box.ChangeScreen ("playlist");
	}
}
