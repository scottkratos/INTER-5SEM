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
    public AsyncOperation load;
    public float timelevel;
    public static Coroutine coroutine = null;

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
        yield return StartCoroutine(IndividualLoader("Level16"));
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
    private IEnumerator Reload()
    {

        player.Instance.CutsceneMode = true;
        if (player.Instance.transform.GetChild(0).transform.GetChild(1).transform.childCount > 0)
        {
            if (player.Instance.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).GetComponent<Vaso>() != null)
            {
                Destroy(player.Instance.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).GetComponent<Vaso>().gameObject);

            }

        }
        if (player.Instance.transform.GetChild(0).transform.GetChild(3).transform.childCount > 0)
        {
            if (player.Instance.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<IceTranform>() != null)
            {
                Destroy(player.Instance.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<IceTranform>().gameObject);

            }

        }
        CutSceneData dataCut = LoadGame.LoadCutscene();
        //PlayerData data = LoadGame.LoadPlayer();
        //print(dataCut.index);
        //Debug.Log(dataCut.level);
        if (dataCut != null)
            switch (dataCut.index)
            {
                case 8:
                    Invoke("CutsceneLoad", .5f);
                    break;
                case 17:
                    Invoke("CutsceneLoad", .5f);
                    break;
                case 26:
                    Invoke("CutsceneLoad", .5f);
                    break;
                case 35:
                    Invoke("CutsceneLoad", .5f);
                    break;
            }
        if (dataCut == null)
        {
            starGame();
        }
        else if (dataCut.index == -1)
        {
            starGame();
        }
        else
        {
            player.Instance.CheatMenu.SetActive(false);
            // "Level" + dataCut.index.ToString()
            yield return StartCoroutine(CheatMenu.Instance.Reload("Level" + dataCut.index.ToString()));
        }
        yield return null;
        coroutine = null;
    }
    public void LoadGameScene()
    {
        if (coroutine == null) coroutine = StartCoroutine(Reload());
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
        MusicControl.Instance.ChangeMusic(index + 3);
        Timeline.initialTime = 0;
        Timeline.Play(Clips[index]);
    }
    public void CutsceneLoad()
    {
        //CutSceneData dataCut = LoadGame.LoadCutscene();
        //Timeline.Play(Clips[dataCut.index]);
    }
}