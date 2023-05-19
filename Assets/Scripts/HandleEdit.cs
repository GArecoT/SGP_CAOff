using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandleEdit : MonoBehaviour
{
    public GameObject messageContainer,
                      editButton;
    public TMP_Text keyboardText;
    TMP_InputField inputField;
    Button button;
    GameObject parentObject;

    public Vector3 position;
    public Vector2 size;
    public bool editMode = false;

    public void Update()
    {
        position = messageContainer.GetComponent<RectTransform>().anchoredPosition;
        size = messageContainer.GetComponent<RectTransform>().sizeDelta;

        editButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(position.x - size.x - 35, editButton.GetComponent<RectTransform>().anchoredPosition.y, 0);

        if (editMode)
        {
            parentObject = messageContainer.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
            if (parentObject != null)
            {
                inputField = parentObject.transform.Find("InputField (TMP)").GetComponent<TMP_InputField>();
                button = parentObject.transform.Find("Button").GetComponent<Button>();
                if (inputField != null && button != null)
                {
                    Debug.Log("FOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOI");
                    keyboardText.text = inputField.text;
                    button.onClick.AddListener(() => editMode = false);
                }
            }
        }
    }

    public void edit()
    {
        editMode = true;
    }

}
