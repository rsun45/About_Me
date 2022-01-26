using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetMouseButtonDown (1)) {
			Vector3 mPos = Input.mousePosition;
			mPos.z = 10;
			transform.position = Camera.main.ScreenToWorldPoint(mPos);;
		}

	}

}
