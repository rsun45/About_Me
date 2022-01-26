using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordTimer : MonoBehaviour {


	public float swordtime = 10f;

	
	// Update is called once per frame
	void Update () {

		if (gameObject.active) {
			swordtime -= Time.deltaTime;

			if (swordtime <= 0) {
				gameObject.SetActive (false);
			}
		}
			

	}
}
