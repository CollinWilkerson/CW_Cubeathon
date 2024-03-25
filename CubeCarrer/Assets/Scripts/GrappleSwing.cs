//Mostly based on https://www.youtube.com/watch?v=Xgh4v1w5DxU

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleSwing : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask isGrappleable;
    public Transform player;

    public float maxDistance = 10f;
    private SpringJoint joint;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        //this is what actually looks for the player
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, maxDistance, isGrappleable);

        //If anything is in our array it has picked up our player
        if (rangeChecks.Length != 0)
        {
            //the only thing in the targetmask is the player, so we use the first index
            Transform target = rangeChecks[0].transform;
            //establishes direction to enemy rotation to player location
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            //starts raycast from center of enemy, toward the player, from the distance to the player, only checking objects in the obstructionMask
            if (Physics.Raycast(transform.position, directionToTarget, out hit, distanceToTarget, isGrappleable))
            {
                grapplePoint = hit.point;

                //creates the spring that works as the grapple and configures it.
                joint = player.gameObject.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = grapplePoint;

                float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

                //distance the grapple tries to keep
                joint.maxDistance = distanceFromPoint * 0.8f;
                joint.maxDistance = distanceFromPoint * 0.25f;

                //effects the way the grapple controlls
                joint.spring = 4.5f;
                joint.damper = 7f;
                joint.massScale = 4.5f;

                lr.positionCount = 2;
            }
        }
    }

    void DrawRope()
    {
        //doesn't draw if there is no grapple
        if (!joint) return;

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }
}
