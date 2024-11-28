using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class MathQuiz : MonoBehaviour
{
    public GameObject questionPanel;
    public TMP_Text questionText;
    public TMP_InputField answerInput;
    public Crash crashScript; // Referencia al script Crash que maneja las vidas
    public RegularCar carController; // Referencia al script que maneja el coche
    public ScoreManager scoreManager; // Referencia al script ScoreManager

    private List<(string, int)> questions;
    private bool isQuestionActive;
    private int correctAnswer; // Variable para almacenar la respuesta correcta actual

    public float speedIncreaseAmount = 1f; // Cantidad con la que se incrementa la velocidad del coche

    void Start()
    {
        questionPanel.SetActive(true); // Asegurarnos de que el panel esté activado
        answerInput.characterValidation = TMP_InputField.CharacterValidation.Integer;

        // Lista de preguntas matemáticas
        questions = new List<(string, int)> {
            ("5 + 3", 8), ("10 - 4", 6), ("2 * 3", 6), ("7 + 5", 12),
            ("9 - 2", 7), ("3 * 4", 12), ("6 / 2", 3), ("8 + 6", 14),
            ("15 - 7", 8), ("2 * 5", 10), ("12 / 3", 4), ("4 + 9", 13),
            ("10 - 3", 7), ("3 * 6", 18), ("20 - 10", 10), ("7 + 8", 15),
            ("18 / 6", 3), ("5 * 5", 25), ("14 - 6", 8), ("9 + 4", 13),
            ("16 / 4", 4), ("8 * 2", 16), ("6 + 11", 17), ("20 - 8", 12),
            ("10 / 5", 2), ("3 + 9", 12), ("12 - 5", 7), ("7 * 2", 14),
            ("24 / 6", 4), ("6 + 8", 14), ("15 - 4", 11), ("5 * 4", 20),
            ("10 + 12", 22), ("18 - 9", 9), ("4 * 7", 28), ("16 / 8", 2),
            ("11 + 3", 14), ("20 - 5", 15), ("9 * 2", 18), ("25 / 5", 5),
            ("12 + 7", 19), ("18 - 6", 12), ("2 * 9", 18), ("30 - 10", 20),
            ("10 + 15", 25), ("20 / 4", 5), ("7 + 9", 16), ("21 - 6", 15),
            ("8 * 3", 24), ("24 / 8", 3), ("14 + 5", 19), ("18 - 8", 10),
            ("6 * 3", 18), ("40 / 8", 5), ("13 + 6", 19), ("20 - 6", 14),
            ("5 * 7", 35), ("49 / 7", 7), ("18 + 3", 21), ("21 - 3", 18),
            ("6 * 6", 36), ("48 / 8", 6), ("10 + 25", 35), ("30 - 12", 18),
            ("6 * 7", 42), ("42 / 6", 7), ("9 + 18", 27), ("21 - 15", 6),
            ("7 * 8", 56), ("56 / 8", 7), ("10 + 25", 35), ("30 - 8", 22),
            ("8 * 6", 48), ("48 / 12", 4), ("15 + 18", 33), ("40 - 25", 15),
            ("9 * 7", 63), ("63 / 9", 7), ("11 + 22", 33), ("30 - 10", 20),
            ("7 * 6", 42), ("42 / 7", 6), ("16 + 14", 30), ("20 - 9", 11),
            ("5 * 6", 30), ("50 / 5", 10), ("13 + 9", 22), ("25 - 7", 18),
            ("6 * 9", 54), ("54 / 6", 9), ("18 + 11", 29), ("32 - 6", 26),
            ("4 * 6", 24), ("24 / 4", 6), ("20 + 5", 25), ("10 - 5", 5),
            ("9 * 3", 27), ("27 / 9", 3), ("15 + 13", 28), ("25 - 12", 13),
            ("7 * 2", 14), ("30 / 6", 5), ("8 + 7", 15), ("21 - 7", 14),
            ("6 * 6", 36), ("36 / 6", 6), ("10 + 10", 20), ("20 - 3", 17),
            ("0 * 1", 0), ("69 / 3", 23), ("144 / 2", 72), ("60 * 3", 180)
        };

        // Llamamos a la corutina que plantea la pregunta
        StartCoroutine(TrackGameTime());

        // Generar la primera pregunta
        GenerateNewQuestion();
    }

    private void GenerateNewQuestion()
    {
        isQuestionActive = true;

        // Selección aleatoria de pregunta
        int index = UnityEngine.Random.Range(0, questions.Count); // Aseguramos que usamos UnityEngine.Random
        string question = questions[index].Item1;
        correctAnswer = questions[index].Item2; // Guardamos la respuesta correcta

        // Mostrar la pregunta
        Debug.Log("Pregunta seleccionada: " + question + " | Respuesta correcta: " + correctAnswer);
        questionText.text = question;

        // Borramos la entrada del jugador anterior
        answerInput.text = "";
        answerInput.ActivateInputField();
    }

    public void SubmitAnswer()
    {
        if (isQuestionActive)
        {
            int userAnswer;

            if (int.TryParse(answerInput.text, out userAnswer))
            {
                Debug.Log("Respuesta del jugador: " + userAnswer);

                if (userAnswer == correctAnswer)
                {
                    Debug.Log("Respuesta correcta.");
                    carController.IncreaseSpeed(speedIncreaseAmount);

                    DatosGlobales.puntos += 1000;
                }
                else
                {
                    Debug.Log("Respuesta incorrecta. La respuesta correcta era: " + correctAnswer);
                    crashScript.DecreaseLife(); // Resta una vida solo si la respuesta es incorrecta
                }

                // Generar nueva pregunta
                GenerateNewQuestion();
            }
            else
            {
                Debug.Log("Entrada inválida.");
            }
        }
    }

    private IEnumerator TrackGameTime()
    {
        // Esperar un minuto (60 segundos)
        yield return new WaitForSeconds(180f);

        // Cargar la escena de victoria
        Debug.Log("¡Se ha alcanzado 1 minuto de juego! Cargando la escena de victoria...");
        SceneManager.LoadScene("victory");
    }
}