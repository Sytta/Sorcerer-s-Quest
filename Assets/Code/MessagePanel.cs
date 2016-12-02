using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessagePanel : MonoBehaviour {

    [SerializeField]
    private Text message;

    public bool openPanel = true;

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "Scene")
            message.text = "You succeeded to collect 10 coins. Now it's time to buy equipments with the coins you collected! The items are actived at the beginning of the game, and they are only valid for one level! Press \"Buy\" button to purchase an item.";
        else if (SceneManager.GetActiveScene().name == "Scene_LV2")
            message.text = "You succeeded to collect 15 coins. Now it's time to buy equipments with the coins you collected! The items are actived at the beginning of the game, and they are only valid for one level! Press \"Buy\" button to purchase an item.";
        else if (SceneManager.GetActiveScene().name == "Scene_LV3")
            message.text = "You succeeded to collect 20 coins. Bravo, you have won the game! Press \"OK\" to return to the menu.";
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        openPanel = false;
    }
}
