using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public AudioClip[] Musics;
    public AudioSource[] Sources;
    public static MusicControl Instance;
    private Coroutine Introducao;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ChangeMusic(0);
    }

    public void ChangeMusic(int value)
    {
        switch (value)
        {
            case 0:
                Introducao = StartCoroutine(Intro());
                break;
            case 1:
                Sources[1].clip = Musics[2];
                Sources[1].Play();
                break;
            default:
                StopCoroutine(Introducao);
                for (int i = 0; i < Sources.Length; i++)
                {
                    Sources[i].Stop();
                }
                break;
        }
    }
    private IEnumerator Intro()
    {
        Sources[0].clip = Musics[0];
        Sources[1].clip = Musics[1];
        Sources[0].Play();
        while (Sources[0].isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        Sources[1].Play();
    }
}
