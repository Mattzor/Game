using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floormask;
    float camRayLength;
    public float turnSpeed = 10f;
    public float moveSpeed = 10f;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
       
        Move(h, v);
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        float z = v * Time.deltaTime * moveSpeed;
        float x = 0;
        transform.Translate(0, 0, z);

        if (Input.GetAxis("Horizontal") != 0)
        {
            x = Input.GetAxis("Horizontal");
        }
        if (Input.GetMouseButton(1))
        {
            x = Input.GetAxis("Mouse X") * turnSpeed * 1;
        }
        transform.Rotate(0, x, 0);
    }



    void Animating(float h, float v)
    {
        if(v != 0f)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
}
