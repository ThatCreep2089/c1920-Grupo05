    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaCollider : MonoBehaviour
{
    const float tiempo = 0.5f;
    float cont = 0;

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;
        if (cont >= tiempo) Destroy(this.gameObject); //contador para que la hitbox del arma desaparezca rápido
    }
}
