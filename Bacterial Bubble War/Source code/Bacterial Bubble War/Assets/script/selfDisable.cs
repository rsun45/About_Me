using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDisable : MonoBehaviour {

	float timer = 5f;
	// Use this for initialization


	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			gameObject.SetActive(false); 

			timer = 5f;
		}
	}
}