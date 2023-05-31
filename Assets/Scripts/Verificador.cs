using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verificador : MonoBehaviour
{
    HandleNextStep mensagens;
    HandleTransfer BaloesDeFalas;
    string textoFiltrado;
    bool apenasLetras = false;
    private char[] numeros =
    {
        '[', ']', '{', '}', '!', '@', '#', '$', '%', '&', '*', '(', ')', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
    };
    private char[] letras = { '[', ']', '{', '}', '!', '@', '#', '$', '%', '&', '*', '(', ')',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    void Start()
    {
        mensagens = FindObjectOfType<HandleNextStep>();
        BaloesDeFalas = FindObjectOfType<HandleTransfer>();
    }

    public void VerificarPorIndex()
    {
        switch (mensagens.IrisIndex)
        {
            case 1:
                apenasLetras = true;
                break;
            case 2:
                apenasLetras = false;
                break;
        }
    }
    
    void OnGUI()
    {
        if (apenasLetras)
        {
            string newString = GUILayout.TextField(textoFiltrado);
            if (newString.IndexOfAny(numeros) < 0)
            {

                textoFiltrado = newString;
            }
        }
        else
        {

            string newString = GUILayout.TextField(textoFiltrado);
            if (newString.IndexOfAny(letras) < 0)
            {

                textoFiltrado = newString;
            }
        }
    }
    void Update()
    {
        Debug.Log(apenasLetras);
        //VerificarPorIndex();
    }
}
