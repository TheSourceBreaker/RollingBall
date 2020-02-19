using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> neighbors = new List<Node>();
    public Node prevNode;
    public float difficulty;
    [HideInInspector]
    public float gScore;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        for(int i = 0; i < neighbors.Count; i++)
        {
            Gizmos.DrawLine(transform.position, neighbors[i].transform.position);
        }
    }
    
    void Update()
    {
        
    }
}
