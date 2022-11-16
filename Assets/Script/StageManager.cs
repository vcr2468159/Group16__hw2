using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int numberOfEnemies = 2;
    public string nextStage;
    public string nowStage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyKilled()
    {
        numberOfEnemies--;
        if (numberOfEnemies <= 0)
        {
            SceneManager.LoadScene(nextStage);
        }
    }

    public void playerDie()
    {
        SceneManager.LoadScene(nowStage);
    }
}
