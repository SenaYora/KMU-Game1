using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
