using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public List<Boid> Agents = new List<Boid>();

    bool Separation, Align, Cohes;

    Vector3 separateForce;

    void Start()
    {
        separateForce = Vector3.zero;
    }

    private void Update()
    {
        foreach(Boid boid in Agents)
        {
            separateForce += 
        }
    }
}
