using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private UIManager uiManager;
    int currentLevel = 0;

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

    public void SetUIManager(UIManager uim)
    {
        uiManager = uim;
    }

    public void Morir(GameObject personaje)
    {
        if (personaje.GetComponentInChildren<PlayerMovement>())
        {
            //Debug.LogError("player detectado");
            LevelFinished(false);
        }

        Destroy(personaje);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
		if (name != "Transition" && name!= "Main Menu" && name!= "Cinematic_Video" && name != "Creditos") currentLevel++;
		Time.timeScale = 1f; //Restaurar la ejecucion en caso de que esté pausado el juego.
    }

    public void LevelFinished(bool playerWins)
    {
        //Debug.LogError("levelfinished");
        uiManager.FinishGame(playerWins);
    }
    public int returncurrentLevel()
    {
        return currentLevel;
    }
}
