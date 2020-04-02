using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WaterMoviment : MonoBehaviour
{


    public GameObject[] evetObject;
    public Animator anim;
    public bool Door, Grid, Button, FullWater;
    public int I;
    public AudioSource finalPuzzle;
    private void Awake()
    {

    }
    private void Start()
    {
        if (FullWater == true)
        {
            anim.SetBool("WaterBool", true);
        }
        else
        {
            anim.SetBool("WaterBool", false);

        }
    }
    private void Update()
    {

    }
    void EventGameplaye()
    {

        if (Door == true)
        {
            foreach (var item in evetObject)
            {
                item.GetComponent<Animator>().SetBool("DoorBool", true);
                item.GetComponent<AudioSource>().Play();
                finalPuzzle.Play();
            }
        }
        if (Button == true)
        {
            foreach (var item in evetObject)
            {
                item.GetComponent<Button>().AmoutWaterVase = true;

            }
        }
        if (Grid == true)
        {
            foreach (var item in evetObject)
            {
                item.GetComponent<Grid>().GridOrdem = !item.GetComponent<Grid>().GridOrdem;

            }
            if (I == 2)
            {
                evetObject[0].GetComponent<Grid>().GridOrdem = true;
                if (evetObject[1].GetComponent<Grid>().GridOrdem == true)
                {
                    evetObject[1].GetComponent<Grid>().GridOrdem = false;


                }

            }
        }
    }
    void takeWater()
    {
        foreach (var item in evetObject)
        {
            item.GetComponent<Button>().AmoutWaterVase = false;

        }


    }
    void Restart()
    {
        if (Grid == true)
        {
            foreach (var item in evetObject)
            {
                item.GetComponent<Grid>().GridOrdem = item.GetComponent<Grid>().SaveOrdem;

            }

        }


    }






























}
