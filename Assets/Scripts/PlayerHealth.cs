using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public RectTransform valueRectTransform;
    public GameObject gameOverScreen;
    public GameObject gameplayUI;
    public Animator animator;

    private float _maxHealth;

    private void Death()
    {
        gameOverScreen.SetActive(true);
        gameplayUI.SetActive(false);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("death");
    }

    public void Injure(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(health / _maxHealth, 1);
    }

    public void AddHealth(float value)
    {
        health += value;
        health = Mathf.Clamp(health, 0, _maxHealth); ;
        DrawHealthBar();
    }

    private void Start()
    {
        _maxHealth = health;
        DrawHealthBar();
    }
}
