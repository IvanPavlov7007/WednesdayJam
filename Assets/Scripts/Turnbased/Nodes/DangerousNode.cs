using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

[RequireComponent(typeof(Node))]
public class DangerousNode : MonoBehaviour
{
    StateMachine stateMachine;
    Node node;

    private void Awake()
    {

    }

    void Start()
    {
        node = GetComponent<Node>();
        stateMachine = GetComponentInChildren<StateMachine>();
        PlayerInput.Instance.GetComponent<CharacterMover>().onCharacterMoved += onPlayerMoved;
    }

    public void onPlayerMoved(Node n)
    {
        if (n == node && stateMachine.currentState != null)
        {
            switch (stateMachine.currentState.name)
            {
                case "danger":
                    hitPlayer();
                    stateMachine.Exit();
                    break;
                default:
                    break;
            }
        }
    }

    public void setDangerState()
    {
        stateMachine.ChangeState("danger");
    }

    void hitPlayer()
    {
        PlayerInput.Instance.GetComponent<CharacterStates>().hitCharacter();
    }

    void Update()
    {
        
    }
}