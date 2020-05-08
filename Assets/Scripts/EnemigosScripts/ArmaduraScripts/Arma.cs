using UnityEngine;

public class Arma : MonoBehaviour
{
	[SerializeField] GameObject atkcol = null;
	[SerializeField] float tiempoPre = 1;

	Animator anim;
    float contador;
    bool control = false;
    Transform arma;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        arma = gameObject.transform;
    }

    void Update()
    {
        if (control)
        {
            contador += Time.deltaTime;
            if (contador >= tiempoPre)
            {
                control = false;
                contador = 0;
                Instantiate(atkcol, arma.position, arma.rotation);
                this.enabled = false;
            }
        }
    }
    private void OnEnable()
    {
        //Debug.Log("ataque");
        control = true; //para que la hitbox del arma apareza solo en el ultimo momento del golpe

        anim.SetBool("Attacking", true);
    }
    private void OnDisable()
    {
        anim.SetBool("Attacking", false);
    }
}
