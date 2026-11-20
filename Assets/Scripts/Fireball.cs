using UnityEditor.UI;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Animator anim;
    private Collider2D pc;
    public float damage;
    public bool hit;
    public float direction;
    public float speed;
    public float lifetime;
    void Start()
    {
        anim = GetComponent<Animator>();
        pc = GetComponent<BoxCollider2D>();

    }

    void Update()
    {   
        if (hit)
        {
            return;
        }
        float movement = speed * direction*Time.deltaTime;
        transform.Translate(movement, 0, 0);
        lifetime += Time.deltaTime;
        if(lifetime > 1.5)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("Explode");
        hit = true; 
        pc.enabled = false;
    }

    public void SetDirection(float dir)
    {
        lifetime = 0;
        direction = dir;
        hit = false;
        gameObject.SetActive(true);

        float scalex = transform.localScale.x;
        if(Mathf.Sign(scalex) != dir)
        {
            scalex = -scalex;
        }
        transform.localScale = new Vector3(scalex, transform.localScale.y, transform.localScale.z);
    }
    public void DestroyFB()
    {
        gameObject.SetActive(false);
    }
}
