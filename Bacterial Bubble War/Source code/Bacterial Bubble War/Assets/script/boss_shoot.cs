using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_shoot : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject bulletPrefabNormal;
	public float fireDelay = 0.5f;
	float cooldownTimer = 0;

	float angle;
	float fanAngle = 15.0f;

	float fanBulletTime = 5.0f;
	float normalTime = 7.0f;
	int bulletModeTag = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		cooldownTimer -= Time.deltaTime;

		if (bulletModeTag == 0) {
			normalTime -= Time.deltaTime;
			if (normalTime <= 0) {
				bulletModeTag = 1;
				normalTime = 7.0f;
			}
		} else if (bulletModeTag == 1) {
			fanBulletTime -= Time.deltaTime;
			if (fanBulletTime <= 0) {
				bulletModeTag = 0;
				fanBulletTime = 5.0f;
			}
		}

		if (cooldownTimer <= 0) {
			// shooting
			cooldownTimer = fireDelay;

			if (bulletModeTag == 0) {

				angle = gameObject.transform.rotation.eulerAngles.z + 45.0f;
				Quaternion afterRotation1 = Quaternion.Euler (0, 0, angle);
				angle = gameObject.transform.rotation.eulerAngles.z - 45.0f;
				Quaternion afterRotation2 = Quaternion.Euler (0, 0, angle);

				Instantiate (bulletPrefabNormal, transform.position, afterRotation1);
				Instantiate (bulletPrefabNormal, transform.position, afterRotation2);
				Instantiate (bulletPrefabNormal, transform.position, transform.rotation);
			}

			else if (bulletModeTag == 1) {

				for (int i = 0; i < 10; i++) {
					angle = gameObject.transform.rotation.eulerAngles.z + fanAngle * 5 - fanAngle * i;
					Quaternion afterRotation = Quaternion.Euler (0, 0, angle);
					Instantiate (bulletPrefab, transform.position, afterRotation);
				}
			}
		}

	}
}
