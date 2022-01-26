using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swardRotation : MonoBehaviour {

	public float rotAngle = 10f;
	
	// Update is called once per frame
	void Update () {
		Quaternion currentRot = transform.localRotation;
	
		float zAngle = currentRot.eulerAngles.z + rotAngle;
		if (zAngle >= 360) {
			zAngle -= 360;
		}

		//if (zAngle >= 0 && zAngle < 90) {
		float x = -1*3*(Mathf.Cos(zAngle*Mathf.PI/180));
		float y = -1*3*(Mathf.Sin(zAngle*Mathf.PI/180));
		Vector3 pos = new Vector3 (x, y, 0);
		transform.localPosition = pos;
		//}

		transform.rotation = Quaternion.Euler (0, 0, zAngle);
	}
}
