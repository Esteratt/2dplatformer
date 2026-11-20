using UnityEngine;

public class SwitchRoomScript : MonoBehaviour
{
    public CameraScript cs;
    public Transform previousroom;
    public Transform nextroom;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.transform.position.x < transform.position.x)
            {
                cs.ChangeRoom(nextroom);
            }
            else
            {
                cs.ChangeRoom(previousroom);
            }
        }
    }
}
