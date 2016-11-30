using UnityEngine;
using System.Collections;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public bool bootsSelected = false;
    public int nbProtectionSelected = 0;
    public bool gunSelected = false;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Reset()
    {
        bootsSelected = false;
        nbProtectionSelected = 0;
        gunSelected = false;
    }
}
