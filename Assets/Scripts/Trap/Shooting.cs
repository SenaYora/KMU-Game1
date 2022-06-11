using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject itemToShootPrefab;

    [SerializeField]
    private float shootStartDelay = 0.1f;

    [SerializeField]
    private float shootInterval = 2f;

    [SerializeField]
    private float destroyItemDelay = 3f;

    private SpriteRenderer spriteRenderer;
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ShootObject(shootInterval));
    }

    private IEnumerator ShootObject(float delay)
    {
        yield return new WaitForSeconds(delay + shootStartDelay);
        shootStartDelay = 0f;
        var item = (GameObject) Instantiate(itemToShootPrefab, spriteRenderer.bounds.center, transform.rotation);
        Destroy(item, destroyItemDelay);
        StartCoroutine(ShootObject(shootInterval));
    }

}
