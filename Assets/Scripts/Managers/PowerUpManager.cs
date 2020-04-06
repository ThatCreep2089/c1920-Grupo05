	using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
	public static PowerUpManager instance;
	public GameObject balaPrefab;
	int powerUpControl = 0;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	public void AddPowerUp(GameObject powerUp)
	{
		DesactivatePowerUp();
		ActivatePowerUp(powerUp);
	}

	void ActivatePowerUp(GameObject powerUp)
	{
		if (powerUp.name == "Poder(Clone)")
		{
			balaPrefab.GetComponent<Danyo>().danyo *= 2;
			powerUpControl = 1;
		}
		else if (powerUp.name == "Velocidad(Clone)")
		{
			this.gameObject.GetComponentInChildren<PlayerMovement>().runVelocity *= 2;
			powerUpControl = 2;
		}
		else if (powerUp.name == "Rango(Clone)")
		{
			balaPrefab.GetComponent<ProjectileProperties>().tiempoProyectil *= 2;
			powerUpControl = 3;
		}
        else if (powerUp.name == "VidaExtra(Clone)")
        {
            if(this.gameObject.GetComponent<Vida>().salud + 2 <= 6)
            {
                this.gameObject.GetComponent<Vida>().salud += 2;
                UIManager.instance.AddCorazon(2);
            }  
            else if (this.gameObject.GetComponent<Vida>().salud + 1 <= 6)
            {
                this.gameObject.GetComponent<Vida>().salud += 1;
                UIManager.instance.AddCorazon(1);
            }
        }
	}

	void DesactivatePowerUp()
	{
		if (powerUpControl > 0)
		{
			if (powerUpControl == 1)
			{
				balaPrefab.GetComponent<Danyo>().danyo /= 2;
				powerUpControl = 0;
			}
			if (powerUpControl == 2)
			{
				this.gameObject.GetComponentInChildren<PlayerMovement>().runVelocity /= 2;
				powerUpControl = 0;
			}
			if (powerUpControl == 3)
			{
				balaPrefab.GetComponent<ProjectileProperties>().tiempoProyectil /= 2;
				powerUpControl = 0;
			}
		}
	}
}
