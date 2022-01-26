using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDoubleShoot : MonoBehaviour {

	public GameObject bulletPrefab;
	public  Vector3 bulletOffset1 = new Vector3 (1f, 0.5f, 0);
	public  Vector3 bulletOffset2 = new Vector3 (-1f, 0.5f, 0);
	public float fireDelay = 0.5f;
	float cooldownTimer = 0;

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (cooldownTimer <= 0) {
			// shooting
			cooldownTimer = fireDelay;

			Vector3 offset1 =transform.rotation * bulletOffset1;
			Vector3 offset2 =transform.rotation * bulletOffset2;


			Instantiate (bulletPrefab, transform.position + offset1, transform.rotation);
			Instantiate (bulletPrefab, transform.position + offset2, transform.rotation);
		}


	}
}
