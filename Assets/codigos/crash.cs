using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Crash : MonoBehaviour
{
    public int vidas;
    [SerializeField] private TMPro.TextMeshProUGUI uiVidasJugador;

    // Start is called before the first frame update
    private void Start()
    {
        vidas = 3;
    }

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
                uiVidasJugador.text = vidas.ToString() + " x";
            }
        }
    }
}


