using UnityEngine;

public class Oscilate : MonoBehaviour
{
	//ESTE COMPONENTE DEBE IR ADJUNTO A UN GAMEOBJECT QUE HAGA DE EJE GIRADOR DEL GO QUE QUEREMOS QUE OSCILE.
	#region Variables

	//Tiempo que tarda en cambiar de posición.
	[Range(1.7f, 2)]
	[SerializeField] float time; 

	float interpTime, temp;      //Tiempo entre cada interpolación | Temporizador .

	float timeDead = 0.5f; //Tiempo muerto entre cada interpolación.
	float addTime = 0.7f;  //Tiempo para ajustar la espera y velocidad del GO.

	Quaternion finalPos;
	Quaternion nextPos, iniRot;

	#region Comments
	//diferencia entre Slerp and Lerp? Uno es esferico y el otro lineal pero es practicament igual.
	/* Se puede hacer mediante programacion matematica, de manera que sea la posicion inicial, la posicion final, y un porcentaje  que me indique lo que avance mediante tiempo en esa distancia.
	 * Es decir, si tengo 3, 5 y 0.5,. la distancia es 2, y me sacara que se moverá 1 por segundo. Entre mas pequeño el valor se moverá mas fluido.
	 * Tweening, easing functions
	 * */
	#endregion

	#endregion

	#region Unity Methods
	private void Awake()
	{
		if (transform.localScale.x > 0)
			finalPos = Quaternion.Euler(0, 0, 135);
		else
			finalPos = Quaternion.Euler(0, 0, -135);

		iniRot = transform.rotation; //Posicion inicial
		nextPos = finalPos;            //Nueva Posición

		interpTime = time + timeDead;

		temp = interpTime;
	}

	void Update()
	{
		if (temp > 0)
		{
			if (nextPos == finalPos)//Bajar
				transform.rotation = Quaternion.Lerp(transform.rotation, nextPos, time * Time.deltaTime);

			else //Subir
				transform.rotation = Quaternion.Lerp(transform.rotation, nextPos, (time - addTime) * Time.deltaTime);
				//time-0.2 significa un porcentaje menor de posición. Por lo que se va más lento.

			temp -= Time.deltaTime;
		}

		else
		{
			if (nextPos == finalPos)
			{
				nextPos = iniRot;
				temp = interpTime; //Variar el temporizador según qué tan rapido baja.
			}			
			else
			{
				nextPos = finalPos;
				temp = interpTime + addTime;
			}
		}
		//Para no alterar el BoxCollider de deteccion del hacha.
		GameObject hijo = GetComponentInChildren<RangoV>().gameObject;
			hijo.transform.rotation = Quaternion.Euler(0, 0, 0);
	}
	#endregion
}

