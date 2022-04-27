using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class CharacterStates : MonoBehaviour
{

    StateMachine stateMachine;
    TimeFlowManager timeFlowManager;
    
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponentInChildren<StateMachine>();
        timeFlowManager = TimeFlowManager.Instance;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && timeFlowManager.makePlayerMove())
        {
            stateMachine.ChangeState("shield");
        }
    }

    public void hitCharacter()
    {
        setCharacterState("normal");
    }

    void setCharacterState(string state)
    {
        stateMachine.ChangeState(state);

    }
}