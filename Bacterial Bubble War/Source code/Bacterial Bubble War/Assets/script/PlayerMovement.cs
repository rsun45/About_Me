using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 5f;
	float radius= 0.6f;

	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("playerMoveSpeed")) {
			PlayerPrefs.SetFloat ("playerMoveSpeed", 8.0f);
		}

		moveSpeed = PlayerPrefs.GetFloat ("playerMoveSpeed");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
	

		pos.y += Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;

		if (Input.GetAxis ("Horizontal") > 0) {
			transform.rotation = Quaternion.Euler(0,0,0);
			pos.x += Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		}
		else if (Input.GetAxis ("Horizontal") < 0) {
			transform.rotation = Quaternion.Euler(0,180,0);
			pos.x += Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		}
	

		if (pos.y+radius> Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize-radius;
		}
		if (pos.y-radius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize+radius;
		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (pos.x + radius > widthOrtho) {
			pos.x = widthOrtho - radius;
		}
		if (pos.x - radius < -widthOrtho) {
			pos.x = -widthOrtho + radius;
		}

		transform.position = pos;

	}
		
}
