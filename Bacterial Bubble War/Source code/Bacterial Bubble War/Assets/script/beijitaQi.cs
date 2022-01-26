using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beijitaQi : MonoBehaviour {

	public float timer = 3;
	float auraTime = 0;

	int correctLayer;

	// Use this for initialization
	void Start () {
		correctLayer = gameObject.layer;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.Find ("aura").gameObject.activeSelf) {
			auraTime -= Time.deltaTime;
			if (auraTime <= 0) {
				transform.Find ("aura").gameObject.SetActive (false);
				gameObject.layer = correctLayer;
			}
		}

		if (Input.GetMouseButtonDown (1)) {
			gameObject.layer = 10;
			auraTime = timer;
			transform.Find ("aura").gameObject.SetActive (true);
		}

		
	}
}
