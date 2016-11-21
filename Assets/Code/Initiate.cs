using UnityEngine;
using System.Collections;

public class Initiate {
    //Takes in parameter the next scene, the color of the transition, and the transition time
    public static void Fade(int scene, Color col, float fadeTime) {
        GameObject init = new GameObject();
        init.name = "LevelChange";
        init.AddComponent<LevelChange>();
        LevelChange scr = init.GetComponent<LevelChange>();
        scr.fadeTime = fadeTime;
        scr.fadeScene = scene;
        scr.fadeColor = col;
        scr.start = true;
    }

}
