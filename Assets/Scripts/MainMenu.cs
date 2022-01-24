using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Funciones para asignar a los botones de los menús para cambiar de escena
    public void StartButton()
    {
        SceneManager.LoadScene("Level01");
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene("Level02");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}
