using UnityEngine;

public class Vida : MonoBehaviour
{
    Disparar disparoPlayer;
    Animator anim;
    DisparoEnemigo dispara;
    EnemigoHaciaPla moverse;
	Knockback knockback;

	public int salud;
	Vector2 dirKnock;

	private void Start()
    {
        disparoPlayer = GetComponent<Disparar>();
        dispara = GetComponentInChildren<DisparoEnemigo>();
        moverse = GetComponentInChildren<EnemigoHaciaPla>();
		knockback = GetComponentInChildren<Knockback>();

		anim = transform.GetComponent<Animator>();
    }
    
    public void QuitaVida(int danyo)
    {
        salud -= danyo;

        if (gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
            UIManager.instance.ReducirCorazon(danyo);
        }
		
		if (salud <= 0)
        {
			if (knockback != null)         //El KnockBack Interrumpe la anim de muerte. Aun hay que hacer arreglos para que funcione mejor.
				knockback.enabled = false;

            if(dispara != null)             //para que no se mueva ni dispare en los primeros frames de la animacion de muerte.
            {
                dispara.enabled = false;
            }
            if (moverse != null)
            {
                moverse.enabled = false;
            }
            if(anim != null)
            {
				anim.SetTrigger("Dead");
            }
        }
    }

	#region AuxMethods
	public void OnDead()
	{
		GameManager.instance.Morir(gameObject);
	}

	public void Infanticidio()
	{
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			Destroy(gameObject.transform.GetChild(i).gameObject);
		}
	}

    public void NoShoot()
    {
        disparoPlayer.enabled = false;
    }
    #endregion
}
