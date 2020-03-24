using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxSerpiente : MonoBehaviour
{
    //Script asociado a la hurtbox del ataque de la serpiente que maneja el tiempo de desaparición de la hurtbox.

    float tiempo = 0.5f, cont = 0;
    void Update()
    {
        cont += Time.deltaTime;
        if (cont >= tiempo) Destroy(this.gameObject);
    }
}
