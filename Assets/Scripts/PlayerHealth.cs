using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10;
    public RectTransform valueRectTransform;
    public GameObject gameOverScreen;
    public GameObject gameplayUI;

    private float _maxHealth;

    private void Death()
    {
        gameOverScreen.SetActive(true);
        gameplayUI.SetActive(false);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
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

    private void Start()
    {
        _maxHealth = health;
        DrawHealthBar();
    }
}
