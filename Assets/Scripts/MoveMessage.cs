using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMessage : MonoBehaviour
{
    [SerializeField] GameObject button;
    private Button btn;
    // Start is called before the first frame update

    // Update is called once per frame
    //
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("JorgeAmado");
        btn = button.GetComponent<Button>();

        btn.onClick.AddListener(MoveUp);
    }
    void MoveUp()
    {
        transform.position += new Vector3(0, 30, 0);
    }
}
