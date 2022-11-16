using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public float playerHealth;
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPlayerHealth(float health){
        playerHealth = health;
    }

    public void playerGetDamage(float dmg){
        if(playerHealth - dmg >= 0){
            playerHealth = playerHealth - dmg;
        }else{
            playerHealth = 0;
        }
    }

    public float getPlayerHealth(){
        return playerHealth;
    }
}
