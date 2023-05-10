using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleNextStep : MonoBehaviour
{
    public GameObject IrisFala_01,

                      IrisFala_02,
                      IrisFala_03,
                      IrisFala_04,
                      IrisFala_05,
                      IrisFala_06,
                      IrisFala_07,
                      IrisFala_08,
                      IrisFala_09;
    public GameObject parentObject;
    public int IrisIndex = 0;
    public TMP_InputField inputField;

    public void HandleIrisIndex()
    {
        if (IrisIndex < 9)
        {
            if (inputField.text != string.Empty)
            {
                if (IrisIndex == 0)
                {
                    CreateMessage(IrisFala_01, parentObject);
                }
                if (IrisIndex == 1)
                {
                    CreateMessage(IrisFala_02, parentObject);
                }
                if (IrisIndex == 2)
                {
                    CreateMessage(IrisFala_03, parentObject);
                }
                if (IrisIndex == 3)
                {
                    CreateMessage(IrisFala_04, parentObject);
                }
                if (IrisIndex == 4)
                {
                    CreateMessage(IrisFala_05, parentObject);
                }
                if (IrisIndex == 5)
                {
                    CreateMessage(IrisFala_06, parentObject);
                }
                if (IrisIndex == 6)
                {
                    CreateMessage(IrisFala_07, parentObject);
                }
                if (IrisIndex == 7)
                {
                    CreateMessage(IrisFala_08, parentObject);
                }
                if (IrisIndex == 8)
                {
                    CreateMessage(IrisFala_09, parentObject);
                }
                IrisIndex++;
            }
        }
    }
    public void CreateMessage(GameObject gameObject, GameObject parent)
    {
        gameObject = Instantiate(gameObject, Vector3.zero, Quaternion.identity, parent.transform);
        inputField.text = string.Empty;

    }

}
