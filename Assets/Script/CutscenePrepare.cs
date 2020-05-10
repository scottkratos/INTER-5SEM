using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePrepare : MonoBehaviour
{
    public int index;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HubEvents.CutsceneIndex = index;
        }
    }
}
