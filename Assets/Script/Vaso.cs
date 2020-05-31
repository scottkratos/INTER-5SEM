using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaso : MonoBehaviour
{
    public GameObject[] evetObject;
    public Animator animator;
    public GameObject checkAmbient;
    public bool Door, Grid, Button, FullWater;
    [HideInInspector]
    public bool DoorEvent, GridOrdem, AmoutWaterVase, congelado;
    public int Level;
    public AudioSource finalPuzzle;
    public LayerMask Ambientelayer;
    public AudioSource place, remove;
    public bool defaultWater;
    private void Awake()
    {

    }
    private void Start()
    {
        if (FullWater == true)
        {
            animator.SetBool("WaterBool", true);
            EventGameplaye();
        }
        else
        {
            animator.SetBool("WaterBool", false);
        }
        defaultWater = FullWater;
    }
    private void Update()
    {
        if (congelado == true)
        {
            AmoutWaterVase = true;
        }

    }
    // roda sempre com a animacao de "agua cheia"
    void EventGameplaye()
    {
        if (Door == true)
        {
            DoorEvent = true;
        }


        if (Button == true)
        {
            AmoutWaterVase = true;
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
    //Sons do vaso
    public void PlayerSound()
    {
        place.Play();
    }
    // animacao do modo "sem agua" ativado, avisa que nao tem agua para o botao
    void takeWater()
    {
        AmoutWaterVase = false;
        remove.Play();
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
    public bool novaso()
    {
        return Physics.CheckSphere(checkAmbient.transform.position, .2f, Ambientelayer);
    }






}
