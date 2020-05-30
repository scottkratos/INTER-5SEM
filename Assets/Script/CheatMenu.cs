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
        StartCoroutine(Reload(level, false));
    }
    public void ChangeInRuntime(string level)
    {
        player.Instance.CheatMenu.SetActive(false);
        StartCoroutine(Reload(level, true));
    }
    private IEnumerator Reload(string level, bool makeConversion)
    {
        player.Instance.CutsceneMode = true;
        MusicControl.Instance.ChangeMusic(1);
        if (makeConversion)
        {
            int transformIndex;
            if (level.Length == 7)
            {
                transformIndex = int.Parse(level[5].ToString() + level[6].ToString());
            }
            else
            {
                transformIndex = int.Parse(level[5].ToString());
            }
            if (transformIndex >= 0 && transformIndex <= 7)
            {
                transformIndex += 1;
            }
            else if (transformIndex >= 8 && transformIndex <= 15)
            {
                //transformIndex += 2;
            }
            else if (transformIndex >= 16 && transformIndex <= 23)
            {
                transformIndex -= 1;
            }
            else if (transformIndex >= 24 && transformIndex <= 31)
            {
                transformIndex -= 2;
            }
            level = "Level" + transformIndex.ToString();
        }
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
        for (int i = 0;  i < LevelLoader.Instance.Levels.Length; i++)
        {
            yield return SceneManager.LoadSceneAsync(LevelLoader.Instance.Levels[i], LoadSceneMode.Additive);
        }
        int indexToStop = System.Array.IndexOf(Levels, level);
        int startPoint = 0;
        if (indexToStop >= 0 && indexToStop <= 7)
        {
            indexToStop += 0;
            startPoint = 0;
        }
        else if (indexToStop >= 8 && indexToStop <= 15)
        {
            indexToStop+= 1;
            startPoint = 7;
            yield return SceneManager.UnloadSceneAsync("Level2");
            yield return SceneManager.UnloadSceneAsync("Level3");
            yield return SceneManager.UnloadSceneAsync("Level4");
            yield return SceneManager.UnloadSceneAsync("Level8");
            yield return SceneManager.UnloadSceneAsync("Level9");
            yield return SceneManager.UnloadSceneAsync("Level17");
            yield return SceneManager.UnloadSceneAsync("Level23");
            yield return SceneManager.UnloadSceneAsync("Level24");
            yield return SceneManager.UnloadSceneAsync("Level26");
            yield return SceneManager.UnloadSceneAsync("Level27");
            yield return SceneManager.UnloadSceneAsync("Level28");
            yield return SceneManager.UnloadSceneAsync("Level29");
            yield return SceneManager.UnloadSceneAsync("Level30");
            yield return SceneManager.UnloadSceneAsync("Level31");
            yield return SceneManager.UnloadSceneAsync("Level32");
        }
        else if (indexToStop >= 16 && indexToStop <= 23)
        {
            indexToStop += 2;
            startPoint = 15;
            yield return SceneManager.UnloadSceneAsync("Level2");
            yield return SceneManager.UnloadSceneAsync("Level3");
            yield return SceneManager.UnloadSceneAsync("Level4");
            yield return SceneManager.UnloadSceneAsync("Level8");
            yield return SceneManager.UnloadSceneAsync("Level9");
            yield return SceneManager.UnloadSceneAsync("Level17");
            yield return SceneManager.UnloadSceneAsync("Level23");
            yield return SceneManager.UnloadSceneAsync("Level24");
            yield return SceneManager.UnloadSceneAsync("Level26");
            yield return SceneManager.UnloadSceneAsync("Level27");
            yield return SceneManager.UnloadSceneAsync("Level28");
            yield return SceneManager.UnloadSceneAsync("Level29");
            yield return SceneManager.UnloadSceneAsync("Level30");
            yield return SceneManager.UnloadSceneAsync("Level31");
            yield return SceneManager.UnloadSceneAsync("Level32");
        }
        else if (indexToStop >= 24 && indexToStop <= 31)
        {
            indexToStop += 3;
            startPoint = 23;
            yield return SceneManager.UnloadSceneAsync("Level2");
            yield return SceneManager.UnloadSceneAsync("Level3");
            yield return SceneManager.UnloadSceneAsync("Level4");
            yield return SceneManager.UnloadSceneAsync("Level8");
            yield return SceneManager.UnloadSceneAsync("Level9");
            yield return SceneManager.UnloadSceneAsync("Level17");
            yield return SceneManager.UnloadSceneAsync("Level23");
            yield return SceneManager.UnloadSceneAsync("Level24");
            yield return SceneManager.UnloadSceneAsync("Level26");
            yield return SceneManager.UnloadSceneAsync("Level27");
            yield return SceneManager.UnloadSceneAsync("Level28");
            yield return SceneManager.UnloadSceneAsync("Level29");
            yield return SceneManager.UnloadSceneAsync("Level30");
            yield return SceneManager.UnloadSceneAsync("Level31");
            yield return SceneManager.UnloadSceneAsync("Level32");
        }
        for (int r = startPoint; r < indexToStop; r++)
        {
            for (int i = 0; i < HubEvents.Instance.levels[r].LevelLoad.Length; i++)
            {
                yield return SceneManager.LoadSceneAsync(HubEvents.Instance.levels[r].LevelLoad[i], LoadSceneMode.Additive);
            }
            for (int i = 0; i < HubEvents.Instance.levels[r].LevelUnload.Length; i++)
            {
                for (int p = 0; p < SceneManager.sceneCount; p++)
                {
                    if (SceneManager.GetSceneAt(p).name == HubEvents.Instance.levels[r].LevelUnload[i])
                    {
                        SceneManager.UnloadSceneAsync(HubEvents.Instance.levels[r].LevelUnload[i]);
                    }
                }
            }
        }
        yield return new WaitForEndOfFrame();
        player.Instance.transform.position = HubEvents.transforms[indexToStop].transform.forward.normalized * -0.5f + new Vector3(HubEvents.transforms[indexToStop].transform.position.x, HubEvents.transforms[indexToStop].transform.position.y + 2, HubEvents.transforms[indexToStop].transform.position.z);
        SetupLoading(false);
        player.Instance.CutsceneMode = false;
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
