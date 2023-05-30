using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandleEdit : MonoBehaviour
{
    public GameObject messageContainer,
                      editButton,
                      scriptObject,
                      buttonObject;
    public TMP_Text keyboardText;
    TMP_InputField inputField;
    Button button;
    public int irisIndex,
               irisIndexBKP;
    public Vector3 position;
    public Vector2 size;
    HandleNextStep handleNextStep;
    bool editMode = false;

    void Start()
    {
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
        button = GameObject.Find("Botao Enviar").GetComponent<Button>();
        scriptObject = GameObject.Find("HandleNextStep");
        handleNextStep = scriptObject.GetComponent<HandleNextStep>();
        handleNextStep.editMode = false;
        irisIndex = handleNextStep.IrisIndex;
        irisIndexBKP = irisIndex;
    }

    public void Update()
    {
        position = messageContainer.GetComponent<RectTransform>().anchoredPosition;
        size = messageContainer.GetComponent<RectTransform>().sizeDelta;

        editButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(position.x - size.x - 35, editButton.GetComponent<RectTransform>().anchoredPosition.y, 0);

        if (handleNextStep.editMode && editMode)
        {
            button.gameObject.GetComponentInChildren<TMP_Text>().text = "SALVAR";
            keyboardText.text = inputField.text;
            button.onClick.AddListener(() =>
            {
                if (handleNextStep.editMode && editMode)
                {
                    handleNextStep.editMode = false;
                    editMode = false;
                    handleNextStep.IrisIndex = irisIndexBKP;
                    button.gameObject.GetComponentInChildren<TMP_Text>().text = "ENVIAR";
                    handleNextStep.RemoveMasksEdit(irisIndexBKP + 1);
                    inputField.text = "";
                }
            });
        }
    }

    public void edit()
    {
        if (handleNextStep.editMode == false)
        {
            handleNextStep.editMode = true;
            editMode = true;
            handleNextStep.RemoveMasksEdit(irisIndex);
            inputField.text = keyboardText.text;
            irisIndexBKP = handleNextStep.IrisIndex;
            handleNextStep.IrisIndex = irisIndex;
        }
    }

}
