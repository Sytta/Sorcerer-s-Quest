using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {

	public void StartGame() {
		Application.LoadLevel("Scene");
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void ChangeVolume() {
		AudioListener.volume = GameObject.Find ("Volume Slider").GetComponent <Slider> ().value;;
	}
}
