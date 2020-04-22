using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Vida>() != null)
        {
            if(collision.gameObject.GetComponent<Vida>().salud + 1 <= 6)
            {
                collision.gameObject.GetComponent<Vida>().salud++;
                UIManager.instance.AddCorazon(1);
            }
            else if(collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
            {
                collision.gameObject.GetComponentInChildren<PlayerMovement>().velocityReduction = 1;
            }
        }
        Destroy(gameObject);
    }
}
