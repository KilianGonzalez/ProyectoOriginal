using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Puntuaci�: " + DatosGlobales.puntos;
    }

    void Update()
    {

    }
}
