using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class CharacterStates : MonoBehaviour
{

    StateMachine stateMachine;
    TimeFlowManager timeFlowManager;
    AudioSource aud;
    Animator anim;

    [SerializeField]
    AudioClip hit, block;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponentInChildren<StateMachine>();
        timeFlowManager = TimeFlowManager.Instance;
        aud = GetComponentInChildren<AudioSource>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.W) && timeFlowManager.makePlayerTurn())
        //{
        //    stateMachine.ChangeState("shield");
        //}
    }

    public void hitCharacter()
    {
        if(stateMachine.currentState == stateMachine.defaultState) // no shield
        {
            aud.PlayOneShot(hit);
            anim.SetTrigger("hit");
        }
        else
        {
            aud.PlayOneShot(block);
        }

        setCharacterState("normal");
    }

    void setCharacterState(string state)
    {
        stateMachine.ChangeState(state);

    }
}