using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool bisPowerUpHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (bisPowerUpHealth)
            {
                GameManager.Instance.IncreaseHealth();

            } else if (!bisPowerUpHealth)
            {
                GameManager.Instance.SetInvincible();
            }
            Debug.Log("Power-up collected!");
            Destroy(gameObject); 
        }
    }



}
