using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    Agent agent;
    public List<Boid> Agents = new List<Boid>();

    public int agentCount;
    public bool Separation, Align, Cohes;

    public float separateWeight;
    public float alignWeight;
    public float cohesionWeight;

    Vector3 separateForce;
    Vector3 alignForce;
    Vector3 cohesionForce;

    Vector3 forceToApply;



    void Start()
    {
        separateForce = Vector3.zero;
        alignForce = Vector3.zero;
        cohesionForce = Vector3.zero;
    }
   
    private void Update()
    {
        if(Separation == true)
        {
            if (agentCount == 0)
            {
                foreach (Boid boid in Agents)
                {
                    separateForce += transform.position - boid.transform.position;
                    agentCount++;
                }
            }
            else
            {
                foreach (Boid boid in Agents)
                    separateForce += transform.position - boid.transform.position;
            }

            separateForce /= agentCount;
            forceToApply = (separateForce - agent.currentVelocity) * separateWeight;///
        }
        if(Align == true)
        {
            if(agentCount == 0)
            {
                foreach (Boid boid in Agents)
                {
                    //alignForce += boid.velocity
                    agentCount++;
                }
            }
            else
            {
                foreach (Boid boid in Agents) ;
                    //alignForce += boid.velocity
            }

            alignForce /= agentCount;
            forceToApply = (alignForce - agent.currentVelocity) * alignWeight;///
        }
        if(Cohes == true)
        {
            if (agentCount == 0)
            {
                foreach (Boid boid in Agents)
                {
                    cohesionForce += boid.transform.position - transform.position;
                    agentCount++;
                }
            }
            else
            {
                foreach(Boid boid in Agents)
                    cohesionForce += boid.transform.position - transform.position;
            }

            cohesionForce /= agentCount;
            forceToApply = (cohesionForce - agent.currentVelocity) * cohesionWeight;///
        }

        agentCount = 0;
    }
}
