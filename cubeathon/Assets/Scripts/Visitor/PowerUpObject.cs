using UnityEngine;

public class PowerUpObject : MonoBehaviour
{
    [SerializeField] private Powerup powerup;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            powerup.Apply(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
