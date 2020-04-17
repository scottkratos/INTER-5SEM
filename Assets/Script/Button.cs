using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Linq;
public class Button : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    public Transform[] vase;
    public GameObject[] gramofone;
    public GameObject[] GridEvent;
    [HideInInspector]
    public bool AmoutWaterVase, operDoorEvent, GridOrdem;
    public bool Restard, OperDoor, Grid;
    public AudioSource ButtonSong, finalPuzzle;
    bool open, closed;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (open == true)
        {
            openDoor();

        }
        if (closed == true)
        {
            ClosedDoor();

        }

    }



    void openDoor()
    {

        foreach (var item in vase)
        {
            if (AmoutWaterVase == true)
            {


                operDoorEvent = true;

            }

        }


    }
    void ClosedDoor()
    {

        foreach (var item in vase)
        {
            if (AmoutWaterVase == true)
            {

                operDoorEvent = false;

            }

        }


    }
    void restard()
    {
        if (Restard == true)
        {
            GetComponent<Animator>().SetBool("ButtonBool", true);
            if (ButtonSong.isPlaying == false)
                ButtonSong.Play();
            foreach (var item in vase)
            {
                item.GetComponent<Animator>().SetBool("WaterBool", true);
            }
            foreach (var item in gramofone)
            {
                item.GetComponent<Animator>().SetBool("WaterBool", false);
            }

        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vaso")
        {
            if (OperDoor == true)
            {
                open = true;
                closed = false;
                GetComponent<Animator>().SetBool("ButtonBool", true);
                if (ButtonSong.isPlaying == false)
                    ButtonSong.Play();


            }
            if (Grid == true)
            {
                GetComponent<Animator>().SetBool("ButtonBool", true);
                if (ButtonSong.isPlaying == false)
                    ButtonSong.Play();


                GridOrdem = !GridOrdem;

            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (Restard == true)
                restard();

        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Vaso")
        {

            if (OperDoor == true)
            {
                GetComponent<Animator>().SetBool("ButtonBool", false);
                open = false;
                closed = true;
                if (ButtonSong.isPlaying == false)
                    ButtonSong.Play();


            }
            if (Grid == true)
            {
                GetComponent<Animator>().SetBool("ButtonBool", false);
                if (ButtonSong.isPlaying == false)
                    ButtonSong.Play();
                GridOrdem = !GridOrdem;

            }

        }
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("ButtonBool", false);
            if (ButtonSong.isPlaying == false)
                ButtonSong.Play();
        }
    }

}








