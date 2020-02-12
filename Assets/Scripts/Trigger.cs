using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    Boid boid;

    void Start()
    {
        boid = GetComponentInParent<Boid>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boid")
        {
            boid.Agents.Add(other.GetComponent<Boid>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boid")
        {
            boid.Agents.Remove(other.GetComponent<Boid>());
        }
    }
}
