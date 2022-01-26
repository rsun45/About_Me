using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundNum : MonoBehaviour {


	public Text roundtext;

	void Update(){

		roundtext.text ="Round : "+gameObject.GetComponent<autoSpawn>().roundnum.ToString();

	}
}
