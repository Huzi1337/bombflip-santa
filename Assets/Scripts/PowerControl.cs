using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerControl : MonoBehaviour
{
    float timer = 2f;
    private int power = 1;
    private int powerCap = 1;
    Image image;


    private void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        if(power < powerCap)
        {
            RechargePower(Time.deltaTime);
        }
    }

    void RechargePower(float deltaTime)
    {
        timer -= deltaTime;
        
        if(timer <= 0)
        { 
            power++;
            image.enabled = true;
            timer = 2f;
        }
    }
    public void UsePower()
    {
        if (power > 0) 
        {
            power--;
            image.enabled = false;
        }
        
    }

    public int GetPower()
    {
        return power;
    }
}
