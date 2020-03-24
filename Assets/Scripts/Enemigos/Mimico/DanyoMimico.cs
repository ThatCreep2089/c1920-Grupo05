using UnityEngine;

public class DanyoMimico : MonoBehaviour
{
    //quita vidas al script vidas que está en un padre
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponentInParent<Vida>() != null && collision.gameObject.GetComponent<Danyo>() != null && this.gameObject.GetComponent<DanyoMimico>() != null)
        {
            gameObject.GetComponentInParent<Vida>().QuitaVida(collision.gameObject.GetComponent<Danyo>().danyo);
        }
    }
}
