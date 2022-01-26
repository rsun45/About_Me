using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySingleShoot : MonoBehaviour {

	public GameObject bulletPrefab;
	public  Vector3 bulletOffset = new Vector3 (0, 0.5f, 0);
	public float fireDelay = 0.5f;
	float cooldownTimer = 0;

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (cooldownTimer <= 0) {
			// shooting
			cooldownTimer = fireDelay;

			Vector3 offset =transform.rotation * bulletOffset;


			Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
		}


	}
}
