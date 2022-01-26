﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazy_movement : MonoBehaviour {

	public float moveSpeed = 10f;
	float radius= 0.6f;
	// Use this for initialization
	void Start () {
		float randomAngle=Random.Range(-180f,180f);
		transform.rotation = Quaternion.Euler (0, 0, randomAngle);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		//pos.y +=moveSpeed * Time.deltaTime;
		//pos.x +=moveSpeed * Time.deltaTime;
		Quaternion rot= transform.rotation;



		if (pos.y+radius> Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize-radius;
			float newz;
			newz = rot.eulerAngles.z;
			newz = -180 - newz;
			rot = Quaternion.Euler (0, 0, newz);
			//transform.rotation=(0,0,transform.rotation.z)
		}
		if (pos.y-radius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize+radius;
			float newz;
			newz = rot.eulerAngles.z;
			newz = 180 - newz;
			rot = Quaternion.Euler (0, 0, newz);

		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (pos.x + radius > widthOrtho) {
			pos.x = widthOrtho - radius;

			float newz;
			newz = rot.eulerAngles.z;
			newz = - newz;
			rot = Quaternion.Euler (0, 0, newz);

		}
		if (pos.x - radius < -widthOrtho) {
			pos.x = -widthOrtho + radius;
			float newz;
			newz = rot.eulerAngles.z;
			newz = - newz;
			rot = Quaternion.Euler (0, 0, newz);
		}
		transform.rotation = rot;
		Vector3 velocity = new Vector3 (0, moveSpeed * Time.deltaTime, 0);

		pos += transform.rotation * velocity;


		transform.position = pos;
	}
}
