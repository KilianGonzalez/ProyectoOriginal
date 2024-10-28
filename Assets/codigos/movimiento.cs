using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour

{
    public float CarVel;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - CarVel, transform.position.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + CarVel, transform.position.y);
        }
        if (transform.position.x < -1.03f)
        {
            transform.position = new Vector2(-1.03f, transform.position.y);
        }
        else if (transform.position.x > 1.03f)
        {
            transform.position = new Vector2(1.03f, transform.position.y);
        }
    }
}
