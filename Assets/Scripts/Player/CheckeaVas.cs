using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckeaVas : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DropPowerUp vasija = collision.gameObject.GetComponent<DropPowerUp>();
        if (vasija != null)
        {
            vasija.CreatePowerUp();
        }
    }
}
