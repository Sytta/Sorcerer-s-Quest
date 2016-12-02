using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

    public PlayerController player;

    public int cost;

    public AudioSource cashSpent;

    // Use this for initialization
    void Start ()
    {
        cashSpent.playOnAwake = false;
	}

    public void OnClick()
    {
        if (player.score >= cost)
        {
            player.score -= cost;
            player.texteScore.text = "Score : " + player.score;
            cashSpent.Play();

            if (name == "Buy Boots Button")
            {
                GlobalControl.Instance.bootsSelected = true;
            }
            else if (name == "Buy Gun Button")
            {
                GlobalControl.Instance.gunSelected = true;
            }
            else if (name == "Buy Shield Button")
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
