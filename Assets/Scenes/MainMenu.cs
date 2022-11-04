using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void CargarEscena(string nombreNivel) 
    {
        SceneManager.LoadScene(nombreNivel);
    }
    /* //SEGUNDAOPCION PARA CAMBIAR DE ESCENAS
    public void EscenaJuego() 
    {
        SceneManager.LoadScene("Juego");
    }

     public void MenuJugador() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("MenuJugador");
        }
    }
    */
    public void Salir() 
    {
        Application.Quit();
    }
}
