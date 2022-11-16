using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBottleCreater : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healItem;
    public GameObject PlayerPos;

    void Ins_Objs()
    {
        Instantiate(healItem , 
        PlayerPos.transform.position+new Vector3(Random.Range(-20f,20f),2f,Random.Range(-20f,20f)),
        healItem.transform.rotation);
    }

    void Start()
    {
        Ins_Objs();
        Ins_Objs();
        
    }
}
