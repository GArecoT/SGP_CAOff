using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleModal : MonoBehaviour
{
    public GameObject modalLGPD;

    public void closeModal()
    {
        modalLGPD.gameObject.SetActive(false);
    }
    public void openModal()
    {
        modalLGPD.gameObject.SetActive(true);
    }


}
