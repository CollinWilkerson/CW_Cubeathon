using UnityEngine;

[CreateAssetMenu(fileName = "Slow", menuName = "Powerups/Slow")]
public class Slow : Powerup
{
    [SerializeField] private float SlowAmount = 2f;
    public override void Apply(GameObject target)
    {
        target.GetComponent<playerBehavior>().forwardForce /= SlowAmount;
    }
}
