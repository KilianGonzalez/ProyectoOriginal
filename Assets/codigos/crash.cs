using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    private int vidas = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            vidas--;

            if (vidas <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("gameover");
            }
            else
            {
                Debug.Log("Vidas restantes: " + vidas);
            }
        }
    }
}


