﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour {


    public Transform playerTransform;
    public float walkSpeed;
    public float runSpeed;

    bool playerInRange = false;
    float time;

    Vector3 startPosition;
    Animator anim;
    Rigidbody skeletonRigidbody;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        anim = GetComponent<Animator>();
        skeletonRigidbody = GetComponent<Rigidbody>();
        time = Time.time;
        anim.SetBool("isIdle", true);
	}

    void FixedUpdate()
    {
        if(playerTransform != null)
        {
            if (anim.GetBool("playerInRange"))
            {
                Attack();
            }
            else
            {
                ChasePlayer();
            }
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        if(anim.GetBool("isIdle") && Time.time - time > 5)
        {
            transform.Rotate(new Vector3(0,90f,0));            
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            time = Time.time;
        }else if(anim.GetBool("isWalking") && Time.time - time > 7)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
            time = Time.time;
        }
        if (anim.GetBool("isWalking"))
        {
            Vector3 position = skeletonRigidbody.position;
            Vector3 movement = transform.forward * walkSpeed * Time.deltaTime;
            skeletonRigidbody.MovePosition(position + movement);
        }
        
        
    }
    void ChasePlayer()
    {
        Vector3 playerPosition = playerTransform.position;
        transform.LookAt(playerTransform);
        Vector3 position = skeletonRigidbody.position;
        Vector3 movement = transform.forward * runSpeed * Time.deltaTime;
        skeletonRigidbody.MovePosition(position + movement);
    }
    void Attack()
    {

    }

}
