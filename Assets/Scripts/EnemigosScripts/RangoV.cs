using UnityEngine;

public class RangoV : MonoBehaviour
{
    DisparoEnemigo dispara;
	EnemigoToPlayer moverse;
    Oscilate oscila;
    Tripas tripas;
    Animator anim;
	Flip gira;
	Stinky stinky;
	Dragon dragon;
    Pistonn piston;

    private void Awake()
    {
        dispara = GetComponent<DisparoEnemigo>();
        moverse = GetComponent<EnemigoToPlayer>();
        oscila = GetComponentInParent<Oscilate>();
        tripas = GetComponent<Tripas>();
        gira = GetComponent<Flip>();
		stinky = GetComponent<Stinky>();
		anim = transform.GetComponentInParent<Animator>();
		dragon = GetComponentInParent<Dragon>();
        piston = GetComponentInParent<Pistonn>();
	}
    //Comprobamos que tipo de enemigo es y en función de ello hacemos una cosa u otra//
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (dispara != null)
		{
			dispara.enabled = true;
			anim.SetBool("Atacando", true);
		}
		else if (moverse != null)
		{
			moverse.enabled = true;

			//animacion de movimiento
			if (anim != null)
				anim.SetBool("Walking", true);

		}
		else if (oscila != null) oscila.enabled = true;
		else if (tripas != null) tripas.enabled = true;
		else if (dragon != null) dragon.enabled = true;

		//Son componentes que se deberán activar si o si alguno de los anteriores ha sido activados(else if's)
		if (stinky != null) stinky.enabled = true;
		if (gira != null) gira.enabled = true;
        if (piston != null) piston.enabled = true;
             
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (dispara != null)
        {
            dispara.enabled = false;
            anim.SetBool("Atacando", false);
        }
        else if (moverse != null)
        {
            moverse.enabled = false;
            Rigidbody2D parent;
            parent = GetComponentInParent<Rigidbody2D>();
            parent.velocity = Vector2.zero;
        }
        else if (oscila != null) oscila.enabled = false;
        else if (stinky != null) stinky.enabled = false;
        else if (dragon != null) dragon.enabled = false;
        else if (piston != null) piston.enabled = false;

        //Especial
        if (gira != null) gira.enabled=false;
    }
}
