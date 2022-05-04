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

    public override void Execute()
    {
        if (otherNode == null)
            return;
        Player.instance.MoveTo(otherNode);
        //do changes for las node here
    }
}
