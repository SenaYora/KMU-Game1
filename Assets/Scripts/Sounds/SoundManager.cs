using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource click;
    public AudioSource level;
    public AudioSource menu;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void playClickSound()
    {
        click.Play();
    }

    public static void playKeySound()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
    }

    public void playLevelSound(bool play) {
        if (play)
            level.Play();
        else
            level.Stop();
    }

    public void playMenuSong(bool play) {
        if (play)
            menu.Play();
        else
            menu.Stop();
    }
}
