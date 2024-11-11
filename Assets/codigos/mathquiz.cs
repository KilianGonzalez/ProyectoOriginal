using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathQuiz : MonoBehaviour
{
    public GameObject questionPanel;
    public Text questionText;
    public InputField answerInput;
    public Crash crashScript;
    private List<(string, int)> questions;
    private bool isPaused;

    void Start()
    {
        questionPanel.SetActive(false);

        // Define preguntas y respuestas
        questions = new List<(string, int)> {
            ("5 + 3", 8),
            ("10 - 4", 6),
            ("2 * 3", 6),
            ("7 + 5", 12),
            // Agrega más preguntas según sea necesario
        };

        StartCoroutine(QuestionTimer());
    }

    IEnumerator QuestionTimer()
    {
        while (crashScript != null && crashScript.vidas > 0)
        {
            yield return new WaitForSeconds(10);
            ShowQuestion();
        }
    }

    void ShowQuestion()
    {
        Time.timeScale = 0; // Pausa el juego
        isPaused = true;
        questionPanel.SetActive(true);

        // Selecciona una pregunta aleatoria
        var question = questions[Random.Range(0, questions.Count)];
        questionText.text = question.Item1;
        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    public void CheckAnswer()
    {
        if (isPaused)
        {
            int correctAnswer = questions.Find(q => q.Item1 == questionText.text).Item2;
            int playerAnswer;

            if (int.TryParse(answerInput.text, out playerAnswer) && playerAnswer == correctAnswer)
            {
                questionPanel.SetActive(false);
                Time.timeScale = 1; // Reanuda el juego
                isPaused = false;
            }
            else
            {
                // Resta una vida si la respuesta es incorrecta
                crashScript.vidas--;

                if (crashScript.vidas <= 0)
                {
                    // Lógica de Game Over
                    SceneManager.LoadScene("gameover");
                }
                else
                {
                    ShowQuestion(); // Muestra otra pregunta si falla
                }
            }
        }
    }
}
