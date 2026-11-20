using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
    public float starthp = 3;
    public float maxhp = 5;
    public Animator anim;
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
        }
    }
    public void TakeDamage(float dmg)
    {
        currenthp = Mathf.Clamp(currenthp - dmg, 0, maxhp);
        if (currenthp > 0)
        {

        }
        else
        {
            anim.SetTrigger("hit");
            Awake();
        }
    }
}
