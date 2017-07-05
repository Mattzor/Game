using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSwordCollider : MonoBehaviour {

    Transform playerTransform;

    void Start()
    {
        playerTransform = transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SkeletonEnemy" && playerTransform.GetComponent<WarriorController>().isAttacking)
        {
            other.transform.GetComponent

            
        }
    }
}
