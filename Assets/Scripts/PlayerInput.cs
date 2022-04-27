using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    CharacterPosition pos;

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
        if(nextN != null)
            pos.moveToNode(nextN);
    }
}
