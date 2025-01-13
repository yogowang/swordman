using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Animator anim;
    void Start()
    {
         player = GameObject.Find("Player").transform;
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    private void Attack(){
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")){
            return;
        }
        transform.LookAt(player);
        anim.Play("Attack", 0, 0);
    }
}
