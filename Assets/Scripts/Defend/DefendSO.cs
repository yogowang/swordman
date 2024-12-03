using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Defends/Normal Defend")]
public class DefendSO : ScriptableObject
{
    public AnimatorOverrideController animatorOV;
    [SerializeField]
    private float _damageReductionRate;

    public float DamageReductionRate
    {
        get => _damageReductionRate;
        set => _damageReductionRate = Mathf.Clamp(value, 0f, 1f);
    }
}
