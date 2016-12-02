using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	bool volumeEnabled = false;
	public Slider sliderVolume;

	public void StartGame() {
		Application.LoadLevel("Scene");
	}

	public void QuitGame() {
		Application.Quit();
	}

	public void enableDisableVolumeSlider() {
		if (volumeEnabled == false) {
			GameObject.Find ("Volume Slider").GetComponent <Slider> ().enabled = true;
			GameObject.Find ("Volume Slider").SetActive (true);
			//GameObject.Find ("Volume Slider").GetComponent<Slider> ().
			volumeEnabled = true;
		} 
		else {
			GameObject.Find ("Volume Slider").GetComponent <Slider> ().enabled = false;
			GameObject.Find ("Volume Slider").SetActive(false);
			//GameObject.Find ("Volume Slider").GetComponent <Slider> ().Rebuild();
			volumeEnabled = false;
		}
	}

	public void ChangeVolume() {
		AudioListener.volume = GameObject.Find ("Volume Slider").GetComponent <Slider> ().value;;
	}

	public void loadCredits() {
		Application.LoadLevel ("Credits");
	}

	public void loadMenu() {
		Application.LoadLevel ("Menu");
	}

	public void loadHelp() {
		Application.LoadLevel ("Help");
	}
}
