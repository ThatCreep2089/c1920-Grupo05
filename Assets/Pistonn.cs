using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistonn : MonoBehaviour
{
    public float speed;
    public float tiempoEspera;
    public float tiempoEmpuje;
    private float tiempoAux;

    //private float tiepoAux;
    bool empuja;
    bool retorna;
    
    private Rigidbody2D rb;
    
    void Awake ()
    {
        tiempoAux = tiempoEmpuje;

        empuja = false;
        retorna = false;

        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoEspera > 0 && !empuja && !retorna) //ESPERA
            tiempoEspera -= Time.deltaTime;

        else if (!empuja && !retorna) empuja = true; //EMPIEZA A EMPUJAR

        else if (empuja && !retorna) Empuja(); //EMPUJA

        else if (retorna && !empuja) Retorna();     


    }

    private void Empuja ()
    {
        if (tiempoEmpuje > 0)
        {
            //Piston();
            rb.velocity = new Vector2(speed, 0);

            tiempoEmpuje -= Time.deltaTime;
        }

        else if (tiempoEmpuje <= 0)
        {
            empuja = false;
            retorna = true;
            tiempoEmpuje = tiempoAux;

            rb.velocity = new Vector2(0, 0);
        }
    }

    private void Retorna ()
    {
        if (tiempoEmpuje > 0)
        {
            //Piston();
            rb.velocity = new Vector2(-speed, 0);

            tiempoEmpuje -= Time.deltaTime;
        }

        else if (tiempoEmpuje <= 0)
        {            
            retorna = false;

            tiempoEmpuje = tiempoAux;

            rb.velocity = new Vector2(0, 0);
        }

    }
}
