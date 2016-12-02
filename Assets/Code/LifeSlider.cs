////////////////////////////////////////////////
// Copyright: Evil-Mind 2016
// --------------------------
// LifeSlider Customed by Yawen Hou
// --------------------------
// Example class that sets a fill amount value depending on the slider value.
// To use this, add this component to the image. Then on the slider, add an 
// "OnValueChanged" action, call to the "SetValue()" method of this class
// and attach the slider itself.
////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class LifeSlider : MonoBehaviour {

    private Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetValue(float value)
    {
        _image.fillAmount = value;
    }
}
