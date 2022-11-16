using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healBottle : MonoBehaviour
{
    public float heal_num;

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player"){
            Destroy(gameObject);
            other.GetComponent<hp_management>().Heal(heal_num);
        }
    }
}
