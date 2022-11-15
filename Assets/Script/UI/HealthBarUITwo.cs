using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HealthBarUITwo : MonoBehaviour
{
    public GameObject healthUIPrefab;
    public Transform barPoint;
    static public Image healthSlider;
    
    int currentHealth;
    //
    static public GameObject UIbar;
    static public Transform UIbarTransform;
    //Update the position with barpoint
    Transform cam;
    //Ensure UI face the camera
    GameObject canvas;
    Quaternion startRotation;

    void Awake()
    {
        cam = Camera.main.transform;
    
        canvas = gameObject.transform.GetChild(0).gameObject;
        UIbar = Instantiate(healthUIPrefab, canvas.transform);
        UIbarTransform =  UIbar.transform;
        healthSlider = UIbarTransform.GetChild(0).GetComponent<Image>();
        UIbar.gameObject.SetActive(true);
    }

    

    static public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if(currentHealth <= 0)
        {
            Destroy(UIbar.gameObject);
            Destroy(UIbarTransform.parent.gameObject);
        }
    }

    void LateUpdate()
    {
        if(UIbar != null)
        {
            UIbarTransform.position = barPoint.position;
            UIbarTransform.forward = -cam.forward;
        }
        
    }

}
