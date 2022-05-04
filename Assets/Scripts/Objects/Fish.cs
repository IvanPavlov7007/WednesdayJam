using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : TurnListenerObject
{
    public int maxSteps;
    public Vector3 translate;

    bool goingLeft = false;
    int currentStep = 0;
    public override void onTurn(TurnOption turn)
    {
        if(goingLeft)
        {
            currentStep--;

            transform.Translate(-translate);
            if (currentStep == 0)
                goingLeft = false;
            return;
        }

        currentStep++;
        transform.Translate(translate);
        if (currentStep == maxSteps - 1)
            goingLeft = true;
    }
}
