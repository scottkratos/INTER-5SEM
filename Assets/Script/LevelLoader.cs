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
    public static LevelLoader Instance;
    AsyncOperation load;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        loadImage.gameObject.SetActive(true);
    }
    private void Start()
    {
        StartCoroutine(LateStart());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Timeline.time = 2200;

        }
    }
    private IEnumerator LateStart()
    {
        yield return StartCoroutine(IndividualLoader("Externo"));
        loadImage.gameObject.SetActive(false);
    }
    public void starGame()
    {
        foreach (GameObject go in HubEvents.Instance.Estatuas)
        {
            foreach (Material mat in go.GetComponent<EstatuasMats>().materials)
            {
                mat.SetFloat("Value", 0);
            }
        }
        StartCoroutine(MasterLoader());
    }

    private IEnumerator IndividualLoader(string level)
    {
        load = SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        while (!load.isDone)
        {
            yield return null;
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
        MainMenuCamera.gameObject.SetActive(false);
        Timeline.initialTime = 0;
        Timeline.Play(Clips[0]);
        MusicControl.Instance.ChangeMusic(2);
    }
    public void Cutscene(int index)
    {
        MusicControl.Instance.ChangeMusic(index);
        Timeline.initialTime = 0;
        Timeline.Play(Clips[index]);
    }
}