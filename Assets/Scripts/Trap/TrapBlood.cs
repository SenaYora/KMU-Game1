using UnityEngine;

public class TrapBlood : MonoBehaviour
{
    public Sprite newSprite;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
