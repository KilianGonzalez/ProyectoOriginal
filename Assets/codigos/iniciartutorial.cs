using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class iniciartutorial : MonoBehaviour
{
    public void CambiarTutorial(string tutorial)
    {
        SceneManager.LoadScene("tutorial");
    }
}