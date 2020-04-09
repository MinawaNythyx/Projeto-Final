using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pedido : MonoBehaviour
{
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = go.GetComponent<ControladorDoJogo>().pedido;
    }
}