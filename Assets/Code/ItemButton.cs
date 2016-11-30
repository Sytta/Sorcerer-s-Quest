using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

    public PlayerController player;

    public Text nameText;
    public Text description;
    public Text costText;
    public int cost;

    //private AudioSource source;

	// Use this for initialization
	void Start ()
    {
        //source = GetComponent<AUdioSource>();
	}

    public void OnClick()
    {
        if (player.score >= cost)
        {
            player.score -= cost;
            player.texteScore.text = "Score : " + player.score;

            if (name == "Boots")
            {
                GlobalControl.Instance.bootsSelected = true;
            }
            else if (name == "Gun")
            {
                GlobalControl.Instance.gunSelected = true;
            }
            else if (name == "Protection")
            {
                GlobalControl.Instance.nbProtectionSelected++;
            }
        }
    }
	
	// Update is called once per frame. Disable the button if the player does not have enought money
	void Update ()
    {
        if (player.score < cost)
        {
            GameObject.Find(name).GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find(name).GetComponent<Button>().interactable = true;
        }

    }
}
