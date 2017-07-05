using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAggro : MonoBehaviour {

    bool calm = true;

    private void OnTriggerEnter(Collider other)
    {
        if( calm && other.tag == "Player")
        {
            transform.parent.GetComponent<SkeletonController>().playerTransform = other.GetComponent<Transform>();
            transform.parent.GetComponent<Animator>().SetBool("Aggro", true);
            calm = false;
        }
    }

}
