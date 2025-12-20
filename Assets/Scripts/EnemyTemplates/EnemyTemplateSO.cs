using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Template", fileName = "EnemyTemplate")]
public class EnemyTemplateSO : ScriptableObject
{
    [Header("Detection")]
    public float detectionRadius = 5f;
    public float rotationSpeedWhileAttacking = 10f;

    [Header("Movement")]
    public float attackRange = 1.5f;
    public float chaseSpeed = 4f;

    [Header("Combo Timing")]
    public float comboInterval = 0.3f;
    public float comboResetDelay = 1f;

    [Header("Combo Sequence")]
    public List<AttackSO> comboSequence = new List<AttackSO>();
}
