using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_management : MonoBehaviour
{
    public float maxHP = 100;
    public float hp;
    private int enemyLayer = 7;
    private int playerLayer = 6;
    public GameObject hpBar;
    public GameObject stageManager;
    private GameObject dontDestroy;

    public AudioSource audioSource;
    public AudioClip hurtSFX;
    public AudioClip healSFX;
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

        if (hpBar)
        {
            hpBar.GetComponent<HealthBarUI>().UpdateHealthBar(hp, maxHP);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hurt(float dmg)
    {
        hp -= dmg;
        audioSource.PlayOneShot(hurtSFX, 1.0f);

        if (this.gameObject.layer == playerLayer)
        {
            if (dontDestroy)
                dontDestroy.GetComponent<DontDestroy>().playerGetDamage(dmg);
            
        }

        if (hpBar)
        {
            hpBar.GetComponent<HealthBarUI>().UpdateHealthBar(hp, maxHP);
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
    public void Heal(float heal_num)
    {
        if(hp + heal_num <= maxHP)hp += heal_num;
        else hp = maxHP;
        audioSource.PlayOneShot(healSFX, 1.0f);

        if (this.gameObject.layer == playerLayer)
        {
            if (dontDestroy)
                dontDestroy.GetComponent<DontDestroy>().PlayerGetHeal(heal_num,maxHP);
        }

        if (hpBar)
        {
            hpBar.GetComponent<HealthBarUI>().UpdateHealthBar(hp, maxHP);
        }
        
        // play particle effect
        // play sound effect
    }
}
