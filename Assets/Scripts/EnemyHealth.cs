using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float xp_per_Kill = 20;

    public PlayerProgress playerProgress;

    private void KillMob()
    {
        Destroy(gameObject);
        playerProgress.AddXP(xp_per_Kill);
    }

    public void Injure(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillMob();
        }
    }

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }
}
