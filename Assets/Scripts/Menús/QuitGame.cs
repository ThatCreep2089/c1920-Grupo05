using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	[SerializeField] float contador = 3f;
	bool quit = false;
	#region Unity Methods

	private void Update()
	{
		if(quit)
		{
			contador -= Time.deltaTime;

			if (contador <= 0)
			{
				Debug.Log("El juego ha terminado!");
				Application.Quit();
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		quit = true;
	}
	#endregion
}
