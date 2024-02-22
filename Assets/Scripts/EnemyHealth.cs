using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 10;


    private void KillMob()
    {
        Destroy(gameObject);
    }

    public void Injure(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillMob();
        }
    }
}
