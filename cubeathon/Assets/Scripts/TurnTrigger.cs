using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    [SerializeField] Direction direction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            playerBehavior.turn(direction);
        }
    }
}
