using JetBrains.Annotations;
using UnityEngine;

public class FanPushScript : MonoBehaviour
{
    public float force = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Animator anim = collision.GetComponent<Animator>();
            anim.SetTrigger("jump");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Animator anim = collision.GetComponent<Animator>();
        anim.SetBool("isonground",true);
    }
}
