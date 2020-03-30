using UnityEngine;

public class Vida : MonoBehaviour
{
    Animator anim;
    DisparoEnemigo dispara;
    EnemigoHaciaPla moverse;
    private void Start()
    {
        dispara = GetComponentInChildren<DisparoEnemigo>();
        moverse = GetComponentInChildren<EnemigoHaciaPla>();

        anim = transform.GetComponent<Animator>();
    }
    public int salud;
    public void QuitaVida(int danyo)
    {
        salud = salud - danyo;
        if (this.gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            UIManager.instance.ReducirCorazon(danyo);
        }
        if (salud <= 0)
        {
            if(dispara != null)             //para que no se mueva ni dispare en los primeros frames de la animacion de muerte.
            {
                dispara.enabled = false;
            }
            if (moverse != null)
            {
                moverse.enabled = false;
            }
            anim.SetTrigger("Dead");
        }
    }
    public void OnDead()
    {
        GameManager.instance.Morir(this.gameObject);
    }
    public void Infanticidio()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
