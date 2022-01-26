using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamehaCtr : MonoBehaviour {

	public float timer = 10f;
	private float kamehaTime = 0;
	// Use this for initialization
	void Start () {
		//transform.Find ("kameha").gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.Find ("kameha").gameObject.activeSelf) {
			kamehaTime -= Time.deltaTime;
			if (kamehaTime <= 0) {
				transform.Find ("kameha").gameObject.SetActive (false);
				this.GetComponent<PlayerMovement> ().enabled = true;
				this.GetComponent<playerShooting> ().enabled = true;
				this.GetComponent<teleport> ().enabled = true;
			}
		}

		if (Input.GetKeyDown ("space")) {
			this.GetComponent<PlayerMovement> ().enabled = false;
			this.GetComponent<playerShooting> ().enabled = false;
			this.GetComponent<teleport> ().enabled = false;

			transform.Find ("kameha").gameObject.SetActive (true);
			kamehaTime = timer;
		}

		var mousePosition =Input.mousePosition;
		mousePosition.z=transform.position.z-Camera.main.transform.position.z;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		var q = Quaternion.FromToRotation (new Vector3(0.5f, 0.5f), mousePosition - transform.position);

		transform.Find ("kameha").rotation = q;
		
	}
}
