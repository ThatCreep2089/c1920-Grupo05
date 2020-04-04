using UnityEngine;

public class CollectPowerUp : MonoBehaviour
{

	#region Variables
	#endregion

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(PowerUpManager.instance!=null)
		{
			PowerUpManager.instance.AddPowerUp(gameObject);
		}
		else
		{
			Debug.Log("No existe PowerUpManager");
		}
		UIManager.instance.AñadirPowerUp(gameObject);
		Destroy(gameObject);
	}
	#region Personal Methods

	#endregion
}
