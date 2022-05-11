using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputDelayDisplayer : MonoBehaviour
{
    Sprite[] s;
    void Start()
    {
        s = GetComponentsInChildren<Sprite>();
    }

    void Update()
    {
        if(TimeFlowManager.Instance.playerCanMakeNextMove)
        {
            
        }
    }

    void setVisibility(float v)
    {

    }
}
