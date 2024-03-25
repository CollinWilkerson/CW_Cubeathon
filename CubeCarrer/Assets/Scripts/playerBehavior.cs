using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float downwardsForce = -1f;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            rb.AddForce(0, downwardsForce, forwardForce * Time.deltaTime);
            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForce, 0, 0, ForceMode.VelocityChange);
            }
        }
        if (rb.position.y < -1f)
        {
            FindFirstObjectByType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            active = false;
            FindFirstObjectByType<GameManager>().EndGame();
        }
    }
}
