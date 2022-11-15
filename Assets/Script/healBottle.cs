using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healBottle : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "player"){
            Destroy(gameObject);
            
        }
    }
}
