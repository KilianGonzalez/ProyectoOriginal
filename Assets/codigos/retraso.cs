using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retraso : MonoBehaviour
{
    public AudioSource audioSource;
    public float tiempo = 5; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayDelayed(tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
