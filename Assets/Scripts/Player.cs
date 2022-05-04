using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    public PlayerInput input { get; private set; }
    public CharacterMovement characterPosition { get; private set; }
    public PlayerState playerGameState { get; private set; }


    private void Awake()
    {
        
        if (instance != null)
            throw new UnityException("Another player exists");
        instance = this;

        characterPosition = GetComponent<CharacterMovement>();
        playerGameState = GetComponent<PlayerState>();
    }

    private void Start()
    {
        
    }

    public void Initialise(Node n)
    {
        characterPosition.moveToNode(n);
        playerGameState.changeState(n.GetComponent<GameState>());
    }

    public void MoveTo(Node n)
    {
        characterPosition.moveToNode(n);
        playerGameState.changeState(n.turnOptions);
    }


}
