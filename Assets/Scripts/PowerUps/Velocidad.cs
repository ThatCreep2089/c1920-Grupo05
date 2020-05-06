using UnityEngine;

public class Velocidad : MonoBehaviour
{
    [SerializeField] float MultVelocidadAumento = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GetComponentInChildren porque el PlayerMovement esta en un objeto hijo y si no, no lo pilla
        if (collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            //llama metodo del playermovement 
            collision.gameObject.GetComponentInChildren<PlayerMovement>().AumentaVelocidad(MultVelocidadAumento);
            //metodo uimanager
            UIManager.instance.AnyadirPowerUp(gameObject.name);
            Destroy(gameObject);
        }
    }
}
