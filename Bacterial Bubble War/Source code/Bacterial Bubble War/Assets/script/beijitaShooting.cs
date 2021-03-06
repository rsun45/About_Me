using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beijitaShooting : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject reboundBullet;
	public bool isDoubleShoot=false;
	public bool isReboundShoot = false;
	public float doubletime= 10f;
	public float reboundtime=10f;
	public float fireDelay = 0.25f;
	float cooldownTimer = 0;
	GameObject bullet;
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (Input.GetButton ("Fire1") && cooldownTimer <= 0) {
			// shooting
			cooldownTimer = fireDelay;

			Vector3 offset =transform.rotation * new Vector3 (0, 0, 0);
			Vector3 offset2 = transform.rotation * new Vector3(0.8f, 0.5f, 0);
			Vector3 offset3 = transform.rotation * new Vector3(-0.8f, 0.5f, 0);

			var mousePosition =Input.mousePosition;
			mousePosition.z=transform.position.z-Camera.main.transform.position.z;
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

			var q1 = Quaternion.FromToRotation (new Vector3(1f, 0.2f), mousePosition - transform.position);
			var q2 = Quaternion.FromToRotation (new Vector3(1f, -0.2f), mousePosition - transform.position);
			var q3 = Quaternion.FromToRotation (new Vector3(1f, 0.3f), mousePosition - transform.position);
			var q4 = Quaternion.FromToRotation (new Vector3(1f, -0.3f), mousePosition - transform.position);
			//Debug.Log ("sdsd"+mousePosition);
			//Debug.Log (q);
			if (isReboundShoot)
			{
				bullet = reboundBullet;
			}
			else
			{
				bullet = bulletPrefab;
			}
			if (!isDoubleShoot)
			{
				Instantiate(bullet, transform.position + offset, q1);
				Instantiate(bullet, transform.position + offset, q2);
				gameObject.GetComponent<score> ().gamescore--;

				AudioSource shootsound = GameObject.Find("AudioSource1").GetComponent<AudioSource>();
				shootsound.Play ();
			}
			else if(isDoubleShoot)
			{
				Instantiate(bullet, transform.position + offset2, q1);
				Instantiate(bullet, transform.position + offset3, q2);
				Instantiate(bullet, transform.position + offset2, q3);
				Instantiate(bullet, transform.position + offset3, q4);
				gameObject.GetComponent<score> ().gamescore--;
				AudioSource shootsound = GameObject.Find("AudioSource2").GetComponent<AudioSource>();
				shootsound.Play ();

			}

		}

		if (isDoubleShoot) {
			doubletime -= Time.deltaTime;

			if (doubletime <= 0) {
				isDoubleShoot = false;
			}
		}
		if (isReboundShoot) {
			reboundtime -= Time.deltaTime;

			if (reboundtime <= 0) {
				isReboundShoot = false;
			}
		}


	}
}
