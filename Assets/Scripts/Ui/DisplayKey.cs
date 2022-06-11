using UnityEngine;
using TMPro;


public class DisplayKey : MonoBehaviour
{
    KeyManager keyManager;

    public TextMeshProUGUI text;

    void Start()
    {
        keyManager = GameObject.Find("KeyManager").GetComponent<KeyManager>();
    }

    void Update()
    {
        text.text = keyManager.GetCurrentKey() + "/" + keyManager.GetMaxKey();
    }
}
