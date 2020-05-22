using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    BoxCollider2D colliderRayo;
    SpriteRenderer seVeElRayo;

    void Awake()
    {
        colliderRayo = GetComponent<BoxCollider2D>();
        seVeElRayo = GetComponent<SpriteRenderer>();
    }

    public void ActivarCollider()
    {
        colliderRayo.enabled = true;
    }

    public void DesactivarCollider()
    {
        colliderRayo.enabled = false;
    }

    public void VerRayo()
    {
        seVeElRayo.enabled = true;
    }

    public void NoVerRayo()
    {
        seVeElRayo.enabled = false;
    }

}
