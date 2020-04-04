using UnityEngine;

public class DropPowerUp : MonoBehaviour
{
    public GameObject PowerUp;
    private void OnDestroy()
    {
        if (PowerUp != null) { Instantiate<GameObject>(PowerUp, transform.position, Quaternion.identity); }
    }
}
