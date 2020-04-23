﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gramofone : MonoBehaviour
{
    public GameObject[] evetObject;
    public Animator animator;
    public bool Door, Grid, Button, FullWater;
    [HideInInspector]
    public bool DoorEvent, GridOrdem;
    public int Level;
    public AudioSource finalPuzzle;
    public GameObject Particula;
    private void Awake()
    {

    }
    private void Start()
    {
        if (FullWater == true)
        {
            animator.SetBool("WaterBool", true);
        }
        else
        {
            animator.SetBool("WaterBool", false);

        }
    }
    private void Update()
    {

    }

    // roda sempre com a animacao de "agua cheia"
    void EventGameplaye()
    {

        if (Door == true)
        {

            foreach (var item in evetObject)
            {

                DoorEvent = true;
            }

        }




        // tipos de movimento de grinde 0 para default
        if (Grid == true)
        {
            GridOrdem = true;
        }
    }



    public void PlayerSound()
    {

        GetComponent<AudioSource>().Play();
        Particula.SetActive(true);
    }
    // animacao do modo "sem agua" ativado, avisa que nao tem agua para o botao
    void takeWater()
    {
        foreach (var item in evetObject)
        {
            // item.GetComponent<Button>().AmoutWaterVase = false;

        }


    }
    void Restart()
    {

        DoorEvent = false;
        GridOrdem = false;

    }

}






