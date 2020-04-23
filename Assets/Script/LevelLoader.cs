using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class LevelLoader : MonoBehaviour
{
    public string[] Levels;
    public CanvasRenderer loadImage;
    public Canvas Canvas;
    public PlayableDirector Timeline;
    public TimelineAsset[] Clips;
    public Camera MainMenuCamera;
    AsyncOperation load;

    private void Awake()
    {
        loadImage.gameObject.SetActive(true);
    }
    private void Start()
    {
        StartCoroutine(LateStart());
    }
    private IEnumerator LateStart()
    {
        yield return StartCoroutine(IndividualLoader("Externo"));
        loadImage.gameObject.SetActive(false);
    }
    public void starGame()
    {
        StartCoroutine(MasterLoader());
    }

    private IEnumerator IndividualLoader(string level)
    {
        load = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        while (!load.isDone)
        {
            yield return new WaitForSeconds(.1f);
        }
    }
    private IEnumerator MasterLoader()
    {
        loadImage.gameObject.SetActive(true);
        Coroutine coroutine;
        for (int i = 0; i < Levels.Length; i++)
        {
            if (Levels[i] == "Externo" || Levels[i] == "HUB") continue;
            coroutine = StartCoroutine(IndividualLoader(Levels[i]));
            yield return coroutine;
        }

        loadImage.gameObject.SetActive(false);
        Timeline.Play(Clips[0]);
    }
}