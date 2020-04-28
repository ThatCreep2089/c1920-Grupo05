using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            //llama metodo de vida
            collision.gameObject.GetComponent<Vida>().SumaVidaPlayer();
            //metodo uimanager
            UIManager.instance.AñadirPowerUp(gameObject);

            Destroy(gameObject);
        }
    }
}
