using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaWarudo : MonoBehaviour
{
    public static bool pause;
    GameObject canvas;
    GameObject canvas2;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        canvas = GameObject.Find("Resumir");
        canvas.SetActive(false);
        canvas2 = GameObject.Find("PauseCanvas");
        canvas2.SetActive(true);
    }

    public void parar()
    {
        if (pause == false)
        {
            pause = true;
            canvas.SetActive(true);
            canvas2.SetActive(false);
            Time.timeScale = 0;
        }
        else if (pause == true)
        {
            pause = false;
            canvas.SetActive(false);
            canvas2.SetActive(true);
            Time.timeScale = 1;
        }
    }
}