using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

    public AudioMixer AudioMixer;
    public Slider masteSlider, SfxSlider, MusicSlider, sensitivitySlider;

    // Start is called before the first frame update
    void Start()
    {
        controleAudioMast(masteSlider.value);
        controleAudioMusica(MusicSlider.value);
        controleAudioSFX(SfxSlider.value);
        Sensitivity(sensitivitySlider.value);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void controleAudioMast(float MastVolume)
    {
        AudioMixer.SetFloat("Master", MastVolume);
    }
    public void controleAudioMusica(float musicaVolume)
    {
        AudioMixer.SetFloat("Musica", musicaVolume);
    }
    public void controleAudioSFX(float SfxVolume)
    {
        AudioMixer.SetFloat("SFX", SfxVolume);
    }
    public void sair()
    {
        Application.Quit();


    }
    public void Sensitivity(float sensitivity)
    {
        FindObjectOfType<player>().Sensitivity = sensitivity;

    }
    
}
