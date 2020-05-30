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
                for (int i = 0; i < Sources.Length; i++)
                {
                    Sources[i].Stop();
                }
                Sources[1].clip = Musics[2];
                Sources[1].Play();
                break;
            case 2:
                for (int i = 0; i < Sources.Length; i++)
                {
                    Sources[i].Stop();
                }
                Sources[1].clip = Musics[3];
                Sources[1].Play();
                break;
            case 8:
                for (int i = 0; i < Sources.Length; i++)
                {
                    Sources[i].Stop();
                }
                StartCoroutine(ForcePlay(8));
                break;
            case 9:
                StartCoroutine(ForcePlay(9));
                break;
            case -1:
                StopCoroutine(Introducao);
                for (int i = 0; i < Sources.Length; i++)
                {
                    Sources[i].Stop();
                }
                break;
            default:
                StartCoroutine(Cutscene(value));
                break;
        }
    }
    private IEnumerator ForcePlay(int index)
    {
        while (!Sources[1].isPlaying)
        {
            Sources[1].clip = Musics[index];
            Sources[1].Play();
            yield return null;
        }
    }
    private IEnumerator Intro()
    {
        Sources[0].clip = Musics[0];
        Sources[1].clip = Musics[1];
        Sources[0].Play();
        while (Sources[0].isPlaying)
        {
            yield return null;
        }
        Sources[1].Play();
    }
    private IEnumerator Cutscene(int value)
    {
        Sources[1].clip = Musics[value];
        Sources[1].Play();
        while (Sources[1].isPlaying)
        {
            yield return null;
        }
        Sources[1].clip = Musics[2];
        Sources[1].Play();
    }
}
