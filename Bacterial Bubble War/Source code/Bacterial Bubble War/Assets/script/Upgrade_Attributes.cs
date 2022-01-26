using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_Attributes : MonoBehaviour {

	public Text hp;
	public Text speed;
	public Text buffTime;
	public Text fireDelay;
	public Text currentScore;

	public Text HP_button;
	public Text speed_button;
	public Text buffTime_button;
	public Text fireDelay_button;

	// Use this for initialization
	void Start () {
		//initial text area
		hp.text = "HEALTH POINTS: "+ PlayerPrefs.GetInt("hp");
		speed.text = "INITIAL SPEED: " + PlayerPrefs.GetFloat ("playerMoveSpeed").ToString ();
		buffTime.text = "BUFF DURATION: " + PlayerPrefs.GetFloat ("buffTime").ToString ();
		fireDelay.text = "FIRE DELAY: " + PlayerPrefs.GetFloat ("fireDelay").ToString ();
		currentScore.text = "TOTAL SCORES: " + PlayerPrefs.GetInt ("totalScore").ToString ();
	}

	public void HP_Upgrade(){
		int scores = PlayerPrefs.GetInt ("totalScore");
		if (scores >= 1000 && PlayerPrefs.GetInt ("hp") < 5) {
			PlayerPrefs.SetInt ("hp", PlayerPrefs.GetInt ("hp") + 1);

			scores -= 1000;
			PlayerPrefs.SetInt ("totalScore", scores);
			Start ();
		} else if (scores < 1000) {
			HP_button.text = "Nope!";
		} else if (PlayerPrefs.GetInt ("hp") >= 5) {
			HP_button.text = "Max!";
		}

	}

	public void SP_Upgrade(){
		int scores = PlayerPrefs.GetInt ("totalScore");
		if (scores >= 1000 && PlayerPrefs.GetFloat ("playerMoveSpeed") < 20.0f) {
			PlayerPrefs.SetFloat ("playerMoveSpeed", PlayerPrefs.GetFloat ("playerMoveSpeed") + 1.0f);

			scores -= 1000;
			PlayerPrefs.SetInt ("totalScore", scores);
			Start ();
		} else if (scores < 1000) {
			speed_button.text = "Nope!";
		} else if (PlayerPrefs.GetFloat ("playerMoveSpeed") >= 20.0f) {
			speed_button.text = "Max!";
		}
	}

	public void BT_Upgrade(){
		int scores = PlayerPrefs.GetInt ("totalScore");
		if (scores >= 1000 && PlayerPrefs.GetFloat ("buffTime") < 60.0f) {
			PlayerPrefs.SetFloat ("buffTime", PlayerPrefs.GetFloat ("buffTime") + 1.0f);

			scores -= 1000;
			PlayerPrefs.SetInt ("totalScore", scores);
			Start ();
		} else if (scores < 1000) {
			buffTime_button.text = "Nope!";
		} else if (PlayerPrefs.GetFloat ("buffTime") >= 60.0f) {
			buffTime_button.text = "Max!";
		}
	}

	public void FD_Upgrade(){
		int scores = PlayerPrefs.GetInt ("totalScore");
		if (scores >= 1000 && PlayerPrefs.GetFloat ("fireDelay") > 0.15f) {
			PlayerPrefs.SetFloat ("fireDelay", PlayerPrefs.GetFloat ("fireDelay") - 0.05f);

			scores -= 1000;
			PlayerPrefs.SetInt ("totalScore", scores);
			Start ();
		} else if (scores < 1000) {
			fireDelay_button.text = "Nope!";
		} else if (PlayerPrefs.GetFloat ("fireDelay") <= 0.15f) {
			fireDelay_button.text = "Max!";
		}
	}
}
