using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	bool volumeEnabled = false;

	public AudioClip buttonPress;

	public void StartGame() {
		AudioSource.PlayClipAtPoint (buttonPress, transform.position);
		Application.LoadLevel("Scene");
	}

	public void QuitGame() {
		AudioSource.PlayClipAtPoint (buttonPress, transform.position);
		Application.Quit();
	}

	public void enableDisableVolumeSlider() {
		AudioSource.PlayClipAtPoint (buttonPress, transform.position);
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
		AudioSource.PlayClipAtPoint (buttonPress, transform.position);
		Application.LoadLevel ("Credits");
	}

	public void loadMenu() {
		AudioSource.PlayClipAtPoint (buttonPress, transform.position);
		Application.LoadLevel ("Menu");
	}

	public void loadHelp() {
		AudioSource.PlayClipAtPoint (buttonPress, transform.position);
		Application.LoadLevel ("Help");
	}
}
