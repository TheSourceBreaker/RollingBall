﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    Agent agent;
    public float MaxVelocity;
    public GameObject Target;

    private Vector3 force;
    private Vector3 v;
    private void Awake()
    {
        agent = GetComponent<Agent>();
    }

    void Start()
    {
        agent.currentVelocity = Vector3.zero; // set current value to all zero
    }

    void FixedUpdate()
    {
        v = (transform.position - Target.transform.position).normalized * MaxVelocity; //calculate a vector from the agent to its target

        force = v - agent.currentVelocity; // at the start is the same thing as saying 5 - 0 = 5;

        agent.currentVelocity += force * Time.deltaTime; // then 0 go up to 5 (with a little realisim). 
    }
}
