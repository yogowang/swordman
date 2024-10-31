using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
private GameObject attackArea = default;
    private Animator animator;

    private bool isAttacking = false;  // State to prevent multiple attacks during animation

    private float timeToAttack = 0;  // Duration of the attack
    private const float DEFAULT_ATTACK_TIME=0.25f;

    void Start()
    {
        // Get the Animator component attached to the player
        animator = GetComponent<Animator>();
        // Set the attack duration based on the attack animation clip's length
        timeToAttack=GetAnimationClip("Stable Sword Inward Slash");
        Debug.Log("Attack duration set to: " + timeToAttack);
        // (Optional) Set up the attack area if needed for detecting collisions
        // Uncomment if you have an attack area and need to enable/disable it
        attackArea = transform.Find("AttackArea").gameObject;
        attackArea.SetActive(false);
    }

    void Update()
    {
        // Listen for attack input (left mouse button in this example)
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("attacking", true);

        // (Optional) Enable the attack area for collision detection
         if (attackArea != null)
        {
            attackArea.SetActive(true);
        }

        // Wait for the duration of the attack
        yield return new WaitForSeconds(timeToAttack);

        // Reset attacking state and animation
        animator.SetBool("attacking", false);

        // (Optional) Disable the attack area after the attack is finished
        if (attackArea != null)
        {
             attackArea.SetActive(false);
         }

        // Allow further attacks after cooldown
        isAttacking = false;
    }
  private float GetAnimationClip(string clipName)
    {
        foreach (var clip in animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == clipName)
            {
                return clip.length;
            }
        }
        Debug.LogWarning("Attack animation clip not found.");
        return DEFAULT_ATTACK_TIME;
    }
}