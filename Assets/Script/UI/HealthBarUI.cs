using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    /*public GameObject healthUIPrefab;
    public Transform barPoint;*/
    public Image healthSlider;
    
    //int currentHealth;
    
    //public GameObject UIbar;
    //public Transform UIbarTransform;
    //Update the position with barpoint
    Transform cam;
    //Ensure UI face the camera
    //GameObject canvas;
    //Quaternion startRotation;

    void Awake()
    {
        cam = Camera.main.transform;
    
        /*canvas = GameObject.Find("HealthBarCanvas");
        UIbar = Instantiate(healthUIPrefab, canvas.transform);
        UIbarTransform = UIbar.transform;
        healthSlider = UIbarTransform.GetChild(0).GetComponent<Image>();*/
        //UIbar.gameObject.SetActive(true);

        healthSlider = this.gameObject.transform.GetChild(0).GetComponent<Image>();
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        /*if (currentHealth <= 0)
        {
            Destroy(UIbar.gameObject);
            Destroy(UIbarTransform.parent.gameObject);
        }*/

        healthSlider.fillAmount = currentHealth / maxHealth;
    }

    void LateUpdate()
    {
        /*if (UIbar != null)
        {
            UIbarTransform.position = barPoint.position;
            UIbarTransform.forward = -cam.forward;
        }*/
        this.gameObject.transform.forward = -cam.forward;
    }

}
