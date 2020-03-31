using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    public GameObject balaPrefab;
    int powerUpControl = 0;

    public void AddPowerUp(GameObject powerUp)
    {
        DesactivatePowerUp();
        ActivatePowerUp(powerUp);
    }

    void ActivatePowerUp(GameObject powerUp)
    {
        if (powerUp.name == "Poder")
        {
            balaPrefab.GetComponent<Danyo>().danyo *= 2;
            powerUpControl = 1;
        }
        else if(powerUp.name == "Velocidad")
        {
            this.gameObject.GetComponent<PlayerMovement>().runVelocity *= 2;
            powerUpControl = 2;
        }
        else if (powerUp.name == "Rango")
        {
            balaPrefab.GetComponent<ProjectileProperties>().tiempoProyectil *= 2;
            powerUpControl = 3;
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
                this.gameObject.GetComponent<PlayerMovement>().runVelocity /= 2;
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
