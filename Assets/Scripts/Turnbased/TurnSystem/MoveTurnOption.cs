using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurnOption : TurnOption
{

    public Node otherNode;
    public Node thisNode { get; protected set; }

    private void Start()
    {
        thisNode = GetComponentInParent<Node>();
    }

    public override bool Execute()
    {
        if (otherNode == null)
            return false;
        Player.instance.MoveTo(otherNode);
        return true;
        //do changes for las node here
    }
}
