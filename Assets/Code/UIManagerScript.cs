using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	bool volumeEnabled = false;

	public AudioClip buttonPress;

	void Start() {
		GameObject.Find ("TextPowerUps").GetComponent<Text> ().enabled = false;
		GameObject.Find ("TextPowerUps2").GetComponent<Text> ().enabled = false;
		GameObject.Find ("previous_btn").GetComponent<Button> ().enabled = false;
		GameObject.Find ("money_img").GetComponent<Image> ().enabled = false;
		GameObject.Find ("invincibility_img").GetComponent<Image> ().enabled = false;
		GameObject.Find ("stop_img").GetComponent<Image> ().enabled = false;
		GameObject.Find ("life_img").GetComponent<Image> ().enabled = false;
	}

	public void StartGame() {
		AudioSource.PlayClipAtPoint (buttonPress, new Vector3(0.0f,0.0f,0.0f));
		Application.LoadLevel("Scene");

		AudioListener.volume = 1.0f;
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

	public void nextPage() {
		GameObject.Find ("TextStory").GetComponent<Text> ().enabled = false;
		GameObject.Find ("next_btn").GetComponent<Button> ().enabled = false;
		GameObject.Find ("TextPowerUps").GetComponent<Text> ().enabled = true;
		GameObject.Find ("TextPowerUps2").GetComponent<Text> ().enabled = true;
		GameObject.Find ("previous_btn").GetComponent<Button> ().enabled = true;
		GameObject.Find ("money_img").GetComponent<Image> ().enabled = true;
		GameObject.Find ("invincibility_img").GetComponent<Image> ().enabled = true;
		GameObject.Find ("stop_img").GetComponent<Image> ().enabled = true;
		GameObject.Find ("life_img").GetComponent<Image> ().enabled = true;
	}

	public void previousPage() {
		GameObject.Find ("TextStory").GetComponent<Text> ().enabled = true;
		GameObject.Find ("next_btn").GetComponent<Button> ().enabled = true;
		GameObject.Find ("TextPowerUps").GetComponent<Text> ().enabled = false;
		GameObject.Find ("TextPowerUps2").GetComponent<Text> ().enabled = false;
		GameObject.Find ("previous_btn").GetComponent<Button> ().enabled = false;
		GameObject.Find ("money_img").GetComponent<Image> ().enabled = false;
		GameObject.Find ("invincibility_img").GetComponent<Image> ().enabled = false;
		GameObject.Find ("stop_img").GetComponent<Image> ().enabled = false;
		GameObject.Find ("life_img").GetComponent<Image> ().enabled = false;
	}
}
