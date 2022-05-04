using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    CharacterMovement pos;

    public static PlayerInput Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pos = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            MoveToNode(-1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveToNode(1f);
        }
    }

    void MoveToNode(float x)
    {
        var nextN = pos.CurrentNode.GetNextNode(new Vector2(x, 0f));
        //if(nextN != null && TimeFlowManager.Instance.makePlayerTurn())
        //    pos.moveToNode(nextN);
    }
}
