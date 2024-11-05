using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 

using UnityEngine;

public class HealthBar : MonoBehaviour
{
     [SerializeField] private Image healthBar;
     public void UpdateHealth(float fraction){
        healthBar.fillAmount=fraction;
     }
}
