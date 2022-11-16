using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    public float speed = 3.5f;

    //public event Action<int, int> UpdateHealthBarOnAttack;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamge()
    {
        //UpdateHealthBarOnAttack?.Invoke(CurrentHealth, MaxHealth);
    }
    
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x,0,z).normalized;

        rb.velocity = move * speed + Vector3.up * rb.velocity.y;
        
        if(move.magnitude > 0.1f)
        {
            this.transform.eulerAngles = new Vector3(0, Mathf.Rad2Deg * Mathf.Atan2(rb.velocity.x , rb.velocity.z),0);
        }
        animator.SetFloat("speed", move.magnitude);
    }
}
