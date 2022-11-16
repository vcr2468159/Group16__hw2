using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.UI;

public class enemyTwoControll : MonoBehaviour
{
    public Vector3 direction;
    public GameObject player;
    public GameObject bullet;
    public float offset = 1.0f;
    GameObject prefab;
    Transform cam;
    Vector3 playerTrans;
    float rate = 0.5f;//the frequency of bullet

    private Rigidbody rb;
    public Image healthSliderCon;

    static public int currentHealth = 100;
    static public int maxHealth = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //healthSliderCon = HealthBarUI.healthSlider;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= 20;
            float sliderPercent = (float)currentHealth / maxHealth;
            healthSliderCon.fillAmount = sliderPercent;
        }*/

        playerTrans = player.transform.position;
        //playerTrans += new Vector3(0, offset, 0);
        this.transform.forward = playerTrans - this.transform.position;
        //this.transform.forward = new Vector3(this.transform.forward.x, 0, this.transform.forward.z);

        rate -= Time.deltaTime;
        if(rate<=0){
            rate = 0.5f;
            prefab = Instantiate(bullet, this.transform.position + new Vector3(0, offset, 0), this.transform.rotation);
            print(this.transform.forward);
            prefab.GetComponent<Rigidbody>().AddForce(this.transform.forward * 300.0f);
        }

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        HealthBarUITwo.UpdateHealthBar(currentHealth, maxHealth);
        
    }

}


