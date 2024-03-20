using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 20;
    public float attackDistance = 0.65f;
    public bool _isPlayerNoticed;

    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _playerHealth;

    private void PickPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickPatrolPoint();
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

    private void EnemyVisionUpdate()
    {
        
        _isPlayerNoticed = false;
        if (!_playerHealth.IsAlive()) return;
        var ditection = player.transform.position - transform.position;

        if (Vector3.Angle(transform.forward, ditection) < viewAngle)
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, ditection, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void AttackUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _isPlayerNoticed) 
        {
<<<<<<< HEAD
            animator.SetBool("attack", true);
            
=======
            _playerHealth.Injure(damage * Time.deltaTime);
>>>>>>> parent of cbd3b82 (Started adding goblin with knifes animations)
        }
    }

    public void MobAttack()
    {
        animator.SetBool("attack", false);
        if (!_isPlayerNoticed) return;
        if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance + attackDistance) return;
        _playerHealth.Injure(damage);
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = player.GetComponent<PlayerHealth>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyVisionUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
    }

}
