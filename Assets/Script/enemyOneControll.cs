using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.UI;

public class enemyOneControll : MonoBehaviour
{
    public GameObject player;
    private Animator animator;
    private NavMeshAgent e_naviagent;
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
        e_naviagent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        healthSliderCon = HealthBarUI.healthSlider;
    }

    // Update is called once per frame
    void Update()
    {
        e_naviagent.SetDestination(player.transform.position);

        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            //print("sdfghjk");
            currentHealth -= 10;
            float sliderPercent = (float)currentHealth / maxHealth;
            healthSliderCon.fillAmount = sliderPercent;
        }*/

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        HealthBarUI.UpdateHealthBar(currentHealth, maxHealth);
    }

    void FixedUpdate()
    {
        animator.SetFloat("speed", rb.velocity.magnitude);
    }
}
