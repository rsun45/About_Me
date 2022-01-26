using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background_Control : MonoBehaviour {


	public GameObject background;

	public Sprite background0;
	public Sprite background1;

	public Dropdown background_dropdown;



	void Start(){
		Debug.Log (PlayerPrefs.GetInt ("bgnum"));
		switch (PlayerPrefs.GetInt ("bgnum")) {
		case 0:
			background_dropdown.value = 0;
			background.GetComponent<SpriteRenderer> ().sprite = background0;
			//imgpreview.GetComponent<SpriteRenderer> ().sprite = background0;
			break;
		case 1:
			background_dropdown.value = 1;
			background.GetComponent<SpriteRenderer> ().sprite = background1;
			//imgpreview.GetComponent<SpriteRenderer> ().sprite = background1;
			break;
		}
	}

	// Update is called once per frame
	void Update () {

		switch(background_dropdown.value)
		{
		case 0:
			background.GetComponent<SpriteRenderer> ().sprite = background0;
			//imgpreview.GetComponent<SpriteRenderer> ().sprite = background0;
			PlayerPrefs.SetInt ("bgnum", 0);
			break;
		case 1:
			background.GetComponent<SpriteRenderer> ().sprite = background1;
			//imgpreview.GetComponent<SpriteRenderer> ().sprite = background1;
			PlayerPrefs.SetInt ("bgnum", 1);
			break;


		}

	}

}
