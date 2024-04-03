using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject menuPerdedor;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void Iniciar()
    {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }

    public void Salir()
    {
        EditorApplication.isPlaying = false;
    }

    public void Perdiste()
    {
        menuPerdedor.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        menuPerdedor.SetActive(false);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 0;
        menuPerdedor.SetActive(false);
        mainMenu.SetActive(true);
    }
}
