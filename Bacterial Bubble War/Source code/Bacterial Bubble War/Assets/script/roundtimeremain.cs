using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundtimeremain : MonoBehaviour {

	public Text roundtimetext;

	void Update(){

		roundtimetext.text ="Time Remain : "+((int)(gameObject.GetComponent<autoSpawn>().cooldownTimer)).ToString() + "s";

	}
}
