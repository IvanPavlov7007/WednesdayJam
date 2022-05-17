using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    public float speed, runningSpeed;
    public bool isRunning;

    protected Rigidbody rb;
    protected Animator anim;
    protected SpriteRenderer sr;
    protected Transform tr;

    public bool facingRight;

    public Vector3 direction { get; set; }


    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        //sr = GetComponentInChildren<SpriteRenderer>();
    }
    protected void Update()
    {
        anim.SetBool("isMoving", direction.magnitude > 0.001f);
        //if (direction.magnitude > 0.001f)
            //facingRight = !(Vector3.Angle(direction, Vector3.right) > 90f);
           //tr.localScale = new Vector3(0,0,-1); //flip some shit
           //sr.flipX = !facingRight;
    }

    protected private void FixedUpdate()
    {
        var velocity = direction * speed;
        //  var velocity = direction * (isRunning ? runningSpeed : speed);
        rb.velocity = CommonTools.yPlaneVector(velocity, rb.velocity.y);
    }
}
