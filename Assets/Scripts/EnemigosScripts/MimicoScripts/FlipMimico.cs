using UnityEngine;

public class FlipMimico : MonoBehaviour
{
    Rigidbody2D rb;
    Transform trans;
    Animator anim;
	EnemigoToPlayer moverse;

	float posPlayerIni, posPlayerFin;

	private void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        trans = gameObject.transform.parent;
        anim = GetComponentInParent<Animator>();
		moverse = gameObject.transform.parent.GetChild(0).GetComponent<EnemigoToPlayer>();
    }
  
    public void OnFlip()
    {	
		//Cambio de sentido de Sprite
        trans.localScale = new Vector3(-trans.localScale.x, trans.localScale.y, trans.localScale.z);

		//Vuelve a la animacion de caminar
        anim.SetBool("Turn", false);
		if(moverse!=null)
			moverse.enabled = true;
		//Camina
        anim.SetBool("Walking", true);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Transform player = collision.gameObject.transform;

		anim.SetBool("Walking", true);

		if (player!=null)
		{
			posPlayerIni = player.position.x;

			if (posPlayerIni > trans.position.x && trans.localScale.x > 0 || posPlayerIni < trans.position.x && trans.localScale.x < 0)
			{
				//Empieza la anim de giro.	
				anim.SetBool("Turn", true);
				//Deja la animacion de caminar
				anim.SetBool("Walking", false);
				//No puede caminar
				if (moverse != null)
					moverse.enabled = false;
			}
		}
	}

	public void OnDeadMimico()
	{
		Destroy(gameObject.transform.parent.gameObject);
	}
}
