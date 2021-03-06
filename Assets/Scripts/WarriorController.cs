﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonoBehaviour {

    public float turnSpeed = 10f;
    public float walkSpeed = 2f;
    public float runSpeed = 10f;


    public bool running = true;


    Animation anim;
    Rigidbody playerRigidbody;
    bool forward = true;
    bool runningMode = true;
    public bool isAttacking = false;

    float moveSpeed;



    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        moveSpeed = runSpeed;
        anim["strafeLeft"].speed = 1.7f;
        anim["strafeRight"].speed = 1.7f;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move();
        Attack();
        //Animating(h, v);
    }

    void Move()
    {
        Vector3 movement;
        Vector3 position = playerRigidbody.position;
        bool moving = false;
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            ChangeMoveSpeed();
        }
        /* Move forward */
        if (Input.GetKey(KeyCode.W) && !isAttacking)
        {
            if (running)
            {
                movement = transform.forward * moveSpeed * Time.deltaTime;
                playerRigidbody.MovePosition(position + movement);
                anim.CrossFade("run");
            }
            else
            {
                movement = transform.forward * moveSpeed * Time.deltaTime;
                playerRigidbody.MovePosition(position + movement);
                if (!forward)
                {
                    ChangeWalkAnimationDirection(true);
                    forward = true;
                }
                anim.CrossFade("walk");
            }
            moving = true;

        }
        /* Move backwards */
        else if (Input.GetKey(KeyCode.S) && !isAttacking)
        {
            movement = -transform.forward * walkSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(position + movement);
            if (forward)
            {
                ChangeWalkAnimationDirection(false);
                forward = false;
            }
            anim.CrossFade("walk");
            moving = true;
        }
        /* Strafe left */
        else if(Input.GetKey(KeyCode.A) && Input.GetMouseButton(1) && !isAttacking){
            movement = -transform.right * moveSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(position + movement);            
            anim.CrossFade("strafeLeft");
            moving = true;
            
        }
        /* Strafe right */
        else if (Input.GetKey(KeyCode.D) && Input.GetMouseButton(1) && !isAttacking)
        {
            movement = transform.right * moveSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(position + movement);            
            anim.CrossFade("strafeRight");
            moving = true;

        }else
        {
            moving = false;
        }
        /* Turning left/right */           
        float x = 0;
        
        if (Input.GetAxis("Horizontal") != 0)
        {
            x = Input.GetAxis("Horizontal") * 2;
        }
        if (Input.GetMouseButton(1))
        {
            x = Input.GetAxis("Mouse X") * turnSpeed * 1;
        }
        transform.Rotate(0, x, 0);
        if (!moving)
        {
            anim.CrossFade("idle");
        }
        else
        {
            isAttacking = false;
        }
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //anim.Play("swordStrike2");
            anim["swordStrike2"].speed = 1.5f;
            anim.CrossFade("swordStrike2");
            isAttacking = true;
        }
        else {
            isAttacking = false;
        }
    }

    void Animate()
    {

    }


    // Update is called once per frame
    void Update () {
		
	}

    void ChangeMoveSpeed()
    {
        if (!running)
        {
            moveSpeed = runSpeed;
            anim["strafeLeft"].speed = 1.7f;
            anim["strafeRight"].speed = 1.7f;
            running = true;
        }
        else
        {
            moveSpeed = walkSpeed;
            anim["strafeLeft"].speed = 1f;
            anim["strafeRight"].speed = 1f;
            running = false;
        }
    }

    void ChangeWalkAnimationDirection(bool forward)
    {
        if (forward)
        {
            anim["walk"].speed = 1;
            anim["walk"].time = 0;
        }
        else
        {
            anim["walk"].speed = -1;
            anim["walk"].time = anim["walk"].length;
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && isAttacking)
        {
            Destroy(other.gameObject);
        }
    }*/

}
