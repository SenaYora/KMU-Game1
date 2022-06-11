using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyManager : MonoBehaviour
{
    public int keyMax;
    public int currentKey = 0;

    void Update()
    {
        if (keyMax == currentKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void AddKey()
    {
        currentKey++;
    }

    public int GetCurrentKey()
    {
        return currentKey;
    }

    public int GetMaxKey()
    {
        return keyMax;
    }
}
