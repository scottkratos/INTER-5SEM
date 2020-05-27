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
    bool starGameOn;
    public AsyncOperation load;
    public float timelevel;

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

            Timeline.time = Timeline.duration;

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
        starGameOn = true;
        StartCoroutine(MasterLoader());

    }
    public void LoadGameScene()
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
        if (starGameOn)
            Timeline.Play(Clips[0]);
        if (starGameOn == false)
        {
            player.Instance.CutsceneMode = false;
            CutSceneData dataCut = LoadGame.LoadCutscene();
            PlayerData data = LoadGame.LoadPlayer();
            Debug.Log(dataCut.level);
            if (data.cutSceneLoad == true)
                switch (dataCut.level)
                {
                    case 9:
                        Invoke("CutsceneLoad", .5f);
                        break;
                    case 7:
                        Invoke("CutsceneLoad", .5f);
                        break;
                    case 8:
                        Invoke("CutsceneLoad", .5f);
                        break;
                    case 95:
                        Invoke("CutsceneLoad", .5f);
                        break;


                }




        }
        MusicControl.Instance.ChangeMusic(2);

    }
    public void Cutscene(int index)
    {
        MusicControl.Instance.ChangeMusic(index);
        Timeline.initialTime = 0;
        Timeline.Play(Clips[index]);
    }
    public void CutsceneLoad()
    {
        CutSceneData dataCut = LoadGame.LoadCutscene();
        Timeline.Play(Clips[dataCut.index]);
    }






}