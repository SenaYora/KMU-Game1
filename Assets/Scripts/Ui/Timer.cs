using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float countSeconds = 10f;
    float timeMultiplier;
    Slider slider;
    bool isDead = false;
    PlayerDeath playerDeath;
    bool hasAlreadyMoved = false;

    void Start()
    {
        slider = GetComponent<Slider>();
        playerDeath = GameObject.Find("PlayerManager").GetComponent<PlayerDeath>();
        timeMultiplier = slider.value / countSeconds;
    }

    void Update()
    {
        if (Input.anyKeyDown)
            hasAlreadyMoved = true;
    }

    void LateUpdate()
    {
        if (!hasAlreadyMoved)
            return;
        if (slider.value > 0)
            slider.value -= Time.deltaTime * timeMultiplier;
        if (slider.value <= 0 && !isDead)
        {
            isDead = true;
            playerDeath.killPlayer();
        }
    }

    public void AddTime(float addedTime)
    {
        slider.value += addedTime * timeMultiplier;
    }
}
