using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularCar : MonoBehaviour
{
    public float carVelocity;
    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d.velocity = new Vector2(0, carVelocity);  // Inicia la velocidad del coche en la dirección y
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    // Método para aumentar la velocidad del coche
    public void IncreaseSpeed(float speedIncrease)
    {
        carVelocity += speedIncrease;  // Aumenta la velocidad en el valor pasado
        rb2d.velocity = new Vector2(0, carVelocity);  // Aplica la nueva velocidad al Rigidbody
    }
}