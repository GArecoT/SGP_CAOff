using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandleEdit : MonoBehaviour
{
    public GameObject messageContainer;
    public TMP_Text keyboardText;
    TMP_InputField inputField;

    GameObject parentObject;

    public void edit()
    {
        Debug.Log("cheiro de pneu queimado");
        parentObject = messageContainer.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        if (parentObject != null)
        {
            inputField = parentObject.transform.Find("InputField (TMP)").GetComponent<TMP_InputField>();
            if (inputField != null)
            {
                Debug.Log("FOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOI");
            }
            else
            {
                Debug.Log("não foi :( 2");
            }
        }
        else
        {
            Debug.Log("não foi :( 1");
        }
        keyboardText.text = inputField.text;
    }
}
