using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WaterMoviment : MonoBehaviour
{


    public GameObject[] evetObject;
    public Animator animator;
    public bool Door, Grid, Button, FullWater;
    [HideInInspector]
    public bool DoorEvent, GridOrdem;
    public int Level;
    public AudioSource finalPuzzle;
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

    // roda sempre com a animca de "agua cheia"
    void EventGameplaye()
    {

        if (Door == true)
        {

            foreach (var item in evetObject)
            {

                DoorEvent = true;
            }

        }


        if (Button == true)
        {
            foreach (var item in evetObject)
            {
                item.GetComponent<Button>().AmoutWaterVase = true;

            }
        }

        // tipos de movimento de grinde 0 para default
        if (Grid == true)
        {


            switch (Level)
            {
                case 0:
                    foreach (var item in evetObject)
                    {
                        GridOrdem = !GridOrdem;

                    }
                    break;
                case 4:
                    foreach (var item in evetObject)
                    {
                        GridOrdem = true;

                    }
                    break;
                case 8:
                    foreach (var item in evetObject)
                    {
                        evetObject[0].GetComponent<Grid>().GridOrdem = true;
                        if (evetObject[1].GetComponent<Grid>().GridOrdem == true)
                        {
                            evetObject[1].GetComponent<Grid>().GridOrdem = false;
                        }
                    }
                    break;
            }



        }
    }








    // animacao do modo "sem agua" ativado, avisa que nao tem agua para o botao
    void takeWater()
    {
        foreach (var item in evetObject)
        {
            item.GetComponent<Button>().AmoutWaterVase = false;

        }


    }
    void Restart()
    {

        DoorEvent = false;
        GridOrdem = false;
        if (Grid == true)
        {
            foreach (var item in evetObject)
            {
                item.GetComponent<Grid>().GridOrdem = item.GetComponent<Grid>().SaveOrdem;

            }

        }


    }






























}
