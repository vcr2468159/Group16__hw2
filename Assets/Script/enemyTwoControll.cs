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
    GameObject prefab;
    Transform cam;
    float rate = 0.5f;//the frequency of bullet

    private Rigidbody rb;
    public Image healthSliderCon;

    static public int currentHealth = 100;
    static public int maxHealth = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthSliderCon = HealthBarUI.healthSlider;
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

        direction = player.transform.position - this.transform.position;

        rate -= Time.deltaTime;
        if(rate<=0){
            rate = 0.5f;
            prefab = Instantiate(bullet, this.transform);
            prefab.GetComponent<Rigidbody>().AddForce(direction * 500.0f);
        }
        this.transform.forward = direction;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        HealthBarUITwo.UpdateHealthBar(currentHealth, maxHealth);
        
    }

}


