using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandleMobileKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject chatContainer;
    private float timeSinceLastCall;

    void Awake()
    {
        TouchScreenKeyboard.Android.consumesOutsideTouches = false;
    }


    public void deixarTeclado()
    {
        TouchScreenKeyboard.Android.consumesOutsideTouches = false;
        inputField.Select();
    }
    //
    // public void subirTeclado()
    // {
    //     TouchScreenKeyboard.Android.consumesOutsideTouches = false;
    //     chatContainer.transform.localPosition = new Vector3(73.5614f, 400, 0);
    // }
    public void descerTeclado()
    {
        chatContainer.transform.localPosition = new Vector3(73.5614f, 29.50944f, 68.98297f);
    }

    void Update()
    {
        timeSinceLastCall += Time.deltaTime;

        if (timeSinceLastCall >= 1)
        {
            if (!inputField.isFocused)
                chatContainer.transform.localPosition = new Vector3(73.5614f, 29.50944f, 68.98297f); timeSinceLastCall = 0;   // reset timer back to 0
        }
        if (inputField.isFocused)
        {
            chatContainer.transform.localPosition = new Vector3(73.5614f, 400, 0);
            inputField.Select();


        }
    }
}
