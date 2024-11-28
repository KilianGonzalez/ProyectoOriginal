using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class iniciarpartida : MonoBehaviour
{
    public void inipartida(string partida)
    {
        DatosGlobales.reiniciarPuntos();
        SceneManager.LoadScene("partida");
    }
}
