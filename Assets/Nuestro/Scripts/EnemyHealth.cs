using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;

        if(enemyHealth <= 0)
        {
            { EnemyDead(); }
        }   
    }

    private void EnemyDead()
    {
        Destroy(gameObject);
    }
}
