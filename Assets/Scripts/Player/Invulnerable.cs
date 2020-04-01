using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    //Cuando el jugador recibe daño, se desavtica su componente de vida, por lo que no se le puede hacer daño//
    Vida player;
    Disparar disparo;
    double timer = 0;
    public int TiempoInvulneravilidad;
    private void Awake()
    {
        player = GetComponent<Vida>();
        disparo = GetComponent<Disparar>();
    }
    private void Update()
    {
        if (timer <= TiempoInvulneravilidad) timer = timer + Time.deltaTime;
        else enabled = false;
    }
    private void OnEnable()
    {
        player.enabled = false;
        disparo.enabled = false;
    }
    private void OnDisable()
    {
        player.enabled = true;
        disparo.enabled = true;
    }
}
