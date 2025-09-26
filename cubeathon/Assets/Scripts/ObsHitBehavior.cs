using UnityEngine;

public class ObsHitBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        playerBehavior.OnHitObstacle += ChangeColor;
    }

    private void OnDisable()
    {
        playerBehavior.OnHitObstacle -= ChangeColor;
    }
    private void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
