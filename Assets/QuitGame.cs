using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	public float contador = 5f;
	#region Unity Methods

	private void OnCollisionEnter2D(Collision2D collision)
	{
		contador -= Time.deltaTime;

		if(contador<=0)
		{
			Debug.Log("El juego ha terminado!");
			Application.Quit();
		}
			
	}
	#endregion

}
