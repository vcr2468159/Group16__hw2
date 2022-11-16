using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float killAfterTime = 10;
    public float movingSpeed = 10;
    public float attackPower = 10;
    private int playerLayer = 6;
    private Vector3 movingDirection;
    // Start is called before the first frame update
    void Start()
    {
        //movingDirection = this.gameObject.transform.forward;
        Destroy(this.gameObject, killAfterTime);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            other.gameObject.GetComponent<hp_management>().hurt(attackPower);
            Destroy(this.gameObject);
        }
    }
}
