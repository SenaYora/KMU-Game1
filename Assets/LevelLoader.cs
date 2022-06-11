using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void loadNextLevel() {
        StartCoroutine(loadLevel());
    }

    IEnumerator loadLevel() {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}
