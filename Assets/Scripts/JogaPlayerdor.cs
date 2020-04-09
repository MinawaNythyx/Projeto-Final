using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogaPlayerdor : MonoBehaviour
{
    public int Dinheiro { get; set; }
    public int Vidas { get; set; }
    void Start()
    {
        Dinheiro = 0;
        Vidas = 3;
    }
    public override string ToString()
    {
        return "R$ " + Dinheiro;
    }
}
