using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitNode : MonoBehaviour
{
    public Node initalNode;
    private void Start()
    {
       GetComponent<Player>().Initialise(initalNode);
    }
}
