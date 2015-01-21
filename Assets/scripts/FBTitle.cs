﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBTitle : MonoBehaviour {

	private Text title;

	void Awake()
	{
		title = GetComponentInChildren <Text> ();
		Debug.Log (title);
	}

	public void SetTitle(string aTitle)
	{
		Debug.Log ("FBTitle.SetTitle('"+aTitle+"')");
		title.text = aTitle;
	}
}
