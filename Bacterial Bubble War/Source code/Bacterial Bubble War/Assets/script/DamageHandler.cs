using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {

	public GameObject buff1;
	public GameObject buff2;
	public GameObject buff3;
	public GameObject buff4;

	public GameObject deathmenu;
	public GameObject pauseBtn;

	public bool isBoss = false;
	public int round = 1;
	public GameObject exploreLazy;
	public GameObject exploreFort;

	public float dropRate = 100.0f;

	public int health = 1;
	public float invulnPeriod = 0;

	public Renderer rend;
	public bool isDroppingBuff = false;

	float invulnTimer = 0;
	int correctLayer;

	float buffTime;


	// Use this for initialization
	void Start () {
		//get buff time
		if (!PlayerPrefs.HasKey ("buffTime")) {
			PlayerPrefs.SetFloat ("buffTime", 10.0f);
		}
		buffTime = PlayerPrefs.GetFloat ("buffTime");

		correctLayer = gameObject.layer;

		rend = GetComponent<Renderer> ();
		rend.enabled = true;


		if (gameObject.CompareTag("Player")){

			// player hp
			if (!PlayerPrefs.HasKey ("hp")) {
				PlayerPrefs.SetInt ("hp", 3);
			}
			gameObject.GetComponent<DamageHandler>().health = PlayerPrefs.GetInt ("hp");
			health=PlayerPrefs.GetInt ("hp");
			for (int i = 1; i <= 5; i++) {
				string pill = "health" + i;

				if (i <= health) {

					GameObject.Find (pill).SetActive (true);
				} else {
					GameObject.Find (pill).SetActive (false);
				}
			}
		}

	}

	//

	IEnumerator OnTriggerEnter2D(Collider2D target){
		// player layer(8) collide enemy layer(9)
		if (target.gameObject.layer == 9 && gameObject.layer == 8 ) {
			if (gameObject.CompareTag ("Player")) {
				string pill = "health" + health;
				//Debug.Log (transform.Find ("health5").gameObject);
				GameObject.Find (pill).SetActive (false);
			
			}
			health--;
			GameObject.Find("cellPlayer").GetComponent<score> ().gamescore += 3;


			target.GetComponent<DamageHandler> ().health -= 1;

			invulnTimer = invulnPeriod;
			gameObject.layer = 10;
			float seconds = 0.2f;

			for (float i = 0f; i < invulnPeriod; i += seconds) {
				//toggle renderer
				rend.enabled = !rend.enabled;

				//wait for a bit
				yield return new WaitForSeconds (seconds);
			}

			//make sure renderer is enabled when we exit
			rend.enabled = true;
		}

		// player sword collide enemy layer
		else if (gameObject.layer == 9 && target.gameObject.layer == 8 && !target.gameObject.CompareTag("playerBullet")) {
			health--;
			GameObject.Find("cellPlayer").GetComponent<score> ().gamescore += 2;

		}

		// player layer(8) collide buff layer(11)
		else if (gameObject.layer == 8 && gameObject.CompareTag("Player") && target.gameObject.layer == 11) {

			// check the buff type with oneHealth
			if (target.CompareTag ("oneHealth") && health < 5) {
				
				GameObject gb = GameObject.Find("pill");
				//1 is second child therefor would be level 2
				gb.transform.GetChild(health).gameObject.SetActive (true);
				health++;

			}
			// check the buff type with doubleBullet
			else if (target.CompareTag ("doubleBullet")) {
				gameObject.GetComponent<playerShooting>().isDoubleShoot=true;
				gameObject.GetComponent<playerShooting> ().doubletime = buffTime;

			}

			// check the buff type with rebound
			else if (target.CompareTag ("rebound")) {
				gameObject.GetComponent<playerShooting>().isReboundShoot=true;
				gameObject.GetComponent<playerShooting> ().reboundtime = buffTime;
			}

			// check the buff type with sword
			else if (target.CompareTag ("sword")) {
				transform.Find ("sword").gameObject.SetActive (true);
				transform.Find ("sword").gameObject.GetComponent<swordTimer> ().swordtime = buffTime;
				transform.Find ("sword2").gameObject.SetActive (true);
				transform.Find ("sword2").gameObject.GetComponent<swordTimer> ().swordtime = buffTime;

			}


			target.GetComponent<DamageHandler> ().health -= 1;

		}

	}
	
	// Update is called once per frame
	void Update () {
		invulnTimer -= Time.deltaTime;
		if (invulnTimer <= 0) {
			gameObject.layer = correctLayer;
		}
		if (health <= 0) {
			Die ();
		}
	}

	void Die(){

		if (isDroppingBuff == true) {
			bool dropRateResult = false;
			float randomNumber = Random.Range (0.0f, 100.0f);
			if (randomNumber > 0.0f && randomNumber < dropRate) {
				dropRateResult = true;
			}

			if (dropRateResult) {
				switch (Random.Range (1, 5)) {
				case 1:
					buff1.transform.localPosition = transform.position;
					Instantiate (buff1);
					break;
				case 2:
					buff2.transform.localPosition = transform.position;
					Instantiate (buff2);
					break;
				case 3:
					buff3.transform.localPosition = transform.position;
					Instantiate (buff3);
					break;
				case 4:
					buff4.transform.localPosition = transform.position;
					Instantiate (buff4);
					break;
				default:
					break;
				
				}
			}



		}

		// write the score
		if (gameObject.CompareTag ("Player")) {
			int score = gameObject.GetComponent<score> ().gamescore;
			//Debug.Log ("score: " + score);
			// if score > 0
			if (score > 0) {
				PlayerPrefs.SetInt ("totalScore", PlayerPrefs.GetInt ("totalScore") + score);
			}

			deathmenu.SetActive (true);
			pauseBtn.SetActive (false);
		
		}


		if (isBoss) {
			for (int i = 0; i < round * 5; i++) {
				Instantiate (exploreLazy, transform.position, transform.rotation);
			}
			for (int i = 0; i < round; i++) {
				float randomAngle = Random.Range (-180f, 180f);
				float randomOffset = Random.Range (-1f, 1f);
				Vector3 offset = new Vector3 (randomOffset, randomOffset, 0);
				Instantiate (exploreFort, transform.position + offset, Quaternion.Euler (0, 0, randomAngle));
			}
			Destroy (gameObject);
			//GameObject.Find ("cellPlayer").GetComponent<autoSpawn> ().cooldownTimer = 5f;
		}

		Destroy (gameObject);
	}
}
