using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public LayerMask diceMask;
    private bool atRest;
    private int value;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        if (!atRest && body.velocity.magnitude < 0.05f && body.angularVelocity.magnitude < 0.05f)
        {
            atRest = true;
            if (Physics.Raycast(body.position, Vector3.up, out RaycastHit hit, 1f, diceMask))
            {
                if (int.TryParse(hit.collider.gameObject.name, out int side))
                {
                    value = side;
                }
            }
        }
        else if (atRest && body.velocity.magnitude > 0.1f && body.angularVelocity.magnitude > 0.1f)
        {
            atRest = false;
        }
    }

    public int GetValue()
    {
        return value > 0 && atRest ? value : 0;
    }

    public void DestroySelf ()
    {
        Destroy(gameObject);
    }
}
