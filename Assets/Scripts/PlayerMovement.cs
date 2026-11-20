using UnityEditor.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5f;
    float jumpheight = 10f;
    public Rigidbody2D rb;
    public bool onground = true;
    public Animator anim;
    public Transform t;
    public GameObject rs;
    public GameObject player;
    public HealthScript hs;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        rb.linearVelocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.linearVelocity.y);
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("iswalking", false);
            anim.SetBool("isidle", true);
        }
        else
        {
            anim.SetBool("iswalking", true);
            anim.SetBool("isidle", false);
            if (Input.GetAxisRaw("Horizontal") <= 0)
            {
                t.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                t.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        if (Input.GetKey(KeyCode.Space) && onground)
        {
            rb.linearVelocity = new Vector2(0, jumpheight);
            onground = false;
            anim.SetBool("isonground", false);
            anim.SetTrigger("jump");
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground" && !onground)
        {
            onground = true;
            anim.SetBool("isonground", true);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Heal_Item")
        {
            GetComponent<HealthScript>().TakeDamage(-1);
        }
    }
    public void SendToRespawnPos()
    {
        player.transform.position = rs.transform.position;
        player.SetActive(false);
    }
    public bool CanAttack()
    {

        return (onground && Input.GetAxisRaw("Horizontal") == 0);
    }
}
