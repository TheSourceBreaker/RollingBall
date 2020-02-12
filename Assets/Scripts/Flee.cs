using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    public float MaxVelocity;
    public GameObject Target;

    public Vector3 CurrentVelocity;
    private Vector3 force;
    private Vector3 v;

    void Start()
    {
        CurrentVelocity = Vector3.zero; // set current value to all zero
    }

    void FixedUpdate()
    {
        v = (transform.position - Target.transform.position).normalized * MaxVelocity; //calculate a vector from the agent to its target

        force = v - CurrentVelocity; // at the start is the same thing as saying 5 - 0 = 5;

        CurrentVelocity += force * Time.deltaTime; // then 0 go up to 5 (with a little realisim). 

        transform.position += CurrentVelocity * Time.deltaTime; // current position goes to new Current Velocity

        transform.rotation = Quaternion.LookRotation(v);

    }
}
