using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI deaths;
    ScoreManager scoreManager;
    private SoundManager soundManager;

    void Start()
    {
        soundManager = GameObject.FindWithTag("Music").GetComponent<SoundManager>();
        scoreManager = GameObject.FindWithTag("Score").GetComponent<ScoreManager>();
        soundManager.playLevelSound(false);
        soundManager.playMenuSong(true);
        float twoDigitScore = Mathf.Round(scoreManager.timer * 100f) / 100f;
        int minutes = (int)scoreManager.timer / 60;

        time.text = "Time: " + (minutes > 0 ? minutes + " min " : "") + (twoDigitScore % 60).ToString() + " sec";
        deaths.text = "Deaths: " + scoreManager.deathCount.ToString();
    }

    public void playGame()
    {
        scoreManager.resetScore();
        soundManager.playClickSound();
        soundManager.playLevelSound(true);
        soundManager.playMenuSong(false);
        SceneManager.LoadScene("Level 1");
    }

    public void quitGame()
    {
        soundManager.playMenuSong(false);
        soundManager.playClickSound();
        Application.Quit();
    }
}
