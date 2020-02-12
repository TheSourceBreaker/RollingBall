using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public Vector3 wanderTarget;
    public Vector3 currentSpeed;
    private Vector3 force;
    private Vector3 v;
    public float wanderTolerance;
    public float wanderRadius;
    public float rotationSpeed;
    public float maxSpeed;

    void Start()
    {
        wanderTarget = new Vector3(Random.Range(-wanderRadius, wanderRadius), transform.position.y, Random.Range(-wanderRadius, wanderRadius));
        rotationSpeed = 0.5f;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, wanderTarget) < wanderTolerance)
        {
            NewTarget();
        }
        v = new Vector3(wanderTarget.x - transform.position.x, transform.position.y, wanderTarget.z - transform.position.z).normalized;
        v.y = 0;
        force = v - currentSpeed;
        currentSpeed += force * Time.deltaTime;
        transform.position += currentSpeed * Time.deltaTime;
        Update();
    }
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(v);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void NewTarget()
    {
        wanderTarget = new Vector3(Random.Range(-wanderRadius, wanderRadius), transform.position.y, Random.Range(-wanderRadius, wanderRadius));
    }

}
