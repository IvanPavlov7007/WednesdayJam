using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlowManager : MonoBehaviour
{
    public float playerNextInputDelay;


    float playerNextInputTimer;


    public static TimeFlowManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public bool playerCanMakeNextMove { get { return playerNextInputTimer > playerNextInputDelay; } }

    public bool makePlayerMove()
    {
        if (playerCanMakeNextMove)
        {
            playerNextInputTimer = 0f;
            return true;
        }
        return false;
    }

    void Update()
    {
        playerNextInputTimer += Time.deltaTime;
    }
}
