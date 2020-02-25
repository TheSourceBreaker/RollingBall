using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Node node; // References an existing class
    List<Node> OpenList; // This references an already existing List of type Node
    List<Node> CloseList;
    List<Node> routeBack = new List<Node>();

    public static List<Node> allNodes = new List<Node>();

    public Vector3 target;
    public Vector3 startPos;

    public float speed;


    public void Path(Node Begin, Node End)
    {
        OpenList = new List<Node>();
        CloseList = new List<Node>();

        Node currentNode = Begin;
        OpenList.Add(Begin);

        while (currentNode != End) // fscore and sorting
        {
            currentNode = OpenList[0]; // current node is equal to the node at the start of OpenList (for each Node)

            for (int i = 1; i < OpenList.Count; i++) // This loop sorts and finds the lowest fScore inside the list and equals it to the currNode
            {
                if(OpenList[i].fScore < currentNode.fScore) // Reads through the node inside the list and compares its gScores with the currentNode's gscore
                {
                    currentNode = OpenList[i]; // If true, then current node is = to the specific list spot
                }
            }

            OpenList.Remove(currentNode);
            CloseList.Add(currentNode); // Add currentNode to ClosedList
            
            for (int i = 0; i < currentNode.neighbors.Count; i++) // This loop calculates the neighbor's gScore and hScore using Distance
            {
                if(!CloseList.Contains(currentNode.neighbors[i]))
                {
                    currentNode.neighbors[i].gScore = currentNode.gScore + Vector3.Distance(currentNode.transform.position, currentNode.neighbors[i].transform.position);//gScore
                    currentNode.neighbors[i].hScore = Vector3.Distance(currentNode.transform.position, End.transform.position);//hScore

                    currentNode.neighbors[i].prevNode = currentNode; // currentNode is now the previous Node of the neighbor
                    OpenList.Add(currentNode.neighbors[i]);
                }
                else
                    Debug.Log("Closelist contains neighbor" + "[" + i + "]");
            }
        }

        while(currentNode != Begin)
        {
            routeBack.Add(currentNode);
            currentNode = currentNode.prevNode;
        }
        routeBack.Reverse();
    }
    

    public void FindNewPath( Vector3 endPos)
    {
        Node startNode = allNodes[0];
        Node endNode = allNodes[0];

        float minStartDist = 0;
        float maxEndDist = 0;

        foreach (Node node in allNodes) // for each element inside the allNodes 
        {
            float startDistance = Vector3.Distance(transform.position, node.transform.position); // checks the min and max of the startPos and endPos
            float endDistance = Vector3.Distance(endPos, node.transform.position);


            if (startDistance > minStartDist) // if 0 is < the min distance
            {
                startNode = node;
                minStartDist = startDistance;
            }

            if(endDistance > maxEndDist) // if 0 is < the max distance
            {
                endNode = node;
                maxEndDist = endDistance;
            }
        }
        Path(startNode, endNode);
    }

    public void BackTrack()
    {
        for(int i = 0; i < CloseList.Count; i++)
        {
            CloseList[i].transform.position = transform.position;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        Vector3 v = new Vector3();
        //while (v != routeBack.)
        //{

        //}

        for(int i = 0; i < routeBack.Count; i++)
        {
            if(v == routeBack[i].transform.position)
            {
                routeBack[i]

            }
        }

    }
}
