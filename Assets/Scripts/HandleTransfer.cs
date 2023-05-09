using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HandleTransfer : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TMP_InputField inputField;

    public GameObject samplePrefab;
    public GameObject sampleObject;
    public GameObject parentObject;

    public bool clicked = false;

    Vector3 posicaoDialogo;
    TMPro.TextMeshProUGUI teste;
    public void Start()
    {

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
            //Limpar input
            inputField.text = string.Empty;
        }

        // sampleObject.GetComponent<RectTransform>().anchoredPosition.Set(0, 0);
        // sampleObject.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
        // sampleObject.GetComponent<RectTransform>().anchorMin = new Vector2(1, 0.5f);
        // sampleObject.GetComponent<RectTransform>().pivot = new Vector2(1, 0.5f);
    }

    // public void StoreName(){
    //     textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text  = inputField.GetComponent<TMPro.TextMeshProUGUI>().text;
    /* } */
}

