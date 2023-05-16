using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HandleTransfer : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TMP_InputField inputField;

    public GameObject sampleObject;
    public GameObject parentObject;
    HandleNextStep HandleIrisIndex;
    private void Awake()
    {
        HandleIrisIndex = FindObjectOfType<HandleNextStep>();
    }

    private void Start()
    {
        /* inputField.characterValidation = TMP_InputField.CharacterValidation.Name; */

    }
    public void AddObject()
    {
        if (inputField.text != string.Empty)
        {
            //Instaciar objeto
            sampleObject = Instantiate(sampleObject, Vector3.zero, Quaternion.identity, parentObject.transform);
            textDisplay = sampleObject.GetComponentInChildren<TextMeshProUGUI>();

            //Passar input para balão
            textDisplay.text = inputField.text;
            Canvas.ForceUpdateCanvases();
            textDisplay.transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false;
            textDisplay.transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = true;
        }
    }

}

