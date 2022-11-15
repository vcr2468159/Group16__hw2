using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.UI;

public class enemyTwoControll : MonoBehaviour
{
    public GameObject player;
    public Vector3 direction;
    public GameObject bullet;
    GameObject prefab;

    
    private Rigidbody rb;
    public Image healthSliderCon;
    //public CharacterStats currentState;

    static public int currentHealth = 100;
    static public int maxHealth = 100;
    
    void Awake() 
    {
        //currentState = GetComponent<CharacterStats>;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthSliderCon = HealthBarUI.healthSlider;
        //GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //print("sdfghjk");
            currentHealth -= 10;
            float sliderPercent = (float)currentHealth / maxHealth;
            healthSliderCon.fillAmount = sliderPercent;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            prefab = Instantiate(bullet, this.transform);
        }

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        HealthBarUI.UpdateHealthBar(currentHealth, maxHealth);
    }
}


