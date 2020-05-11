using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneControl : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (HubEvents.CutsceneIndex == index)
            {
                LevelLoader.Instance.Cutscene(index);
                if (index == 4) HubEvents.CutsceneIndex = 5;
                else HubEvents.CutsceneIndex = -1;
                MusicControl.Instance.ChangeMusic(index);
            }
        }
    }
}
