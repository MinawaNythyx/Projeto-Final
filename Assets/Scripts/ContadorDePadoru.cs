using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorDePadoru : MonoBehaviour
{
    public int Padoru { get; set; }
    public int TotalPadoru { get; set; }
    void Start()
    {
        TotalPadoru = 10;
        Padoru = 0;
    }
    public override string ToString()
    {
        return Padoru + "/" + TotalPadoru;
    }
}