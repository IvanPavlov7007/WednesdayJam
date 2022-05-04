using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnListenerObject : MonoBehaviour
{
    protected virtual void Start()
    {
        TimeFlowManager.Instance.onPlayerMakeTurn += onTurn;
    }

    public abstract void onTurn(TurnOption turn);
}
