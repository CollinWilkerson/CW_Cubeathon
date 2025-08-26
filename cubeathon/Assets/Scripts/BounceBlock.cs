using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBlock : MonoBehaviour
{
    public float forceMultiplier = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Vector3 direction = (transform.position - collision.transform.position).normalized;
            Vector3 direction = new Vector3 (0,1,0);
            collision.rigidbody.AddForce(direction * forceMultiplier, ForceMode.VelocityChange);
            Debug.Log("CONTACT! " + direction);
        }
    }
}
