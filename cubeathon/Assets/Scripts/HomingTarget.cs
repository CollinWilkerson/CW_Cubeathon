using UnityEngine;

public class HomingTarget : MonoBehaviour
{
    private static HomingTarget[] targets;
    [SerializeField] float forceMultiplier;

    private void Start()
    {
        targets = FindObjectsByType<HomingTarget>(FindObjectsSortMode.None);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.linearVelocity = Vector3.zero;
            collision.rigidbody.AddForce(Vector3.up * forceMultiplier, ForceMode.VelocityChange);

            gameObject.SetActive(false);
        }
    }

    public static void Restart()
    {
        foreach (HomingTarget target in targets)
        {
            target.gameObject.SetActive(true);
        }
    }
}
