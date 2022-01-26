using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class score : MonoBehaviour {

	public int gamescore =0;
	public Text scoretext;

	void Update(){

		scoretext.text ="SCORE : "+gamescore.ToString();

	}
}
