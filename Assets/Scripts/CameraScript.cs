using System.Security.Cryptography;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float speed = 0.2f;
    private float currentposx;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        currentposx = transform.position.x;
    }

    void Update()
    {
        Vector3 target = new Vector3(currentposx, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, speed);
    }
    public void ChangeRoom(Transform newroom)
    {
        if(newroom != null)
        {
            currentposx = newroom.position.x;
        }
    }
}
