using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string[] Levels;
    public Canvas canvas;
    float loadlevel, finalLoad;
    AsyncOperation load;
    private void Start()
    {

        StartCoroutine(MasterLoader());

    }
    private void Update()
    {
        if (finalLoad < loadlevel)
        {
            canvas.gameObject.SetActive(true);
            finalLoad += Time.deltaTime;


        }
        else
        {
            canvas.gameObject.SetActive(false);
        }

        Debug.Log(finalLoad);
    }

    private IEnumerator IndividualLoader(string level)
    {
        load = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);

        while (!load.isDone)
        {
            yield return new WaitForSeconds(.01f);
            loadlevel += load.progress / .9f;
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






