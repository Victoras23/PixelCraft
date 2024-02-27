using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameOverbg gameover;
    private int currentValue=100;

    public void Start()
    {
        slider.maxValue=100;
        slider.value=100;
    }
    
    public void SetHealth(int health)
    {
        currentValue=currentValue-health;
        if (currentValue <=0)
        {
            gameover.set();
        }
        else 
        {
            slider.value=currentValue;
        }
    }
    
}
