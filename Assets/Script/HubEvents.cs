using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HubEvents : MonoBehaviour
{
    public static HubEvents Instance;
    public int ObjectiveIndex = -1;
    public GameObject[] LamparinasObjective;
    public GameObject[] Estatuas;
    public LevelController[] Portas;
    public LevelController PortaPrincipal;
    public GameObject Barreira;
    public GameObject Credits;
    public Sprite RPGLogo;
    private AudioSource audioSource;
    private List<GameObject> Lamparinas = new List<GameObject>();
    private bool LockUpdate = false;
    private bool IsCutscene = false;
    private const float MaxShader = -3;
    private float ShaderValue;
    private bool IsHaunted;
    public LevelLoadManager[] levels;
    public static int CutsceneIndex;
    public static GameObject[] transforms = new GameObject[36];

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
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Lamparina"))
        {
            Lamparinas.Add(go);
        }
        audioSource = GetComponent<AudioSource>();
    }
    public void CreteTransform(Vector3 valvect, Quaternion valquat, int index)
    {
        if (transforms[index] != null) return;
        GameObject go = new GameObject();
        Vector3 pos;
        pos = new Vector3(valvect.x, valvect.y, valvect.z);
        Quaternion rot = new Quaternion(valquat.x, valquat.y, valquat.z, valquat.w);
        go.transform.position = pos;
        go.transform.rotation = rot;
        go.name = "Transform Porta " + index;
        transforms.SetValue(go, index);
    }
    public void ChangePlayerEnableStatus(bool active)
    {
        player.Instance.gameObject.SetActive(active);
    }
    public void ChagePlayerPlayabilityStatus(bool active)
    {
        player.Instance.CutsceneMode = active;
    }
    public void ChangeObjectiveIndex(int value)
    {
        ObjectiveIndex = value;
        if (value != -1 && value != 4)
        {
            Portas[value].Open(true);
            audioSource.Play();
        }
    }
    public void OffLights()
    {
        for (int i = 0; i < LamparinasObjective.Length; i++)
        {
            LamparinasObjective[i].transform.GetChild(0).transform.gameObject.SetActive(false);
        }
    }
    public void FlickLights()
    {
        IsHaunted = !IsHaunted;
        if (IsHaunted == false)
        {
            for (int i = 0; i < LamparinasObjective.Length; i++)
            {
                LamparinasObjective[i].transform.GetChild(0).transform.gameObject.SetActive(true);
            }
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(Flashing());
        }
    }
    public void FadeOut()
    {
        Credits.SetActive(true);
        StartCoroutine(Fade());
    }
    public void Creditos()
    {
        StartCoroutine(StartCredits());
    }
    private IEnumerator Fade()
    {
        float timer = 2;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            Credits.transform.GetChild(0).GetComponent<Image>().color = new Color(Credits.transform.GetChild(0).GetComponent<Image>().color.r, Credits.transform.GetChild(0).GetComponent<Image>().color.g, Credits.transform.GetChild(0).GetComponent<Image>().color.b, OneMinus(timer / 2));
            yield return null;
        }
    }
    private float OneMinus(float value)
    {
        value = (value * -1) + 1;
        return value;
    }
    private IEnumerator Transicao(Image img)
    {
        Coroutine coroutine;
        yield return new WaitForSeconds(20);
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, true));
        yield return coroutine;
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, false));
        yield return new WaitForSeconds(20);
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, true));
        yield return coroutine;
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, false));
        yield return new WaitForSeconds(20);
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, true));
        yield return coroutine;
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, false));
        yield return new WaitForSeconds(20);
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, true));
        yield return coroutine;
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, false));
        yield return new WaitForSeconds(20);
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, true));
        yield return coroutine;
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, false));
        yield return new WaitForSeconds(20);
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, true));
        yield return coroutine;
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, false));
        yield return new WaitForSeconds(20);
        coroutine = StartCoroutine(ChangeAlpha(img.gameObject, true, 1, true));
    }
    private IEnumerator StartCredits()
    {
        MusicControl.Instance.ChangeMusic(9);
        LevelLoader.Instance.Timeline.initialTime = 0;
        LevelLoader.Instance.Timeline.Play(LevelLoader.Instance.Clips[6]);
        Image bg, logo;
        Text title, subtitle, finalText;
        Coroutine coroutine;
        bg = Credits.transform.GetChild(0).GetComponent<Image>();
        logo = Credits.transform.GetChild(1).GetComponent<Image>();
        title = Credits.transform.GetChild(2).GetComponent<Text>();
        subtitle = Credits.transform.GetChild(3).GetComponent<Text>();
        finalText = Credits.transform.GetChild(4).GetComponent<Text>();
        logo.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        StartCoroutine(Transicao(bg));
        StartCoroutine(ChangeAlpha(bg.gameObject, true, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(logo.gameObject, true, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        logo.sprite = RPGLogo;
        coroutine = StartCoroutine(ChangeAlpha(logo.gameObject, true, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        coroutine = StartCoroutine(ChangeAlpha(logo.gameObject, true, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Equipe:";
        subtitle.text = "Álvaro Barros – 21142585 \n Gabriel Rego dos Santos Caldeira – 20840852 \n Giuglia Tubini Ehlke – 21122736 \n Lucas Silva da Cruz – 21146351 \n Marcelo Rangel Figueiredo – 21057406 \n Paula Fernandes Mussi – 21068984 \n Rafael Pedro Cianelli – 21085972";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Produtor:";
        subtitle.text = "Gabriel Rego dos Santos Caldeira";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Diretora de Arte:";
        subtitle.text = "Giuglia Tubini Ehlke";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Equipe de Arte:";
        subtitle.text = "Giuglia Tubini Ehlke \n Paula Fernandes Mussi";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Lead de Programação:";
        subtitle.text = "Lucas Silva da Cruz";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Equipe de Programação:";
        subtitle.text = "Lucas Silva da Cruz \n Gabriel Rego dos Santos Caldeira";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Lead de 3D:";
        subtitle.text = "Rafael Pedro Cianelli";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Equipe de 3D:";
        subtitle.text = "Rafael Pedro Cianelli \n Álvaro Barros \n Paula Fernandes Mussi";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Lead de Rigging:";
        subtitle.text = "Álvaro Barros";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Lead de Sound Design:";
        subtitle.text = "Marcelo Rangel Figueiredo";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Artista VFX:";
        subtitle.text = "Paula Fernandes Mussi";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        title.text = "Playtesters de Desenvolvimento:";
        subtitle.text = "Eliel Calebi \n Henrique Andrade Pancote \n Amanda Fernandes Mussi \n Leonardo Coradi \n Arames Zaccarias \n Gabriel Alves Cianelli";
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, true));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, true));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        StartCoroutine(ChangeAlpha(title.gameObject, false, 2, false));
        coroutine = StartCoroutine(ChangeAlpha(subtitle.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(5);
        coroutine = StartCoroutine(ChangeAlpha(finalText.gameObject, false, 2, true));
        yield return coroutine;
        coroutine = StartCoroutine(ChangeAlpha(bg.gameObject, true, 5, true));
        yield return coroutine;
        coroutine = StartCoroutine(ChangeAlpha(finalText.gameObject, false, 2, false));
        yield return coroutine;
        yield return new WaitForSeconds(1);
        RestartGame();
        //163 secs total
        //22 secs p/ sala
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("HUB", LoadSceneMode.Single);
    }
    private IEnumerator ChangeAlpha(GameObject go, bool IsImage, float timer, bool IsFadingIn)
    {
        float compareTimer = timer;
        Image image = null;
        Text text = null;
        if (IsImage)
        {
            image = go.GetComponent<Image>();
        }
        else
        {
            text = go.GetComponent<Text>();
        }
        while (timer > 0)
        {
            if (IsFadingIn)
            {
                if (IsImage)
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, OneMinus(timer / compareTimer));
                }
                else
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, OneMinus(timer / compareTimer));
                }
            }
            else
            {
                if (IsImage)
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, timer / compareTimer);
                }
                else
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, timer / compareTimer);
                }
            }
            timer -= Time.deltaTime;
            yield return null;
        }
        if (IsFadingIn)
        {
            if (IsImage)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            }
            else
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            }
        }
        else
        {
            if (IsImage)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            }
            else
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            }
        }
    }
    public IEnumerator Flashing()
    {
        while (IsHaunted)
        {
            for (int i = 0; i < LamparinasObjective.Length; i++)
            {
                LamparinasObjective[i].transform.GetChild(0).transform.gameObject.SetActive(!LamparinasObjective[i].transform.GetChild(0).transform.gameObject.activeSelf);
            }
            yield return null;
        }
    }
    public void OpenMainDoor(bool value)
    {
        PortaPrincipal.Open(value);
    }
    public void EnableEstatuas(int index)
    {
        StartCoroutine(SpawnEstatua(Estatuas[index].GetComponent<EstatuasMats>()));
    }
    public void Enfraquecer(int index)
    {
        StartCoroutine(EnfraquecerBarreira(index));
    }
    private IEnumerator SpawnEstatua(EstatuasMats estatua)
    {
        ShaderValue = 0;
        float timer = 0;
        float rate = 1 / MaxShader;
        while(timer < 1)
        {
            timer += Time.deltaTime;
            for (int i = 0; i < estatua.materials.Length; i++)
            {
                estatua.materials[i].SetFloat("Value", ShaderValue);
            }
            ShaderValue += rate;
            yield return null;
        }
    }
    private IEnumerator EnfraquecerBarreira(int index)
    {
        Material barreiraMat = Barreira.GetComponent<MeshRenderer>().material;
        float timer = 0;
        switch (index)
        {
            case 0:
                ShaderValue = 0;
                while (timer < 2)
                {
                    timer += Time.deltaTime;
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue = (timer / 20);
                    yield return null;
                }
                break;
            case 1:
                ShaderValue = 0.25f;
                while (timer < 2)
                {
                    timer += Time.deltaTime;
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue = (timer / 20) + 0.25f;
                    yield return null;
                }
                break;
            case 2:
                ShaderValue = 0.5f;
                while (timer < 2)
                {
                    timer += Time.deltaTime;
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue = (timer / 20) + 0.5f;
                    yield return null;
                }
                break;
            case 3:
                ShaderValue = 0.75f;
                while (timer < 2)
                {
                    timer += Time.deltaTime;
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue = (timer / 20) + 0.75f;
                    yield return null;
                }
                Barreira.SetActive(false);
                break;
        }
    }
    private void Update()
    {
        if (LockUpdate) return;
        switch(ObjectiveIndex)
        {
            case -1:
                for (int i = 0; i < LamparinasObjective.Length; i++)
                {
                    LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                    LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
                }
                break;
            case 0:
                for (int i = 0; i < LamparinasObjective.Length; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
                    }
                    else
                    {
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
                break;
            case 1:
                for (int i = 0; i < LamparinasObjective.Length; i++)
                {
                    if (i == 2 || i == 3)
                    {
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
                    }
                    else
                    {
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < LamparinasObjective.Length; i++)
                {
                    if (i == 4 || i == 5)
                    {
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
                    }
                    else
                    {
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < LamparinasObjective.Length; i++)
                {
                    if (i == 6 || i == 7)
                    {
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
                    }
                    else
                    {
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                        LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
                break;
            default:
                for (int i = 0; i < LamparinasObjective.Length; i++)
                {
                    LamparinasObjective[i].transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
                    LamparinasObjective[i].transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
                }
                foreach (GameObject go in Lamparinas)
                {
                    go.GetComponent<CapsuleCollider>().enabled = true;
                    go.GetComponent<Rigidbody>().isKinematic = false;
                    go.transform.GetChild(2).gameObject.SetActive(false);
                }
                LockUpdate = true;
                break;
        }
    }
}
[System.Serializable]
public class LevelLoadManager
{
    public string[] LevelLoad, LevelUnload;
}