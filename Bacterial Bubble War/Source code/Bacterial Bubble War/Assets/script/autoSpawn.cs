using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class autoSpawn : MonoBehaviour
{
    public GameObject crazy;
    public GameObject lazy;
    public GameObject gun;
    public GameObject fort;
	public GameObject boss;
    public float spawnDelay = 5f;
    public float cooldownTimer = 2f;
    public int roundnum = 0;

	public GameObject bossWarning;
    
    // Use this for initialization
    void Update()
    {

        float posy = Camera.main.orthographicSize;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float posx = Camera.main.orthographicSize * screenRatio;



        cooldownTimer -= Time.deltaTime;
		if (cooldownTimer <= 0) {

			roundnum++;
			cooldownTimer = spawnDelay;
			if((roundnum%5)!=0){

				// round 1
				if ((roundnum % 5) == 1) {
					// random a corner
					float randomy = Random.Range (posy, posy + 3f);
					float randomx = Random.Range (posx, posx + 3f);
					float signal = getSignal ();
					float signal2 = getSignal ();
					//crazy
					for (int i = 0; i < roundnum; i++) {
						float randomAngle = Random.Range (-180f, 180f);
						Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
						Instantiate (crazy, offset, Quaternion.Euler (0, 0, randomAngle));
						cooldownTimer += 1.5f;
					}
					//lazy
					for (int i = 0; i < roundnum; i++) {
						float randomAngle = Random.Range (-180f, 180f);
						Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
						Instantiate (lazy, offset, Quaternion.Euler (0, 0, randomAngle));
						cooldownTimer += 1.5f;
					}
					//gun
					for (int i = 0; i < roundnum; i++) {
						float randomAngle = Random.Range (-180f, 180f);
						Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
						Instantiate (gun, offset, Quaternion.Euler (0, 0, randomAngle));
						cooldownTimer += 1.5f;
					}
					//fort
					for (int i = 0; i < (roundnum / 10); i++) {
						float randomx1 = Random.Range (posx -2f, posx -1f);
						float randomy1 = Random.Range (posy -2f, posy -1f);
						float randomAngle = Random.Range (-180f, 180f);
						Vector3 offset = new Vector3 (signal * randomx1, signal2 * randomy1, 0);
						Instantiate (fort, offset, Quaternion.Euler (0, 0, randomAngle));
						cooldownTimer += 1.5f;
					}
				}

				// round 2
				if ((roundnum % 5) == 2) {
					for (int j = 0; j < 2; j++) {
						// random a corner
						float randomy = Random.Range (posy, posy + 3f);
						float randomx = Random.Range (posx, posx + 3f);
						float signal = getSignal ();
						float signal2 = getSignal ();
						//crazy
						for (int i = 0; i < (roundnum/2 + 1); i++) {
							float randomAngle = Random.Range (-180f, 180f);
							Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
							Instantiate (crazy, offset, Quaternion.Euler (0, 0, randomAngle));
							cooldownTimer += 1.5f;
						}
						//lazy
						for (int i = 0; i < (roundnum/2 + 1); i++) {
							float randomAngle = Random.Range (-180f, 180f);
							Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
							Instantiate (lazy, offset, Quaternion.Euler (0, 0, randomAngle));
							cooldownTimer += 1.5f;
						}
						//gun
						for (int i = 0; i < (roundnum/2 + 1); i++) {
							float randomAngle = Random.Range (-180f, 180f);
							Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
							Instantiate (gun, offset, Quaternion.Euler (0, 0, randomAngle));
							cooldownTimer += 1.5f;
						}
						//fort
						for (int i = 0; i < (roundnum / 10); i++) {
							float randomx1 = Random.Range (posx -2f, posx -1f);
							float randomy1 = Random.Range (posy -2f, posy -1f);
							float randomAngle = Random.Range (-180f, 180f);
							Vector3 offset = new Vector3 (signal * randomx1, signal2 * randomy1, 0);
							Instantiate (fort, offset, Quaternion.Euler (0, 0, randomAngle));
							cooldownTimer += 1.5f;
						}
					}
				}

				// round 3
				if ((roundnum % 5) == 3) {
					for (int j = 0; j < 3; j++) {
						// random a corner
						float randomy = Random.Range (posy, posy + 3f);
						float randomx = Random.Range (posx, posx + 3f);
						float signal = getSignal ();
						float signal2 = getSignal ();
						//crazy
						for (int i = 0; i < (roundnum/3 + 1); i++) {
							float randomAngle = Random.Range (-180f, 180f);
							Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
							Instantiate (crazy, offset, Quaternion.Euler (0, 0, randomAngle));
							cooldownTimer += 1.5f;
						}
						//lazy
						for (int i = 0; i < (roundnum/3 + 1); i++) {
							float randomAngle = Random.Range (-180f, 180f);
							Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
							Instantiate (lazy, offset, Quaternion.Euler (0, 0, randomAngle));
							cooldownTimer += 1.5f;
						}
						//gun
						for (int i = 0; i < (roundnum/3 + 1); i++) {
							float randomAngle = Random.Range (-180f, 180f);
							Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
							Instantiate (gun, offset, Quaternion.Euler (0, 0, randomAngle));
							cooldownTimer += 1.5f;
						}
						//fort
						for (int i = 0; i < (roundnum / 10); i++) {
							float randomx1 = Random.Range (posx -2f, posx -1f);
							float randomy1 = Random.Range (posy -2f, posy -1f);
							float randomAngle = Random.Range (-180f, 180f);
							Vector3 offset = new Vector3 (signal * randomx1, signal2 * randomy1, 0);
							Instantiate (fort, offset, Quaternion.Euler (0, 0, randomAngle));
							cooldownTimer += 1.5f;
						}
					}
				}

				// round 4
				if ((roundnum % 5) == 4) {
					//crazy
					for (int i = 0; i < roundnum; i++) {
						float randomy = Random.Range (posy, posy + 3f);
						float randomx = Random.Range (posx, posx + 3f);
						float randomAngle = Random.Range (-180f, 180f);
						float signal = getSignal ();
						float signal2 = getSignal ();
						Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
						Instantiate (crazy, offset, Quaternion.Euler (0, 0, randomAngle));
						cooldownTimer += 1.5f;
					}
					//lazy
					for (int i = 0; i < roundnum; i++) {
						float randomy = Random.Range (posy - 2f, posy);
						float randomx = Random.Range (posx - 2f, posx);
						float randomAngle = Random.Range (-180f, 180f);
						float signal = getSignal ();
						float signal2 = getSignal ();
						Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
						Instantiate (lazy, offset, Quaternion.Euler (0, 0, randomAngle));
						cooldownTimer += 1.5f;
					}
					//gun
					for (int i = 0; i < roundnum; i++) {
						float randomy = Random.Range (posy, posy + 3f);
						float randomx = Random.Range (posx, posx + 3f);
						float randomAngle = Random.Range (-180f, 180f);
						float signal = getSignal ();
						float signal2 = getSignal ();
						Vector3 offset = new Vector3 (signal * randomx, signal2 * randomy, 0);
						Instantiate (gun, offset, Quaternion.Euler (0, 0, randomAngle));
						cooldownTimer += 1.5f;
					}
					//fort
					for (int i = 0; i < (roundnum / 10); i++) {
						float randomx1 = Random.Range (posx -2f, posx -1f);
						float randomy1 = Random.Range (posy -2f, posy -1f);
						float randomAngle = Random.Range (-180f, 180f);
						float signal = getSignal ();
						float signal2 = getSignal ();
						Vector3 offset = new Vector3 (signal * randomx1, signal2 * randomy1, 0);
						Instantiate (fort, offset, Quaternion.Euler (0, 0, randomAngle));
						cooldownTimer += 1.5f;
					}
				}
		}
			if ((roundnum % 5) == 0) {
				// disable warning


				float randomAngle = Random.Range(-180f, 180f);
				Vector3 offset = new Vector3 (0f, -posy+2f, 0f);
				GameObject boss1=Instantiate(boss, offset, Quaternion.Euler(0, 0, randomAngle));
				boss1.GetComponent<DamageHandler> ().health = roundnum * 2;
				cooldownTimer = (float) (roundnum * 4);
			}



        }

		// go to next round if no enemy left
		if (roundnum != 0&&cooldownTimer>6f) {
			if (GameObject.FindWithTag ("enemy") == null) {
				cooldownTimer = 6.0f;


			}
		}
		if ((roundnum % 5 == 4)&&cooldownTimer<6f&&cooldownTimer>2f&&(!bossWarning.activeSelf)) {
			// enable warning
			bossWarning.SetActive(true);
			AudioSource sound = GameObject.Find("warningsound").GetComponent<AudioSource>();
			sound.Play ();

		}

    }

    float getSignal()
    {
        float signal = -1f;
        int tester = Random.Range(1, 10);
        if (tester % 2 == 0)
        {
            signal = -1f;
        }
        else
        {
            signal = 1f;
        }

        return signal;

    }
}
