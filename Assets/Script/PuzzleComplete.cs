using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComplete : MonoBehaviour
{
    private bool Cutscene;
    private bool Ready;
    private bool Lock;
    private AudioSource audioRef;
    private Coroutine PlayerCheck;

    private void Start()
    {
        Cutscene = GetComponentInParent<LevelController>().CutsceneDoor;
        audioRef = GetComponentInParent<AudioSource>();
    }

    public void IsDoorOpen(bool value)
    {
        Ready = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Cutscene) return;
        PlayerCheck = StartCoroutine(CheckPlayer(other));
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player" && PlayerCheck != null)
        {
            StopCoroutine(PlayerCheck);
        }
    }
    private IEnumerator CheckPlayer(Collider other)
    {
        while (true)
        {
            if (!Ready)
            {
                yield return new WaitForSeconds(0.5f);
                continue;
            }
            if (other.tag == "Player" && !Lock)
            {
                audioRef.Play();
                Lock = true;
                break;
            }
            yield return null;
        }
    }
}
