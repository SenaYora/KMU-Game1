using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public bool onGround;
    public bool onWall;

    [Space]

    [Header("Collision")]

    public float collisionRadius = 0.25f;
    public Transform feetPos;
    public Transform frontCheck;

    void Update()
    {
        onGround = Physics2D.OverlapCircle(feetPos.position, collisionRadius, groundLayer);
        onWall = Physics2D.OverlapCircle(frontCheck.position, collisionRadius, groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(feetPos.position, collisionRadius);
        Gizmos.DrawWireSphere(frontCheck.position, collisionRadius);
    }
}