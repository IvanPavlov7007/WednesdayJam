using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContinuousInput : MonoBehaviour
{
    CharacterMovement characterMovement;
    ShootingManager shootingManager;
    Transform characterTr;
    Animator anim;

    // Singletone pattern
    private static PlayerContinuousInput instance;
    public static PlayerContinuousInput Instance { get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
        characterTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        shootingManager = GetComponent<ShootingManager>();
    }

    void Update()
    {
        characterMovement.direction = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //characterMovement.isRunning = Input.GetKey(KeyCode.LeftShift);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //anim.SetTrigger("pewTriggeruz");
            //shootingManager.Shoot(new Vector3(20f, 0f, 0f) * (characterTr.forward.x < 0f ? -1f : 1f));
            shootingManager.Shoot(characterTr.right * 20f);

        }
    }
}
