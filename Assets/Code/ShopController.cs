using UnityEngine;
using System.Collections;

public class ShopController : MonoBehaviour {

    public bool openShop = true;

    public void OpenShop()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        openShop = false;
    }
}
