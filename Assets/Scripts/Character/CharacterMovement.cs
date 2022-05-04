using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pixelplacement;

public class CharacterMovement : MonoBehaviour
{
    Node currentNode;

    AudioSource aud;
    [SerializeField]
    AudioClip moveSound;

    public event CharacterMovemenAction onCharacterMoved;

    public Node CurrentNode { get { return currentNode; } private set { currentNode = value; } }

    private void Awake()
    {
    }

    void Start()
    {
        aud = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToNode(Node n)
    {
        currentNode = n;
        Tween.Position(transform, n.transform.position, 0.2f, 0f);
        if (onCharacterMoved != null)
        {
            aud.PlayOneShot(moveSound);
            onCharacterMoved(n);
        }
    }
}

public delegate void CharacterMovemenAction(Node newNode);
