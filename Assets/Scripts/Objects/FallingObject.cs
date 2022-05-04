using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : TurnListenerObject
{
    public Vector3 translation;

    public override void onTurn(TurnOption turn)
    {
        transform.Translate(translation);
    }
}
