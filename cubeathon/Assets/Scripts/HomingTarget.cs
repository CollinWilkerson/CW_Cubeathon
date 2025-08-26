using UnityEngine;

public class HomingTarget : MonoBehaviour
{
    [SerializeField] float forceMultiplier;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.linearVelocity = Vector3.zero;
            collision.rigidbody.AddForce(Vector3.up * forceMultiplier, ForceMode.VelocityChange);

            Destroy(gameObject);
        }
    }
}
