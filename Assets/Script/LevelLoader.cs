using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string[] Levels;
    public CanvasRenderer loadImage;
    public Canvas Canvas;
    float loadlevel, finalLoad;
    AsyncOperation load;
    private void Start()
    {



    }
    public void starGame()
    {
        StartCoroutine(MasterLoader());
       

    }
    private void Update()
    {
        if (finalLoad < loadlevel)
        {
            loadImage.gameObject.SetActive(true);
            finalLoad += Time.deltaTime;


        }
        else
        {
            loadImage.gameObject.SetActive(false);
           
        }

        Debug.Log(finalLoad);
    }

    private IEnumerator IndividualLoader(string level)
    {
        load = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);

        while (!load.isDone)
        {
            yield return new WaitForSeconds(.1f);
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






