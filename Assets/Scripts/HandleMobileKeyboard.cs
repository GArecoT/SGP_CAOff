using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HandleMobileKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject chatContainer;
    public bool focused = false;
    // Start is called before the first frame update
    //
    void Awake()
    {
        TouchScreenKeyboard.Android.consumesOutsideTouches = false;
    }
    void Start()
    {
        /*        chatContainer.transform.localPosition = new Vector3(73.5614f, 400, 0); */
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

    // Update is called once per frame
    void Update()
    {
        Debug.Log(TouchScreenKeyboard.Android.consumesOutsideTouches);
        if (TouchScreenKeyboard.visible)
        {
            chatContainer.transform.localPosition = new Vector3(73.5614f, 400, 0);
            inputField.Select();
            if (!inputField.isFocused)
                chatContainer.transform.localPosition = new Vector3(73.5614f, 29.50944f, 68.98297f);

        }
        // if (!inputField.isFocused)
        //     chatContainer.transform.localPosition = new Vector3(73.5614f, 29.50944f, 68.98297f);
        // if (!TouchScreenKeyboard.visible)
        // {
        //     chatContainer.transform.localPosition = new Vector3(73.5614f, 29.50944f, 68.98297f);
        // }
        //
    }
}
