using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class FallingObject : TurnListenerObject
{
    public Vector3 translation;

    public override void onTurn(TurnOption turn)
    {
        Tween.Position(transform, transform.position + translation, 0.5f, 0f);
    }
}
