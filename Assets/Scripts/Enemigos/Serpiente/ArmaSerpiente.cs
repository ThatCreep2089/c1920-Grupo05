using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaSerpiente : MonoBehaviour
{
    public GameObject atkcol;
    private Animator anim;
    public float tiempoPre = 1;
    float contador;
    bool control = false;
    Transform arma;
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        arma = gameObject.transform;
    }

    // Update is called once per frame
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

        anim.CrossFade("atk", 3); //es decir al final de esta animación
    }
}
