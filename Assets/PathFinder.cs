using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Node node;
    List<Node> OpenList;
    List<Node> CloseList;



    public void Path(Node Begin, Node End)
    {
        Node currentNode;
        while (Begin != End)
        {
            currentNode = OpenList[0]; // current node is equal to the node at the start of OpenList

            for (int i = 1; i < OpenList.Count; i++) // OpenList.count = OpenList.size
            {
                if(OpenList[i].gScore < currentNode.gScore) // Reads through the list and compares its gScore with the currentNode
                {
                    currentNode = OpenList[i]; // If true, then current node is = to the specific list spot
                }
            }
            CloseList.Add(currentNode); // Add currentNode to ClosedList
            node.prevNode = currentNode; // set prevNode to be = to currentNode
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < node.neighbors.Count; i++)
            OpenList.Add(node.neighbors[0]);
    }

    // Update is called once per frame
    void Update()
    {
        Path(Begin,End);
        
    }
}
