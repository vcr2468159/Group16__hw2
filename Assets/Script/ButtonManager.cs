using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ScrollView;
    public GameObject Initials;
    
    void Start()
    {
        ScrollView.SetActive(false);
        Initials.SetActive(true);
    }

    public void StartPlay()
    {
        SceneManager.LoadScene("FirstStage");
    }

    public void HowToPlay()
    {
        ScrollView.SetActive(true);
        Initials.SetActive(false);
    }

    public void Back()
    {
        ScrollView.SetActive(false);
        Initials.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
