using UnityEngine;
using System.Collections;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public bool bootsSelected = false;
    public int nbProtection;
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
        gunSelected = false;
    }
}
