using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    CharacterPosition pos;

    public static PlayerInput Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pos = GetComponent<CharacterPosition>();
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
        if(nextN != null && TimeFlowManager.Instance.makePlayerMove())
            pos.moveToNode(nextN);
    }
}
