using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyTwoControl : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public float offset = 1.0f;
    private GameObject firedBullet;
    private Vector3 playerPos;
    private Vector3 myPosition;
    public float playerHeight = 1.5f;
    public float fireRate = 1.0f; // fire frequency of bullet
    private float timeout = 0;


    void Start()
    {
        timeout = fireRate;
    }

    // Update is called once per frame
    void Update()
    {

        playerPos = player.transform.position;
        playerPos.y += playerHeight / 2;
        myPosition = this.transform.position;
        myPosition.y += this.gameObject.GetComponent<CapsuleCollider>().height / 2;
        this.transform.forward = playerPos - myPosition;

        timeout -= Time.deltaTime;
        if(timeout <= 0)
        {
            timeout = fireRate;
            firedBullet = Instantiate(bulletPrefab, myPosition + this.transform.forward * offset, this.transform.rotation);
            //print(this.transform.forward);
        }
    }
}