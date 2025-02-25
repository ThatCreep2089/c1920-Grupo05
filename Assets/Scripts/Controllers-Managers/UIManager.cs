﻿using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	[Header("Panel de Game Over")]
	public GameObject finishPanel;
    public Text finishText;
	
	[Header("Panel de Pausa")]
	public GameObject pausePanel;
	public static bool paused = false;

	[Header("Vida")]
	public Image[] corazones;
	[Header("Potencidores")]
	public Image[] powerUps;

    int indice;

    void Start()
    {
        GameManager.instance.SetUIManager(this);
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
        indice = 0;
    }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) /*|| Input.GetAxis("")*/)
		{
			if(paused)
			{
				ResumeGame();
			}else
			{
				PauseGame();
			}
		}
		
	}

	public void ResumeGame()
	{
		paused = false;
		pausePanel.SetActive(false);
		Time.timeScale = 1f; //Activamos la ejecuccion del juego.
	}

	public void PauseGame()
	{
		paused = true;
		pausePanel.SetActive(true);
		Time.timeScale = 0f; //Detenemos la ejecuccion del juego.
	}

	public void FinishGame(bool playerWins)
	{
		//Debug.LogError("finishGame Detectado");
		if (playerWins)
			finishText.text = "The End \n Gracias por jugar";
		else
			finishText.text = "Game Over";

		finishPanel.gameObject.SetActive(true);
	}

	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
	public void ReducirCorazon(int danyo)
    {
        int control = indice;
        if (indice + danyo < corazones.Length)
        {
            while (indice < control + danyo)
            {
                corazones[indice].gameObject.SetActive(false);
                indice++;
            }
        }
        else
        {
            while (indice < corazones.Length)
            {
                corazones[indice].gameObject.SetActive(false);
                indice++;
            }
        }
    }

    public void AddCorazon(int vidaExtra)
    {
        for (int i = 0; i < vidaExtra; i++)
        {
            indice--;
            corazones[indice].gameObject.SetActive(true);
        }
    }

    // Metodo que va activando los corazones en funcion del int dado 
    // (esto funciona porque este metodo se llama siempre despues del ReducirCorazones)
    public void SetHealth(int corazonesActivos)
    {
        for (int i = corazonesActivos; i < corazones.Length; i++)
        {
            corazones[i].gameObject.SetActive(true);
        }
        indice = corazonesActivos;
    }

	public void AnyadirPowerUp(string powerUp)
	{
		string s = powerUp.Replace("(Clone)", "");

		int i = 0;
		while (i < powerUps.Length && powerUps[i].name != s) i++;
		if (i < powerUps.Length)
			powerUps[i].gameObject.SetActive(true);
	}

    public void QuitarPowerUp(string powerUp)
    {
        // ATENCION, como podeis ver este metodo no usa un string auxiliar para cortar la parte de (Clone) del nombre
        // si usais este metodo por tanto, el string powerUp debe ser el nombre sin alterar
        int i = 0;
        while (i < powerUps.Length && powerUps[i].name != powerUp) i++;
        if (i < powerUps.Length) powerUps[i].gameObject.SetActive(false);
    }
}
