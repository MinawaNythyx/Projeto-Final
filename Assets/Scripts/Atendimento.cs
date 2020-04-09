using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atendimento : MonoBehaviour
{
    public string atendendo;
    // Start is called before the first frame update
    void Start()
    {
        atendendo = "Vazio";
    }
    public void ChangeAtendendo(string status)
    {
        atendendo = status;
    }
    public string ReturnAtendendo()
    {
        return atendendo;
    }
}