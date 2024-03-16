using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Explosion : MonoBehaviour
{

    public float maxSize = 6;
    public float speed = 12;
    public float damage = 70;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Injure(damage);
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.Injure(damage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= maxSize)
            transform.localScale += Vector3.one * Time.deltaTime * speed;
        else
            Destroy(gameObject);
    }
}
