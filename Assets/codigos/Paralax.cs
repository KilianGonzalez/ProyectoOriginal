using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{

    public Vector2 Velocidad;
    public MeshRenderer meshRenderer;


    void Update()
    {
        meshRenderer.material.mainTextureOffset = Velocidad * Time.time;
    }
}
