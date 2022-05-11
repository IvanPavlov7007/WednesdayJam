using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedPlayer : MonoBehaviour
{
    public static TurnBasedPlayer instance { get; private set; }

    public PlayerDiscreteInput input { get; private set; }
    public CharacterMover characterMover { get; private set; }
    public PlayerState playerGameState { get; private set; }


    private void Awake()
    {
        
        if (instance != null)
            throw new UnityException("Another player exists");
        instance = this;

        characterMover = GetComponent<CharacterMover>();
        playerGameState = GetComponent<PlayerState>();
    }

    private void Start()
    {
        
    }

    public void Initialise(Node n)
    {
        characterMover.moveToNode(n);
        playerGameState.changeState(n.GetComponent<GameState>());
    }

    public void MoveTo(Node n)
    {
        characterMover.moveToNode(n);
        playerGameState.changeState(n.turnOptions);
    }


}
