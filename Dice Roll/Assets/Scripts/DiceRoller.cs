using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    private Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Roll(Vector3 spawnPoint)
    {
        float angVel = Random.Range(-10f, 10f);
        float launchVel = Random.Range(4f, 10f);
        float randRot = Random.Range(0f, 180f);
        body.rotation = Quaternion.Euler(randRot, randRot, 0f);
        body.position = spawnPoint;
        body.angularVelocity = Vector3.one * angVel;
        body.velocity = new Vector3(0f, 1f, launchVel);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
