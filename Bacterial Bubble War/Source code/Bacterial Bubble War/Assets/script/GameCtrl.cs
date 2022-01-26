using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameCtrl : MonoBehaviour {



	void Start(){
		AudioListener.volume = PlayerPrefs.GetFloat ("volum");

	}


	public void LaodScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);	
	}



	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
			Application.Quit();

	}
}
