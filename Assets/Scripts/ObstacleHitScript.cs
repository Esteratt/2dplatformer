using System.Collections;
using UnityEngine;

public class ObstacleHitScript : MonoBehaviour
{
    public Animator anim;
    public HealthScript hs;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("hit");
            hs.TakeDamage(1);
        }
    }
}
