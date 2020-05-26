using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.LogError("Collision ocurred with G.O. " + collision.gameObject + " in layer " + collision.gameObject.layer);
        if (collision.gameObject.GetComponent<Stunned>() != null)
        {   //stunea al personaje en cuestión//
            collision.gameObject.GetComponent<Stunned>().Paralizar();
        }
    }
}

