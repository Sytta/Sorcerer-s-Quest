using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScriptHelp : MonoBehaviour {
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

	public void loadMenu() {
		AudioSource.PlayClipAtPoint (buttonPress, new Vector3(0.0f,0.0f,0.0f));
		Application.LoadLevel ("Menu");
	}

	public void nextPage() {
		GameObject.Find ("TextStory").GetComponent<Text> ().enabled = false;
		GameObject.Find ("TextControls").GetComponent<Text> ().enabled = false;
		GameObject.Find ("next_btn").GetComponent<Button> ().enabled = false;
		GameObject.Find ("arrow_left").GetComponent<Image> ().enabled = false;
		GameObject.Find ("arrow_right").GetComponent<Image> ().enabled = false;
		GameObject.Find ("arrow_up").GetComponent<Image> ().enabled = false;
		GameObject.Find ("arrow_down").GetComponent<Image> ().enabled = false;
		GameObject.Find ("key1").GetComponent<Image> ().enabled = false;
		GameObject.Find ("key2").GetComponent<Image> ().enabled = false;
		GameObject.Find ("key3").GetComponent<Image> ().enabled = false;
		GameObject.Find ("key4").GetComponent<Image> ().enabled = false;
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
		GameObject.Find ("TextControls").GetComponent<Text> ().enabled = true;
		GameObject.Find ("next_btn").GetComponent<Button> ().enabled = true;
		GameObject.Find ("arrow_left").GetComponent<Image> ().enabled = true;
		GameObject.Find ("arrow_right").GetComponent<Image> ().enabled = true;
		GameObject.Find ("arrow_up").GetComponent<Image> ().enabled = true;
		GameObject.Find ("arrow_down").GetComponent<Image> ().enabled = true;
		GameObject.Find ("key1").GetComponent<Image> ().enabled = true;
		GameObject.Find ("key2").GetComponent<Image> ().enabled = true;
		GameObject.Find ("key3").GetComponent<Image> ().enabled = true;
		GameObject.Find ("key4").GetComponent<Image> ().enabled = true;
		GameObject.Find ("TextPowerUps").GetComponent<Text> ().enabled = false;
		GameObject.Find ("TextPowerUps2").GetComponent<Text> ().enabled = false;
		GameObject.Find ("previous_btn").GetComponent<Button> ().enabled = false;
		GameObject.Find ("money_img").GetComponent<Image> ().enabled = false;
		GameObject.Find ("invincibility_img").GetComponent<Image> ().enabled = false;
		GameObject.Find ("stop_img").GetComponent<Image> ().enabled = false;
		GameObject.Find ("life_img").GetComponent<Image> ().enabled = false;
	}
}
