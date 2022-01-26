using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Volumn_Control : MonoBehaviour {




	float preVolum;

	void Start(){
		AudioListener.volume = PlayerPrefs.GetFloat ("volum");
		//		Debug.Log (SceneManager.GetSceneByName ("Setting_Screen").GetRootGameObjects()[4]);
		GameObject.Find ("Setting_UI").transform.Find ("Volumn_Slider").GetComponent<Slider> ().value = AudioListener.volume;


	}





	public void AdjustVolumn()
	{
		//Debug.Log (GameObject.Find ("Setting_UI").transform.Find ("Volumn_Slider").GetComponent<Slider> ().value);
		AudioListener.volume = GameObject.Find ("Setting_UI").transform.Find ("Volumn_Slider").GetComponent<Slider> ().value;
		if (AudioListener.volume > 0) {
			preVolum = AudioListener.volume;
		}
		PlayerPrefs.SetFloat ("volum", AudioListener.volume);

		//Debug.Log (PlayerPrefs.GetFloat ("volum"));

	}

	public void Mute()
	{	

		if (AudioListener.volume>0) {
			AudioListener.volume = 0;
			GameObject.Find ("Setting_UI").transform.Find ("Volumn_Slider").GetComponent<Slider> ().value = 0;

		} else {
			AudioListener.volume = preVolum;
			GameObject.Find ("Setting_UI").transform.Find ("Volumn_Slider").GetComponent<Slider> ().value = preVolum;
		}

		PlayerPrefs.SetFloat ("volum", AudioListener.volume);
	}


}

