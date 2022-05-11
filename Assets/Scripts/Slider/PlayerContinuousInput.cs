using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContinuousInput : MonoBehaviour
{
    CharacterMovement characterMovement;
    ShootingManager shootingManager;

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
        shootingManager = GetComponent<ShootingManager>();
    }

    void Update()
    {
        characterMovement.direction = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        characterMovement.isRunning = Input.GetKey(KeyCode.LeftShift);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            shootingManager.Shoot(new Vector3(20f, 0f, 0f) * (characterMovement.direction.x < 0f ? -1f : 1f));
        }
    }
}
