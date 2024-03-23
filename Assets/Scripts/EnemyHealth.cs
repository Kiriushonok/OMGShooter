using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float xp_per_Kill = 20;

    public PlayerProgress playerProgress;

    public Animator animator;

    private void KillMob()
    {
        playerProgress.AddXP(xp_per_Kill);
        animator.SetTrigger("death");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    public void Injure(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            KillMob();
        }

        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }
}
