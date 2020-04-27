using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        while(ShaderValue > MaxShader)
        {
            for (int i = 0; i < estatua.materials.Length; i++)
            {
                estatua.materials[i].SetFloat("Value", ShaderValue);
            }
            ShaderValue -= 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator EnfraquecerBarreira(int index)
    {
        Material barreiraMat = Barreira.GetComponent<Material>();
        switch (index)
        {
            case 0:
                ShaderValue = 0;
                while (ShaderValue <= 0.25f)
                {
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue += 0.05f;
                    yield return new WaitForSeconds(0.1f);
                }
                break;
            case 1:
                ShaderValue = 0.25f;
                while (ShaderValue <= 0.5f)
                {
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue += 0.05f;
                    yield return new WaitForSeconds(0.2f);
                }
                break;
            case 2:
                ShaderValue = 0.5f;
                while (ShaderValue <= 0.75f)
                {
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue += 0.05f;
                    yield return new WaitForSeconds(0.2f);
                }
                break;
            case 3:
                ShaderValue = 0.75f;
                while (ShaderValue <= 1)
                {
                    barreiraMat.SetFloat("Barrier", ShaderValue);
                    ShaderValue += 0.05f;
                    yield return new WaitForSeconds(0.2f);
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