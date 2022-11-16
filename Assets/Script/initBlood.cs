using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initBlood : MonoBehaviour
{
    private GameObject dontDestroy;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");
        if (objs.Length > 1)
        {
            Debug.Log("Multiple DontDestroy Object!");
        }
        dontDestroy = objs[0];

        dontDestroy.GetComponent<DontDestroy>().setPlayerHealth(100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
