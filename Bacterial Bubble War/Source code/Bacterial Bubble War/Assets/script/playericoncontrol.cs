using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playericoncontrol : MonoBehaviour {

	public GameObject cellplayer;

	public Sprite icon0;
	public Sprite icon1;



	void Start(){

		if (!PlayerPrefs.HasKey ("iconnum")) {
			PlayerPrefs.SetInt ("iconnum", 0);
		}



		switch (PlayerPrefs.GetInt ("iconnum")) {
		case 0:
			cellplayer.GetComponent<SpriteRenderer> ().sprite = icon0;
			//imgpreview.GetComponent<SpriteRenderer> ().sprite = background0;
			break;
		case 1:
			cellplayer.GetComponent<SpriteRenderer> ().sprite = icon1;
			//imgpreview.GetComponent<SpriteRenderer> ().sprite = background1;
			break;
		}
	}
}
