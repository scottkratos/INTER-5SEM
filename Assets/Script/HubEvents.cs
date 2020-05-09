using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubEvents : MonoBehaviour
{
    public static HubEvents Instance;
    public int ObjectiveIndex = -1;
    public GameObject[] LamparinasObjective;
    public GameObject[] Estatuas;
    public LevelController[] Portas;
    public LevelController PortaPrincipal;
    public GameObject Barreira;
    private AudioSource audioSource;
    private List<GameObject> Lamparinas = new List<GameObject>();
    private bool LockUpdate = false;
    private bool IsCutscene = false;
    private const float MaxShader = -5;
    private float ShaderValue;


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
            ShaderValue -= rate;
            yield return null;
        }
    }
    private IEnumerator EnfraquecerBarreira(int index)
    {
        Material barreiraMat = Barreira.GetComponent<Material>();
        float timer = 0;
        switch (index)
        {
            case 0:
                ShaderValue = 0;
                while (timer < 2)
                {
                    timer += Time.deltaTime;
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue = (timer / 200);
                    yield return null;
                }
                break;
            case 1:
                ShaderValue = 0.25f;
                while (timer < 2)
                {
                    timer += Time.deltaTime;
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue = (timer / 200) + 0.25f;
                    yield return null;
                }
                break;
            case 2:
                ShaderValue = 0.5f;
                while (timer < 2)
                {
                    timer += Time.deltaTime;
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue = (timer / 200) + 0.5f;
                    yield return null;
                }
                break;
            case 3:
                ShaderValue = 0.75f;
                while (timer < 2)
                {
                    timer += Time.deltaTime;
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue = (timer / 200) + 0.75f;
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