using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
    public float starthp = 3;
    public float maxhp = 5;
    public Animator anim;
    public bool isstunned = false;
    public bool dead = false;
    public float currenthp { get; private set; } //scripts can use this variable, only this script can change its value

    private void Awake()
    {
        currenthp = starthp;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
                TakeDamage(1);
                anim.SetTrigger("hit");

        }
    }
    public void TakeDamage(float dmg)
    {
        if (dead)
        {
            return;
        }
        currenthp = Mathf.Clamp(currenthp - dmg, 0, maxhp);
        if (currenthp > 0)
        {

        }
        else
        {
            anim.SetTrigger("dead");
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            dead = true;
        }
    }
}
