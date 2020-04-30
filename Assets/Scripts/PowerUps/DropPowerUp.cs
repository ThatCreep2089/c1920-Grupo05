using UnityEngine;

public class DropPowerUp : MonoBehaviour
{
    [SerializeField] GameObject PowerUp;
    public void CreatePowerUp()
    {
        if (PowerUp != null) { Instantiate<GameObject>(PowerUp, transform.position, Quaternion.identity); }
    }
}
