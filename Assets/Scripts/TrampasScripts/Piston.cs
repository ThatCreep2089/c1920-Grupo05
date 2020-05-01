﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    Rigidbody2D pistonRB; //SE VA A MOVER

    Transform transPiston; //VOLVERA A SU POSICION 
    Vector3 posInicial;

    [SerializeField] float speed = 1;

    private bool empujar;

    [SerializeField] float tiempoDeEspera = 1; //ESPERA ANTES DE COMENZAR A MOVERSE
    private float esperaAuxiliar;

    [SerializeField] float tiempoDeEmpuje = 1; //EMPUJA UN RATO
    private float empujeAuxiliar;

    //INICIALIZA VARIABLES
    void Awake()
    {
        transPiston = GetComponent<Transform>();
        posInicial = transPiston.position;

        pistonRB = GetComponent<Rigidbody2D>();

        empujar = false;
        //empujar = true;

        esperaAuxiliar = tiempoDeEspera;

        empujeAuxiliar = tiempoDeEmpuje;
    }

    // Update is called once per frame
    void Update()
    {
        pistonRB.freezeRotation = true; //PARA QUE NO EMPIECE A ROTAR POR LOS LOLES

        if (Input.GetKey(KeyCode.E)) empujar = true;

        //TIEMPO de ESPERA ANTES de MOVERSE
        if (empujar && esperaAuxiliar > 0)
            esperaAuxiliar -= Time.deltaTime;

        else if (empujar)
        {
            Empuje();

            if (empujar && empujeAuxiliar > 0)
                empujeAuxiliar -= Time.deltaTime;                            

            else  empujar = false;            
        } 

        else
        {
            transPiston.position = posInicial;
            esperaAuxiliar = tiempoDeEspera;
            empujeAuxiliar = tiempoDeEmpuje;

        }
    }

    void Empuje()
    {
        pistonRB.velocity = new Vector2(speed, 0);
    }
}
