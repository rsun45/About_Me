using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgcontrlforother : MonoBehaviour {

	public GameObject background;

	public Sprite background0;
	public Sprite background1;



	void Start(){
		switch (PlayerPrefs.GetInt ("bgnum")) {
		case 0:
			background.GetComponent<SpriteRenderer> ().sprite = background0;
			//imgpreview.GetComponent<SpriteRenderer> ().sprite = background0;
			break;
		case 1:
			background.GetComponent<SpriteRenderer> ().sprite = background1;
			//imgpreview.GetComponent<SpriteRenderer> ().sprite = background1;
			break;
		}
	}
}
