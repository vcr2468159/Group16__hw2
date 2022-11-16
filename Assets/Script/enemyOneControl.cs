using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyOneControl : MonoBehaviour
{
    public GameObject player;
    private Animator animator;
    private NavMeshAgent e_naviagent;
    private Rigidbody rb;
    //public Image healthSliderCon;
    private int playerLayer = 6;
    public float attackPower = 10;
    //public CharacterStats currentState;

    //public int currentHealth = 100;
    //public int maxHealth = 100;
    
    void Awake()
    {
        //currentState = GetComponent<CharacterStats>;
    }

    void Start()
    {
        e_naviagent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //healthSliderCon = HealthBarUI.healthSlider;
    }

    // Update is called once per frame
    void Update()
    {
        e_naviagent.SetDestination(player.transform.position);

        /*if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }*/
        //HealthBarUI.UpdateHealthBar(currentHealth, maxHealth);
    }

    void FixedUpdate()
    {
        animator.SetFloat("speed", rb.velocity.magnitude);
    }

    // Detect if player is attacked by enemy
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == playerLayer)
        {
            collision.collider.gameObject.GetComponent<hp_management>().hurt(attackPower);
            Debug.Log("hurt");
        }
        //Debug.Log(collision.collider);
    }
}
