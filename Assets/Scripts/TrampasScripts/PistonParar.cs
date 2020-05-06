using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonParar : MonoBehaviour
{
    /*El piston no se para cuando sales de su campo de vion
     sale propulsado en la velocidad que tengas en ese momento.
     Esto es debido a que al salir se desactiva el script Pistonn.
     No se me ocurria como arreglarlo asi que he creado por el momento este
     script auxiliar. Luego preguntare si alguien me sabe decir como havcerlo
     menos chapuza*/

    private Rigidbody2D rbParent;

    void Awake()
    {               //RB del Piston
        rbParent = GetComponentInParent<Rigidbody2D>();
    }

    void OnTriggerExit2D (Collider2D coll)
    {
        rbParent.velocity = new Vector2(0, 0);
    }
}
