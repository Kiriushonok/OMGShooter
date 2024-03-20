using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public EnemyAI enemyAI;

    public void GoblinKnifesAttackEvent()
    {
        enemyAI.MobAttack();
    }
}
