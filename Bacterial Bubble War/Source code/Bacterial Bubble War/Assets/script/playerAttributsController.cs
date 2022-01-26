using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttributsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// initial or read attributes
		// move speed
		if (!PlayerPrefs.HasKey ("playerMoveSpeed")) {
			PlayerPrefs.SetFloat ("playerMoveSpeed", 8.0f);
		}
		gameObject.GetComponent<PlayerMovement>().moveSpeed = PlayerPrefs.GetFloat ("playerMoveSpeed");

		// player hp
		if (!PlayerPrefs.HasKey ("hp")) {
			PlayerPrefs.SetInt ("hp", 2);
		}
		gameObject.GetComponent<DamageHandler>().health = PlayerPrefs.GetInt ("hp");

		// buff time
		if (!PlayerPrefs.HasKey ("buffTime")) {
			PlayerPrefs.SetFloat ("buffTime", 10.0f);
		}


		// fire delay
		if (!PlayerPrefs.HasKey ("fireDelay")) {
			PlayerPrefs.SetFloat ("fireDelay", 0.5f);
		}
		gameObject.GetComponent<playerShooting>().fireDelay = PlayerPrefs.GetFloat ("fireDelay");

		// currentScore
		if (!PlayerPrefs.HasKey ("totalScore")) {
			PlayerPrefs.SetInt ("totalScore", 0);
		}

	}

}
