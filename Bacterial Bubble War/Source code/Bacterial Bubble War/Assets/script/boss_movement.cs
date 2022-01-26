using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_movement : MonoBehaviour {

	public float moveSpeed = 10f;
	public float speedMul = 1.0f;
	public float randomSpeedMin = 5.0f;
	public float randomSpeedMax = 10.0f;

	float radius= 1.0f;
	float angle = 0.0f;

	float dx, dy;
	Vector3 move;

	// Use this for initialization
	void Start () {
		// random a direction in x y coordinate
		dx = Random.Range(-1f, 1f);
		dy = Random.Range (-1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;
		// when collide right screen side
		if (pos.x + radius > widthOrtho && dx > 0) {
			dx = -dx;

			// random a direction and a speed
			angle = Random.Range(90.0f, 270.0f);
			dx = Mathf.Cos((angle/180.0f)*Mathf.PI);
			dy = Mathf.Sin((angle/180.0f)*Mathf.PI);
			moveSpeed = Random.Range (randomSpeedMin, randomSpeedMax);
		}
		// when coliide left screen side
		else if (pos.x - radius < -widthOrtho && dx < 0) {
			dx = -dx;

			// random a direction and a speed
			angle = Random.Range(-90.0f, 90.0f);
			dx = Mathf.Cos((angle/180.0f)*Mathf.PI);
			dy = Mathf.Sin((angle/180.0f)*Mathf.PI);
			moveSpeed = Random.Range (randomSpeedMin, randomSpeedMax);
		}
		// when collide low screen side
		else if (pos.y - radius < -Camera.main.orthographicSize && dy < 0) {
			dy = -dy;

			// random a direction and a speed
			angle = Random.Range(0.0f, 180.0f);
			dx = Mathf.Cos((angle/180.0f)*Mathf.PI);
			dy = Mathf.Sin((angle/180.0f)*Mathf.PI);
			moveSpeed = Random.Range (randomSpeedMin, randomSpeedMax);
		}
		// when collide middle screen horizontal line
		else if (pos.y + radius > 0 && dy > 0) {
			dy = -dy;

			// random a direction and a speed
			angle = Random.Range(270.0f, 360.0f);
			dx = Mathf.Cos((angle/180.0f)*Mathf.PI);
			dy = Mathf.Sin((angle/180.0f)*Mathf.PI);
			moveSpeed = Random.Range (randomSpeedMin, randomSpeedMax);
		}

		move = new Vector3 (speedMul * moveSpeed * Time.deltaTime * dx, speedMul * moveSpeed * Time.deltaTime * dy, 0);
		pos += move;
		transform.position = pos;

	}
}
