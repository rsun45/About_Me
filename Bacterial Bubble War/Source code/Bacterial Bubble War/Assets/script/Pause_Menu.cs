using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Pause_Menu : MonoBehaviour {

	public GameObject pauseMenu;
	public Text pauseCounter;

	int flag = 0;

	public void PauseGame() {
		Time.timeScale = 0f;
		pauseMenu.SetActive (true);
	}

	public void ResumeGame() {
		StartCoroutine(countDown());
	}


	public void BackHome(string sceneName){
		Time.timeScale = 1f;
		SceneManager.LoadScene (sceneName);	
	}
		
	IEnumerator countDown(){
		Time.timeScale = 0.00001f;
		pauseCounter.text = "3";
		yield return new WaitForSeconds(Time.timeScale);
		pauseCounter.text = "2";
		yield return new WaitForSeconds(Time.timeScale);
		pauseCounter.text = "1";
		yield return new WaitForSeconds(Time.timeScale);
		pauseCounter.text = "";
		flag = 1;

	}
		
	void Update(){
		if (flag == 1  && Time.timeScale != 1f) {
			pauseMenu.SetActive (false);
			Time.timeScale = 1f;
			flag = 0;
		}
	}


}
