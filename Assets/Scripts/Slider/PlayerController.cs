using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

// taken from https://itnext.io/how-to-write-a-simple-3d-character-controller-in-unity-1a07b954a4ca
public class PlayerController : MonoBehaviour
{
    /*    public abstract class Command
        {
            public abstract void Execute();
        }

        public class JumpFunction : Command
        {
            public override void Execute()
            {
                Jump();
            }
        }


        public static void DoMove()
        {
            Command keySpace = new JumpFunction();
            Command keyX = new TelekinesisFunction();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                keySpace.Execute();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                keyX.Execute();
            }
        }
    */

    public CharacterController cc;
    public float speed = 3;
    public AnimationCurve jumpCurve;
    private Vector3 playerVelocity;


    public Animator anim;

    private float gravity = 9.87f;
    private float verticalPosDelta = 0;
    private Transform tr;
    private ShootingManager sm;
    private bool faceRightOld;
    private bool faceRight;
    private float jumpHeight = 20f;
    private Vector3 jumpMove;
    private Vector3 moveDirection = Vector3.zero;
    private float jumpUpDuration = 0.5f;
    private float jumpPos = 0;
    private float jumpStartTime = 0;
    private float jumpTime;
    private Vector3 gravityVelocity = Vector3.zero;
    private Vector3 lastKnownDirection = Vector3.zero;
    private Vector3 runVelocity = Vector3.zero;
    private Transform initTr;
    private float horizontalMove;
    private float verticalMove;
    private Vector3 jumpVelocity;


    void Update()
    {
        Move();
        LookInDirection(lastKnownDirection);
        if (Input.GetKeyDown(KeyCode.LeftControl)) Fire(lastKnownDirection);
    }

    protected void Start()
    {
        anim = GetComponent<Animator>();
        initTr = GetComponent<Transform>();
        tr = GetComponent<Transform>();
        sm = GetComponent<ShootingManager>();
        cc = GetComponent<CharacterController>();
    }


    /*
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    */
    /* //  sollte ich jemals mouse look haben wollen
         public void Rotate()
        {
            float horizontalRotation = Input.GetAxis("Mouse X");
            float verticalRotation = Input.GetAxis("Mouse Y");

            transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
            cameraHolder.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

            Vector3 currentRotation = cameraHolder.localEulerAngles;
            if (currentRotation.x > 180) currentRotation.x -= 360;
            currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
            cameraHolder.localRotation = Quaternion.Euler(currentRotation);
        }*/

    private void Move()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (cc.isGrounded)
        { //isGrounded is trash, replace later
            verticalPosDelta = 0;
        }
        else
        {
            verticalPosDelta -= gravity * Time.deltaTime; //fall
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpStartTime = Time.time;
        }

        if (Time.time - jumpStartTime < jumpUpDuration)
        {
            jumpPos = (Time.time - jumpStartTime) / jumpUpDuration; // [0 .. 1]
        }
        else
        {
            jumpPos = 0;
        }

        runVelocity = speed * (transform.forward * verticalMove + transform.right * horizontalMove);
        gravityVelocity = new Vector3(0, verticalPosDelta, 0); //direction + input value
        jumpVelocity = Vector3.Lerp(Vector3.zero, new Vector3(0, jumpHeight, 0), jumpCurve.Evaluate(jumpPos));
        //new Vector3(0, Mathf.SmoothStep(0, jumpHeight, jumpPos),0) // ref für irgendwann so könnte es auch gehen

        if (horizontalMove != 0) lastKnownDirection = runVelocity;
        cc.Move(Time.deltaTime * (runVelocity + gravityVelocity + jumpVelocity));
        anim.SetBool("isMoving", horizontalMove != 0 && verticalPosDelta > -0.5); //fixlater 
    }

    private void LookInDirection(Vector3 direction)
    {
        if (direction.x < 0)
        {
            tr.localScale = new Vector3(1f, tr.localScale.y, tr.localScale.z); //fixlater
        }
        else {
            tr.localScale = new Vector3(-1f, tr.localScale.y, tr.localScale.z);

        }
    }

    private void Fire(Vector3 direction)
    {
        anim.SetTrigger("pewTrigger");
        //anim.Play("pew");
        if (direction.x > 0) {
            sm.offset = new Vector3(Mathf.Abs(sm.offset.x), sm.offset.y, sm.offset.z);
            sm.Shoot(tr.right * 20); }
        else {
            sm.offset = new Vector3((-1) * Mathf.Abs(sm.offset.x), sm.offset.y, sm.offset.z);
            sm.Shoot(tr.right * -20); }
    }
}