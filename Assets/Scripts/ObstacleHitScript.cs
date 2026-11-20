using System.Collections;
using UnityEngine;

public class ObstacleHitScript : MonoBehaviour
{
    public Animator anim;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("hit");
            
        }
    }
}
