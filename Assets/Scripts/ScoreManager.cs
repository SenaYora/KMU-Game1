using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float timer = 0.0f;
    public int deathCount = 0;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
        float seconds = timer % 60;
        int minutes = (int)timer / 60;
    }

    public void addADeathToScore()
    {
        deathCount++;
    }
    public void resetScore()
    {
        timer = 0;
        deathCount = 0;
    }
}
