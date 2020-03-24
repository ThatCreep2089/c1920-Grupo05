using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    //Cuando el jugador recibe daño, se desavtica su componente de vida, por lo que no se le puede hacer daño//
    Vida player;
    double timer = 0;
    public int TiempoInvulneravilidad;
    private void Awake()
    {
        player = GetComponent<Vida>();
    }
    private void Update()
    {
        if (timer <= TiempoInvulneravilidad) timer = timer + Time.deltaTime;
        else enabled = false;
    }
    private void OnEnable()
    {
        player.enabled = false;
    }
    private void OnDisable()
    {
        player.enabled = true;
    }
}
