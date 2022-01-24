using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    //Función para mostrar la pantalla de game over tras la muerte
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
        }
    }

    //Función que se lanzará tras llegar a la puerta de final de nivel
    public void WinGame()
    {
        if(gameHasEnded == false)
        {
            Debug.Log("Level Won");

            //Si se gana el primer nivel se muestra un menú intermedio con el segundo nivel donde te permite avanzar
            if(SceneManager.GetActiveScene().name == "Level01")
            {
                SceneManager.LoadScene("WinMenuBetween");
            }
            //Si se gana el segundo nivel se muestra una pantalla de victoria final, sin opción de avanzar
            else if(SceneManager.GetActiveScene().name == "Level02")
            {
                SceneManager.LoadScene("WinMenu");
            }
        }
    }
}
