using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameState currentState;

    public static PlayerState instance { get; private set; }


    TimeFlowManager timeFlowManager;
    private void Awake()
    {
        if (instance != null)
            throw new UnityException("Another player exists");
        instance = this;
    }

    private void Start()
    {
        timeFlowManager = TimeFlowManager.Instance;
    }

    public void changeState(GameState newState)
    {
        currentState = newState;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            timeFlowManager.makePlayerTurn(currentState.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            timeFlowManager.makePlayerTurn(currentState.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            timeFlowManager.makePlayerTurn(currentState.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            timeFlowManager.makePlayerTurn(currentState.right);
        }
    }
}
