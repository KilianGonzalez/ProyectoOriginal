using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public int startingTime = 180; // Tiempo inicial en segundos
    public TMP_Text countdownText; // Referencia al TMP_Text donde se mostrará el contador
    public string victorySceneName = "victory"; // Nombre de la escena de victoria

    private int remainingTime; // Tiempo restante

    void Start()
    {
        // Inicializamos el tiempo restante con el tiempo inicial
        remainingTime = startingTime;

        // Iniciamos la coroutine para el contador
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (remainingTime > 0)
        {
            // Actualizamos el texto del contador (solo segundos)
            countdownText.text = remainingTime.ToString();

            // Esperamos un segundo
            yield return new WaitForSeconds(1f);

            // Reducimos el tiempo restante
            remainingTime--;
        }

        // Cuando el contador llega a 0
        countdownText.text = "0";
        Debug.Log("Tiempo terminado. Cargando escena de victoria...");
        SceneManager.LoadScene(victorySceneName);
    }
}