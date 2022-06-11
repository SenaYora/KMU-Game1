using UnityEngine;

public class ProjectileTrap : MonoBehaviour
{
    private PlayerDeath playerDeath;

    private void Start()
    {
        playerDeath = GameObject.Find("PlayerManager").GetComponent<PlayerDeath>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            playerDeath.killPlayer();
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
