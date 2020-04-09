using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPupup : MonoBehaviour
{
    GameObject spawn;
    // Start is called before the first frame update
    public GameObject Panel;
    private void Start()
    {
        spawn = GameObject.Find("Spawn");
    }
    public void OpenPanel()
    {
        Debug.Log("Funcionou");
        if (Panel != null)
        {
            Debug.Log("Funcionou2");
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
    public void Cabelo()
    {
        spawn.GetComponent<ControladorDoJogo>().Cabelo();
        spawn.GetComponent<ControladorDoJogo>().Destroy();
    }
    public void Manicure()
    {
        spawn.GetComponent<ControladorDoJogo>().Manicure();
        spawn.GetComponent<ControladorDoJogo>().Destroy();
    }
    public void Depilacao()
    {
        spawn.GetComponent<ControladorDoJogo>().Depilacao();
        spawn.GetComponent<ControladorDoJogo>().Destroy();
    }
}