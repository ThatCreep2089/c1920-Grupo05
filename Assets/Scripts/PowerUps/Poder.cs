using UnityEngine;

public class Poder : MonoBehaviour
{
    [SerializeField] 
    int MultDanyoAumento = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            //metodo danyo, aqui tambien se aumenta el tamanyo
            collision.gameObject.GetComponent<Disparar>().SetDobleDanyoTrue();
            //metodo uimanager
            UIManager.instance.AnyadirPowerUp(gameObject.name);
            Destroy(gameObject);
        }
    }
}
