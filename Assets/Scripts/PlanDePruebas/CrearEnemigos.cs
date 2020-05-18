using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearEnemigos : MonoBehaviour
{
    public GameObject Enemigo0, Enemigo1, Enemigo2, Enemigo3, Enemigo4, Enemigo5, Enemigo6, Enemigo7, Enemigo8, Spawn;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)) Instantiate(Enemigo0, Spawn.transform);
        else if (Input.GetKeyDown(KeyCode.Alpha1)) Instantiate(Enemigo1, Spawn.transform);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) Instantiate(Enemigo2, Spawn.transform);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) Instantiate(Enemigo3, Spawn.transform);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) Instantiate(Enemigo4, Spawn.transform);
        else if (Input.GetKeyDown(KeyCode.Alpha5)) Instantiate(Enemigo5, Spawn.transform);
        else if (Input.GetKeyDown(KeyCode.Alpha6)) Instantiate(Enemigo6, Spawn.transform);
        else if (Input.GetKeyDown(KeyCode.Alpha7)) Instantiate(Enemigo7, Spawn.transform);
        else if (Input.GetKeyDown(KeyCode.Alpha8)) Instantiate(Enemigo8, Spawn.transform);
    }
}
