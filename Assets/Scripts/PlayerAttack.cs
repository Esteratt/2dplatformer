using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement pm;
    private float cooldown = 0f;
    public float attacktimer;
    public GameObject firepoint;
    public GameObject[] fb;
    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
    }

    void Update()
    {   
        if (Input.GetMouseButton(0) && pm.CanAttack() && attacktimer < cooldown)
        {
            anim.SetTrigger("attack");
            cooldown = 0;
            GameObject fireball = fb[FindFireball()];
            fireball.transform.position = firepoint.transform.position;
            fireball.GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
        cooldown += Time.deltaTime;
    }
    public int FindFireball()
    {
        for(int i = 0; i < fb.Length; i++)
        {
            if (!fb[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
