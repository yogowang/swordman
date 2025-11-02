using UnityEngine;

public class AttackEnabler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private  Weapon weapon;
    void Start()
    {
        weapon=GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {

    }
     public void EnableTriggerBox()
    {
        weapon.EnableTriggerBox();
    }

    public void DisableTriggerBox()
    {
        weapon.DisableTriggerBox();
    }
}
