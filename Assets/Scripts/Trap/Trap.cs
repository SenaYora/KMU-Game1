using UnityEngine;

public class Trap : MonoBehaviour
{
    private PlayerDeath playerDeath;

    private void Start()
    {
        playerDeath = GameObject.Find("PlayerManager").GetComponent<PlayerDeath>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            playerDeath.killPlayer();
        }
    }
}
