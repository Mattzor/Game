using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorHealth : MonoBehaviour {



    float health = 100;
    bool isAlive = true;

    Animation anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        if (!isAlive)
        {
            anim.CrossFade("die2");
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isAlive = false;
        }
    }
}
