using UnityEngine;

public class DecorativeKill : MonoBehaviour
{
    PlayerDeath playerDeath;

    void Start()
    {
        playerDeath = GameObject.Find("PlayerManager").GetComponent<PlayerDeath>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            playerDeath.killPlayer();
        }
    }
}
