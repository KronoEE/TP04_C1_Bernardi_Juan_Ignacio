using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] heartIcons; 

    private void Start()
    {
        UpdateHearts(GameManager.Instance.Health); 
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].enabled = i < currentHealth;
        }
    }
}
