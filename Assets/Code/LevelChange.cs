using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

    public bool start = false;
    public float fadeTime = 0.0f;
    public int fadeScene;
    public float alpha = 0.0f;
    public Color fadeColor;

    public bool isFadein = false;

    void OnGUI()
    {
        if (!start)
            return;

        //Create a new texture and draw accross the screen
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);        //set opacity of the layer
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, fadeColor);
        texture.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture); //Overlay the fadeout texture to fit the entire screen area

        if (isFadein)
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime); //Set texture to transparent
        else
            alpha = Mathf.Lerp(alpha, 1.1f, fadeTime * Time.deltaTime); //Set texture to opaque

        //If the screen is completely black, loadLevel
        if (alpha >= 1 && !isFadein)
        {
            SceneManager.LoadScene(fadeScene);
            DontDestroyOnLoad(gameObject); //Let the loading finish before destroying 
            isFadein = true;
        }
        else if (alpha <= 0 && isFadein)
        {
            Destroy(gameObject);
        }
    }

}
