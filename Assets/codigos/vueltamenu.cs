using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vueltamenu : MonoBehaviour
{
    public void CambiarEscena(string menu)
    {
        SceneManager.LoadScene("menu");
    }
}
