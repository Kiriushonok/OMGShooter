using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Animator animator;
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 20;

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
        var ditection = player.transform.position - transform.position;
        _isPlayerNoticed = false;

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
        if (_isPlayerNoticed){
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) 
        {
                _playerHealth.Injure(damage * Time.deltaTime);
            }
        }
    }

    public void MobAttack()
    {
        if (!_isPlayerNoticed) return;
        if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance) return;
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
