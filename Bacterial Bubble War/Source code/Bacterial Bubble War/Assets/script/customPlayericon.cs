using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customPlayericon : MonoBehaviour {


	public Sprite icon0;
	public Sprite icon1;

	public Dropdown icon_dropdown;

	public GameObject imgpreview;


	void Start(){
		Debug.Log (PlayerPrefs.GetInt ("iconnum"));
		switch (PlayerPrefs.GetInt ("iconnum")) {
		case 0:
			icon_dropdown.value = 0;
			imgpreview.GetComponent<SpriteRenderer> ().sprite = icon0;
			break;
		case 1:
			icon_dropdown.value = 1;
			imgpreview.GetComponent<SpriteRenderer> ().sprite = icon1;
			break;
		}
	}

	// Update is called once per frame
	void Update () {

		switch(icon_dropdown.value)
		{
		case 0:
			imgpreview.GetComponent<SpriteRenderer> ().sprite = icon0;
			PlayerPrefs.SetInt ("iconnum", 0);
			break;
		case 1:
			imgpreview.GetComponent<SpriteRenderer> ().sprite = icon1;
			PlayerPrefs.SetInt ("iconnum", 1);
			break;


		}

	}

}