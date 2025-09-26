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
    private bool right = false;
    private bool left = false;
    private bool jump = false;
    private bool isGrounded = false;
    private Vector3 startPosition;

    public delegate void HitObstacle();
    public static event HitObstacle OnHitObstacle;

    [SerializeField] float jumpForce = 10f;
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

        startPosition = transform.position;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 2.0f))
        {
            isGrounded = true;
            //Debug.Log("isGrounded: " + isGrounded);
            //Debug.Log("Jump: " + jump);
        }
        else
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("Jump check: " + isGrounded + " " + jump);
        if (active)
        {
            rb.AddForce(forwardVector * forwardForce * Time.deltaTime);
            if (right)
            {
                rb.AddForce(sidewaysVector * sidewaysForce, ForceMode.VelocityChange);
            }
            if (left)
            {
                rb.AddForce(-1 * sidewaysVector * sidewaysForce, ForceMode.VelocityChange);
            }
            if (jump && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce);
                jump = false;
                //Debug.Log("Execute");
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
            OnHitObstacle();
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
                sidewaysVector = Vector3.right;
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

    public void TurnLeft()
    {
        left = true;
    }

    public void StopTurnLeft()
    {
        left = false;
    }

    public void TurnRight()
    {
        right = true;
    }

    public void StopTurnRight()
    {
        right = false;
    }

    public void Jump()
    {
        jump = true;
    }

    public void ResetPosition()
    {
        rb.linearVelocity = Vector3.zero;
        turn(Direction.Forward);
        active = true;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
    }

}
