using UnityEngine;

[CreateAssetMenu(fileName = "Shrink", menuName = "Powerups/Shrink")]
public class Shrink : Powerup
{
    [SerializeField] private float shrinkAmount = 2f;
    public override void Apply(GameObject target)
    {
        target.transform.localScale /= shrinkAmount; 
    }
}
