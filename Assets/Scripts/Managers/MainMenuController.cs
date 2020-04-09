using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //IMPORTANATE

public class MainMenuController : MonoBehaviour
{
    //CUANDO SE PRESIONA EL BOTON ==> SE LLAMA A ESTE METODO
    public void StartGame ()
    {
        SceneManager.LoadScene("Fragile_v0");
    }
}
