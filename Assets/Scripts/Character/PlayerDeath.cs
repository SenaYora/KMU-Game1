using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject prefabBlood;
    private GameObject player;
    public ScoreManager scoreManager;

    public void killPlayer()
    {
        StartCoroutine(killPlayerAndReload());
    }

    IEnumerator killPlayerAndReload()
    {
        scoreManager = GameObject.FindWithTag("Score").GetComponent<ScoreManager>();
        scoreManager.addADeathToScore();
        player = GameObject.FindWithTag("Player");

        if (player)
        {
            GameObject bloodSpray = Instantiate(prefabBlood, player.transform.position + new Vector3(0, 0, -1), player.transform.rotation);
            Destroy(bloodSpray, 3f);
            Destroy(player);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
