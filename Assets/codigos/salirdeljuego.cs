using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirDelJuego : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego se ha cerrado.");
    }
}