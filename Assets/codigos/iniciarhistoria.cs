using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class iniciarhistoria : MonoBehaviour
{
    public void CambiarEscena(string historia)
    {
        SceneManager.LoadScene("historia");
    }
}
