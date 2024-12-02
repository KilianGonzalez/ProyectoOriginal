using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitOnEnter : MonoBehaviour
{
    public TMP_InputField answerInput; // Referencia al campo de entrada
    public Button submitButton;       // Referencia al bot�n de Confirmar

    void Start()
    {
        if (answerInput != null)
        {
            // Agregar un listener al evento onSubmit del campo de texto
            answerInput.onSubmit.AddListener(SubmitAnswerOnEnter);
        }
    }

    void Update()
    {
        // Detectar la tecla Enter para activar el bot�n
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            submitButton.onClick.Invoke();
        }
    }

    private void SubmitAnswerOnEnter(string input)
    {
        // Activar el bot�n de confirmar si se presiona Enter dentro del campo de texto
        submitButton.onClick.Invoke();
    }
}