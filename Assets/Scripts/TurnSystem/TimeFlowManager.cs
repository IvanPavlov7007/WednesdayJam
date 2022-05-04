using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlowManager : MonoBehaviour
{
    public float playerNextInputDelay;


    float playerNextInputTimer;


    public static TimeFlowManager Instance { get; set; }

    public event TurnAction onPlayerMakeTurn;

    private void Awake()
    {
        Instance = this;
    }

    public bool playerCanMakeNextMove { get { return playerNextInputTimer > playerNextInputDelay; } }

    public bool makePlayerTurn(TurnOption turn)
    {
        if (playerCanMakeNextMove)
        {
            playerNextInputTimer = 0f;
            if (turn.Execute())
            {
                if (onPlayerMakeTurn != null)
                    onPlayerMakeTurn(turn);
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        playerNextInputTimer += Time.deltaTime;
    }
}

public delegate void TurnAction(TurnOption turn);
