using UnityEngine;

public class Poder : MonoBehaviour
{
    [SerializeField] 
    int MultDanyoAumento = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            //metodo danyo
            collision.gameObject.GetComponent<Disparar>().SetDobleDanyoTrue();
            //aumento de tamanyo
            // bala.GetComponent<ProjectileProperties>().AumentaTamanyo(1.3f);
            //metodo uimanager
            UIManager.instance.AnyadirPowerUp(gameObject.name);
            Destroy(gameObject);
        }
    }
}
