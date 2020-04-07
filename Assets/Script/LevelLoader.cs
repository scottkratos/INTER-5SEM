using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string[] Levels;

    private void Start()
    {
        StartCoroutine(MasterLoader());
    }

    private IEnumerator IndividualLoader(string level)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        while (!load.isDone)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator MasterLoader()
    {
        Coroutine coroutine;
        for (int i = 0; i < Levels.Length; i++)
        {
            coroutine = StartCoroutine(IndividualLoader(Levels[i]));
            yield return coroutine;
        }
    }
}
