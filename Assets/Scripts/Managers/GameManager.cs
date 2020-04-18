using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        //Cosa que viene en los apuntes para que el gamemanager no se destruya entre escenas
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //Metodo que destruye el gameobject del jugador
    public void Morir(GameObject personaje)
    {
        if (personaje.GetComponent<PlayerMovement>()) ChangeScene("Main Menu");
        Destroy(personaje);
    }
    private void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
