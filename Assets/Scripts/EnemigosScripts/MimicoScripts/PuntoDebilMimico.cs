using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoDebilMimico : MonoBehaviour
{
    Vida vida;

    private void Awake()
    {
        vida = GetComponentInParent<Vida>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogError("PuntoDebil Trigger ocurred with G.O. " + collision.gameObject + " in layer " + collision.gameObject.layer);
        if (!vida.enabled)
            vida.enabled = true;
    }
}
