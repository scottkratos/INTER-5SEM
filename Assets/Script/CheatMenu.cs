using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatMenu : MonoBehaviour
{
    public GameObject loading;
    public static CheatMenu Instance;
    private string[] Levels = new string[] 
    {
        "Level1",
        "Level2",
        "Level3",
        "Level4",
        "Level5",
        "Level6",
        "Level7",
        "Level8",
        "Level9",
        "Level10",
        "Level11",
        "Level12",
        "Level13",
        "Level14",
        "Level15",
        "Level16",
        "Level17",
        "Level18",
        "Level19",
        "Level20",
        "Level21",
        "Level22",
        "Level23",
        "Level24",
        "Level25",
        "Level26",
        "Level27",
        "Level28",
        "Level29",
        "Level30",
        "Level31",
        "Level32",
    };
    private int Cutscene;

    private void Start()
    {
        Instance = this;
    }
    public void ChangeLevel(string level)
    {
        player.Instance.CheatMenu.SetActive(false);
        StartCoroutine(Reload(level));
    }
    public IEnumerator Reload(string level)
    {
        player.Instance.CutsceneMode = true;
        MusicControl.Instance.ChangeMusic(1);
        SetupLoading(true);
        SaturationControl.lastIndex = System.Array.IndexOf(Levels, level);
        List<string> listUnload = new List<string>();
        bool haveExterno = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == "Externo")
            {
                haveExterno = true;
            }
            if (SceneManager.GetSceneAt(i).name != "HUB" && SceneManager.GetSceneAt(i).name != "Externo")
            {
                listUnload.Add(SceneManager.GetSceneAt(i).name);
            }
        }
        if (haveExterno) yield return SceneManager.UnloadSceneAsync("Externo");
        while (listUnload.Count > 0)
        {
            yield return SceneManager.UnloadSceneAsync(listUnload[0]);
            listUnload.RemoveAt(0);
            yield return new WaitForSeconds(0.2f);
        }
        int indexToStop = System.Array.IndexOf(Levels, level);
        int startPoint = 0;
        if (indexToStop >= 0 && indexToStop <= 7)
        {
            indexToStop += 0;
            startPoint = 0;
            for (int i = 0; i < LevelLoader.Instance.Levels.Length; i++)
            {
                yield return SceneManager.LoadSceneAsync(LevelLoader.Instance.Levels[i], LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.2f);
            }
        }
        else if (indexToStop >= 8 && indexToStop <= 15)
        {
            indexToStop+= 1;
            startPoint = 7;
        }
        else if (indexToStop >= 16 && indexToStop <= 23)
        {
            indexToStop += 2;
            startPoint = 15;
        }
        else if (indexToStop >= 24 && indexToStop <= 31)
        {
            indexToStop += 3;
            startPoint = 23;
        }
        for (int r = startPoint; r < indexToStop; r++)
        {
            for (int i = 0; i < HubEvents.Instance.levels[r].LevelLoad.Length; i++)
            {
                yield return SceneManager.LoadSceneAsync(HubEvents.Instance.levels[r].LevelLoad[i], LoadSceneMode.Additive);
                yield return new WaitForSeconds(0.2f);
            }
            for (int i = 0; i < HubEvents.Instance.levels[r].LevelUnload.Length; i++)
            {
                for (int p = 0; p < SceneManager.sceneCount; p++)
                {
                    if (SceneManager.GetSceneAt(p).name == HubEvents.Instance.levels[r].LevelUnload[i])
                    {
                        SceneManager.UnloadSceneAsync(HubEvents.Instance.levels[r].LevelUnload[i]);
                        yield return new WaitForSeconds(0.2f);
                    }
                }
            }
        }
        yield return new WaitForEndOfFrame();
        player.Instance.transform.position = HubEvents.transforms[indexToStop].transform.forward.normalized * -0.5f + new Vector3(HubEvents.transforms[indexToStop].transform.position.x, HubEvents.transforms[indexToStop].transform.position.y + 2, HubEvents.transforms[indexToStop].transform.position.z);
        player.Instance.transform.rotation = Quaternion.Euler(HubEvents.transforms[indexToStop].transform.rotation.eulerAngles.x, HubEvents.transforms[indexToStop].transform.rotation.eulerAngles.y, HubEvents.transforms[indexToStop].transform.rotation.eulerAngles.z);
        SetupLoading(false);
        player.Instance.CutsceneMode = false;
        CutscenePrepare cp = new CutscenePrepare();
        int indexToSave = 0;
        char A, B;
        string final;
        if (level.Length > 6)
        {
            A = level[5];
            B = level[6];
            final = A.ToString() + B.ToString();
        }
        else
        {
            A = level[5];
            final = A.ToString();
        }
        indexToSave = int.Parse(final);
        cp.index = indexToSave;
        LoadGame.Savecutscene(cp);
    }
    public void ChangeCutscene(int index)
    {
        player.Instance.CheatMenu.SetActive(false);
        StartCoroutine(CutsceneOverride(index));
    }
    private IEnumerator CutsceneOverride(int index)
    {
        SetupLoading(true);
        List<string> listUnload = new List<string>();
        bool haveExterno = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == "Externo")
            {
                haveExterno = true;
            }
            else
            {
                if (SceneManager.GetSceneAt(i).name != "HUB")
                {
                    listUnload.Add(SceneManager.GetSceneAt(i).name);
                }
            }
        }
        if (haveExterno) yield return SceneManager.UnloadSceneAsync("Externo");
        while (listUnload.Count > 0)
        {
            yield return SceneManager.UnloadSceneAsync(Levels[System.Array.IndexOf(Levels, listUnload[0])]);
            listUnload.RemoveAt(0);
        }
        yield return SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync("Level8", LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync("Level9", LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync("Level16", LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync("Level17", LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync("Level24", LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync("Level25", LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync("Level32", LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync("Externo", LoadSceneMode.Additive);
        if (index == 5 || index == 6) yield return SceneManager.LoadSceneAsync("Creditos", LoadSceneMode.Additive);
        player.Instance.gameObject.transform.position = new Vector3(-10, 1.64f, 0);
        SetupLoading(false);
        if (index != 6) LevelLoader.Instance.Cutscene(index);
        else
        {
            HubEvents.Instance.FadeOut();
            HubEvents.Instance.Creditos();
        }
    }
    private void SetupLoading(bool value)
    {
        player.Instance.CutsceneMode = value;
        loading.transform.GetChild(1).gameObject.SetActive(value);
    }
}
