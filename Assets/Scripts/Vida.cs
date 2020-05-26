using UnityEngine;

public class Vida : MonoBehaviour
{
    Rigidbody2D rb;
    Disparar disparoPlayer;
    PlayerMovement movimientoPlayer;
    Knockback knockback;
    Animator anim;
    DisparoEnemigo dispara;
	EnemigoToPlayer moverse;
    int vidasExtra;

	[SerializeField] int salud;
	Vector2 dirKnock;

	private void Start()
    {
        //componentes player
        disparoPlayer = GetComponent<Disparar>();
        movimientoPlayer = GetComponentInChildren<PlayerMovement>();
        knockback = GetComponentInChildren<Knockback>();
        rb = GetComponent<Rigidbody2D>();
        vidasExtra = 0;

        //componentes de enemigos
        dispara = GetComponentInChildren<DisparoEnemigo>();
        moverse = GetComponentInChildren<EnemigoToPlayer>();

        //animacion
		if(gameObject.GetComponentInChildren<FlipMimico>()!=null)
			anim = transform.GetComponentInChildren<Animator>();
		else anim = transform.GetComponent<Animator>();
	}
    
    public void QuitaVida(int danyo)
    {
        salud -= danyo;

        if (gameObject.GetComponentInChildren<PlayerMovement>() != null)
        {
			anim.SetTrigger("Damage");
			UIManager.instance.ReducirCorazon(danyo);
        }
		
		if (salud <= 0 && vidasExtra == 0)
        {
            if(dispara != null)             //para que no se mueva ni dispare en los primeros frames de la animacion de muerte.
                dispara.enabled = false;

            if (moverse != null)
                moverse.enabled = false;

            if(anim != null)
				anim.SetTrigger("Dead");

			//Evitamos que pueda recibir algun ataque sin importar qué GO sea
			GetComponent<BoxCollider2D>().enabled = false;
			if (rb!=null)
				rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else if(salud <= 0 && vidasExtra > 0)
        {
            vidasExtra--;
            salud = 3;
            UIManager.instance.SetHealth(3);
            if (vidasExtra == 0) UIManager.instance.QuitarPowerUp("VidaExtra");
        }

    }

	public int GetHealth()
	{
		return salud;
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

    public void NoShootOrMove()
    {
        rb.velocity = Vector2.zero;
        knockback.enabled = false;
        disparoPlayer.enabled = false;
        movimientoPlayer.enabled = false;
    }

    public void AddVidaExtra()
    {
        vidasExtra++;
    }

    #endregion
}
