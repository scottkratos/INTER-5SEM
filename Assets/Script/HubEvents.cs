using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubEvents : MonoBehaviour
{
    public HubEvents Instance;
    public int ObjectiveIndex = 0;
    public GameObject[] LamparinasObjective;
    private List<GameObject> Lamparinas = new List<GameObject>();
    private bool LockUpdate = false;
    private bool IsCutscene = false;

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
                    go.GetComponent<Rigidbody>().isKinematic = false;
                    go.transform.GetChild(2).gameObject.SetActive(false);
                }
                LockUpdate = true;
                break;
        }
    }
}