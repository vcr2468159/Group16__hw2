using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_management : MonoBehaviour
{
    public float maxHP = 100;
    public float hp;
    private int enemyLayer = 7;
    private int playerLayer = 6;
    public GameObject stageManager;
    private GameObject dontDestroy;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;

        if (this.gameObject.layer == playerLayer)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");
            if (objs.Length > 1)
            {
                Debug.LogError("Multiple DontDestroy Object!");
            }
            dontDestroy = objs[0];
            //Debug.Log(dontDestroy);
            hp = dontDestroy.GetComponent<DontDestroy>().getPlayerHealth();
        }

        stageManager = GameObject.Find("StageManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hurt(float dmg)
    {
        hp -= dmg;

        if (this.gameObject.layer == playerLayer)
        {
            dontDestroy.GetComponent<DontDestroy>().playerGetDamage(dmg);
        }
        
        // play particle effect
        // play sound effect

        if (hp <= 0)
        {
            if (this.gameObject.layer == enemyLayer)
            {
                // score
                // call stage manager to check if stage switching needed
                stageManager.GetComponent<StageManager>().enemyKilled();
            }
            else if (this.gameObject.layer == playerLayer)
            {
                // restart
            }
            Destroy(this.gameObject);
        }
    }
}
