using NUnit.Framework.Constraints;
using System;
using System.Collections;
using UnityEngine;

public class HomingAttack : MonoBehaviour
{
    [SerializeField] private float homingRadius;
    [SerializeField] private LayerMask targetMask;

    private Transform activeTarget;

    private void Start()
    {
        StartCoroutine(RangeCheckRoutine());
    }

    private void Update()
    {
        if (activeTarget != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.position = activeTarget.position;
            }
        }
    }

    private IEnumerator RangeCheckRoutine()
    {
        //how often the coroutine runs
        WaitForSeconds wait = new WaitForSeconds(0.1f);

        while (true)
        {
            yield return wait;
            RangeCheck();
        }
    }

    private void RangeCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, homingRadius, targetMask);

        //if we have at least one homing object
        if (rangeChecks.Length != 0)
        {
            Transform target = null;
            float newDistance;
            float targetDistance = homingRadius * 2; //make targetDistance large so it chooses a target
            //selects the closest object in the colider array
            foreach (Collider collider in rangeChecks)
            {
                newDistance = Vector3.Distance(transform.position, collider.transform.position);
                if (newDistance < targetDistance)
                {
                    target = collider.transform;
                }
            }
            activeTarget = target;
        }
        else
        {
            activeTarget = null;
        }
    }
}
