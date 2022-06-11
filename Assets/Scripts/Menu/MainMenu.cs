using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SoundManager soundManager;
    private LevelLoader levelLoader;

    private void Start()
    {
        soundManager = GameObject.FindWithTag("Music").GetComponent<SoundManager>();
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    public void playGame()
    {
        soundManager.playClickSound();
        soundManager.playMenuSong(false);
        soundManager.playLevelSound(true);
        levelLoader.loadNextLevel();
        SceneManager.LoadScene("Level 1");
    }

    public void quitGame()
    {
        soundManager.playClickSound();
        Application.Quit();
    }
}
