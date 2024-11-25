using UnityEngine.SceneManagement;
using UnityEngine;

public class Crash : MonoBehaviour
{
    public int vidas;
    [SerializeField] private TMPro.TextMeshProUGUI uiVidasJugador;

    // Start is called before the first frame update
    private void Start()
    {
        vidas = 3;
        uiVidasJugador.text = vidas.ToString() + " x"; // Inicia el UI con las vidas
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

    // Método para restar una vida desde otro script
    public void DecreaseLife()
    {
        vidas--;
        uiVidasJugador.text = vidas.ToString() + " x"; // Actualiza el UI

        // Verifica si el jugador ha perdido todas las vidas
        if (vidas <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("gameover");
        }
    }
}