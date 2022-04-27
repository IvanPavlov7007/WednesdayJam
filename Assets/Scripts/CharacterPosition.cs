using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPosition : MonoBehaviour
{
    Node currentNode;
    [SerializeField]
    Node initialNode;

    public Node CurrentNode { get { return currentNode; } private set { currentNode = value; } }

    private void Awake()
    {
        moveToNode(initialNode);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToNode(Node n)
    {
        currentNode = n;
        transform.position = n.transform.position;
    }
}
