using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10;

    private void Death()
    {
        Destroy(gameObject);
    }

    public void Injure(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }
}
