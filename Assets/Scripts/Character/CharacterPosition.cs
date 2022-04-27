using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterPosition : MonoBehaviour
{
    Node currentNode;
    [SerializeField]
    Node initialNode;

    public event CharacterMovemenAction onCharacterMoved;

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
        if (onCharacterMoved != null)
            onCharacterMoved(n);
    }
}

public delegate void CharacterMovemenAction(Node newNode);
