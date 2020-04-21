using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llamarada : MonoBehaviour
{
     BoxCollider2D colliderP;
     SpriteRenderer seVeLaLlama;

    void Awake ()
    {
        colliderP = GetComponent<BoxCollider2D>();
        seVeLaLlama = GetComponent<SpriteRenderer>();
    }

    public void ActivarCollider ()
    {
        colliderP.enabled = true;
    }

    public void DesactivarCollider()
    {
        colliderP.enabled = false;
    }

    public void VerLlamarada()
    {
        seVeLaLlama.enabled = true;
    }

    public void NoVerLlamarada()
    {
        seVeLaLlama.enabled = false;
    }
}
