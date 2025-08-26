using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left,
    Right,
    Forward,
    Back
}

public class playerBehavior : MonoBehaviour
{
    private Rigidbody rb;

    public float forwardForce = 2000f;
    public static Vector3 forwardVector;
    public float sidewaysForce = 500f;
    public static Vector3 sidewaysVector;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        forwardVector = Vector3.forward;
        sidewaysVector = Vector3.right;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            rb.AddForce(forwardVector * forwardForce * Time.deltaTime);
            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysVector * sidewaysForce, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-1 * sidewaysVector * sidewaysForce, ForceMode.VelocityChange);
            }
        }
        if (rb.position.y < -1f)
        {
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            active = false;
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }

    public static void turn(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                forwardVector = Vector3.forward;
                break;
            case Direction.Right:
                forwardVector = Vector3.right;
                sidewaysVector = Vector3.back;
                break;
            case Direction.Back:
                forwardVector = Vector3.back;
                sidewaysVector = Vector3.left;
                break;
            case Direction.Left:
                forwardVector = Vector3.left;
                sidewaysVector = Vector3.forward;
                break;
        }
    }
}
