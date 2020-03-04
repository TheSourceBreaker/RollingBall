using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : MonoBehaviour
{
    public IDecision decisionTreeRoot;

    public bool choice;

    void Update()
    {
        decisionTreeRoot = new PrintDecision(choice);

        decisionTreeRoot.MakeDecision();
    }
}


class BooleanDecision : IDecision
{
    bool test = false;

    public Decision trueBranch;
    public Decision falseBranch;

    public IDecision MakeDecision()
    {
        if (test == true)
        {
            
        }
        return null;
    }
}

public class PrintDecision : IDecision
{
    public bool branch;

    public PrintDecision() { } // constructor

    public PrintDecision(bool otherBranch) // copy contructor
    {
        this.branch = otherBranch;
    }

    public IDecision MakeDecision()
    {
        Debug.Log(branch ? "Yes" : "No");

        return null;
    }
}