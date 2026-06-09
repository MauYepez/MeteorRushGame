using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    public Image[] healthIcons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveIcon()
    {
        for (int i = healthIcons.Length - 1; i >= 0; i--)
        {
            if (healthIcons[i].enabled)
            {
                healthIcons[i].enabled = false;
                return;
            }
        }
    }
}
