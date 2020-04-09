using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TentarNovamente : MonoBehaviour
{
    // Start is called before the first frame update
    public void Reiniciar()
    {
        SceneManager.LoadScene("GameTeste");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}