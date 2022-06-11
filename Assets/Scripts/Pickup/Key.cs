using UnityEngine;

public class Key : MonoBehaviour
{
    AudioSource audioSource;
    KeyManager keyManager;
    Timer timer;

    public float addedTime = 1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        keyManager = GameObject.Find("KeyManager").GetComponent<KeyManager>();
        timer = GameObject.FindGameObjectWithTag("Slider").GetComponent<Timer>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            SoundManager.playKeySound();
            keyManager.AddKey();
            timer.AddTime(addedTime);
            Destroy(transform.parent.gameObject);
        }
    }
}
