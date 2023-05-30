using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleModalCreate : MonoBehaviour
{
    public GameObject modalLGPD;
    public void Start()
    {
        modalLGPD = Instantiate(modalLGPD, Vector3.zero, Quaternion.identity);
        modalLGPD.gameObject.SetActive(false);
    }
    public void closeModal()
    {
        modalLGPD.gameObject.SetActive(false);
    }
    public void openModal()
    {
        modalLGPD.gameObject.SetActive(true);
    }


}
