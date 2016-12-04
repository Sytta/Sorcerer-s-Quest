using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	bool volumeEnabled = false;

	public AudioClip buttonPress;

	public void StartGame() {
		AudioSource.PlayClipAtPoint (buttonPress, new Vector3(0.0f,0.0f,0.0f));
		Application.LoadLevel("Scene");
	}

	public void QuitGame() {
		AudioSource.PlayClipAtPoint (buttonPress, new Vector3(0.0f,0.0f,0.0f));
		Application.Quit();
	}

	public void loadCredits() {
		AudioSource.PlayClipAtPoint (buttonPress, new Vector3(0.0f,0.0f,0.0f));
		Application.LoadLevel ("Credits");
	}

	public void loadMenu() {
		AudioSource.PlayClipAtPoint (buttonPress, new Vector3(0.0f,0.0f,0.0f));
		Application.LoadLevel ("Menu");
	}

	public void loadHelp() {
		AudioSource.PlayClipAtPoint (buttonPress, new Vector3(0.0f,0.0f,0.0f));
		Application.LoadLevel ("Help");
	}
}
