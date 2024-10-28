using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularCar : MonoBehaviour
{
    public float carVelocity;
    public Rigidbody2D rb2d;

    void Start()
    {
        rb2d.velocity = new Vector2(0, carVelocity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}


