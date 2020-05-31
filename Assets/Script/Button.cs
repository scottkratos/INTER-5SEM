using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Linq;
public class Button : MonoBehaviour
{
    public int Level;
    [HideInInspector]
    public Animator anim;
    public Transform[] vase;
    public GameObject[] gramofone;
    public GameObject[] vasoFixo;
    public GameObject[] GridEvent;
    public GameObject[] espinhos;
    public GameObject[] canhao;
    [HideInInspector]
    public bool operDoorEvent, GridOrdem;
    public bool Restard, OperDoor, Grid, rotaoHorario, rotaoAntehoraria, DestinoInicial, DestinoFinal, espinho, otherOrdeGrid;
    public AudioSource ButtonSong, finalPuzzle;
    public GameObject checkAmbient;
    public LayerMask vasolayer, PlayerLayer;
    public AudioSource reset;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // tipos de verificacao com vaso 
        if (noButton())
        {


            // tipos de verificacao dos vaso cheios
            switch (Level)
            {

                case 0:
                    if (vase.Any(vas => vas.GetComponent<Vaso>().AmoutWaterVase == true))
                    {
                        if (OperDoor == true)
                        {
                            openDoor();
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                        }
                        if (Grid == true)
                        {
                            if (otherOrdeGrid == false)
                            {
                                GetComponent<Animator>().SetBool("ButtonBool", true);
                                GridOrdem = true;

                            }
                            if (otherOrdeGrid == true)
                            {
                                GetComponent<Animator>().SetBool("ButtonBool", true);
                                GridOrdem = false;

                            }
                        }
                        if (Restard == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                            restard();
                        }
                        if (espinho == true)
                        {
                            foreach (var item in espinhos)
                            {
                                item.GetComponent<Espinho>().ButtonAct = true;

                            }
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                        }
                    }
                    break;
                case 4:
                    if (vase.Any(vas => vas.GetComponent<Vaso>().AmoutWaterVase == true))
                    {
                        if (OperDoor == true)
                        {
                            openDoor();
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                        }
                        if (Grid == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                            GridOrdem = true;
                        }
                        if (Restard == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", true);

                        }
                    }
                    break;
                case 5:
                    if (vase[0].GetComponent<Vaso>().AmoutWaterVase == true)
                    {
                        if (OperDoor == true)
                        {
                            openDoor();
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                        }
                        if (Grid == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                            GridOrdem = true;
                        }
                        if (Restard == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", true);

                        }
                    }
                    if (vase[1].GetComponent<Vaso>().AmoutWaterVase == true)
                    {
                        if (OperDoor == true)
                        {
                            openDoor();
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                        }
                        if (Grid == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                            GridOrdem = true;
                        }
                        if (Restard == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", true);

                        }
                    }
                    if (vase[2].GetComponent<Vaso>().AmoutWaterVase == true)
                    {
                        if (OperDoor == true)
                        {
                            openDoor();
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                        }
                        if (Grid == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", true);
                            GridOrdem = true;
                        }
                        if (Restard == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", true);

                        }
                    }
                    break;
            }

            // tipos de verificacao dos vaso vazios
            switch (Level)
            {

                case 0:
                    if (vase.Any(vas => vas.GetComponent<Vaso>().AmoutWaterVase == false))
                    {
                        if (OperDoor == true)
                        {

                            GetComponent<Animator>().SetBool("ButtonBool", false);
                            ClosedDoor();
                        }
                        if (Grid == true)
                        {
                            if (otherOrdeGrid == false)
                            {
                                GetComponent<Animator>().SetBool("ButtonBool", false);
                                ClosedDoor();
                                GridOrdem = false;
                            }
                            if (otherOrdeGrid == true)
                            {
                                GetComponent<Animator>().SetBool("ButtonBool", false);
                                ClosedDoor();
                                GridOrdem = true;
                            }



                        }
                        if (Restard == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", false);

                        }
                        if (espinho == true)
                        {
                            foreach (var item in espinhos)
                            {
                                item.GetComponent<Espinho>().ButtonAct = false;

                            }
                            GetComponent<Animator>().SetBool("ButtonBool", false);
                        }
                    }
                    break;
                case 4:
                    if (vase[0].GetComponent<Vaso>().AmoutWaterVase == false)
                    {
                        if (OperDoor == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", false);
                            ClosedDoor();

                        }
                        if (Grid == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", false);
                            ClosedDoor();
                            GridOrdem = false;
                        }
                    }
                    break;
                case 5:
                    if (vase[0].GetComponent<Vaso>().AmoutWaterVase == false)
                    {
                        if (OperDoor == true)
                        {
                            openDoor();
                            GetComponent<Animator>().SetBool("ButtonBool", false);
                        }
                        if (Grid == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", false);
                            GridOrdem = true;
                        }
                        if (Restard == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", false);

                        }
                    }
                    if (vase[1].GetComponent<Vaso>().AmoutWaterVase == false)
                    {
                        if (OperDoor == true)
                        {
                            openDoor();
                            GetComponent<Animator>().SetBool("ButtonBool", false);
                        }
                        if (Grid == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", false);
                            GridOrdem = true;
                        }
                        if (Restard == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", false);

                        }
                    }
                    if (vase[2].GetComponent<Vaso>().AmoutWaterVase == false)
                    {
                        if (OperDoor == true)
                        {
                            openDoor();
                            GetComponent<Animator>().SetBool("ButtonBool", false);
                        }
                        if (Grid == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", false);
                            GridOrdem = true;
                        }
                        if (Restard == true)
                        {
                            GetComponent<Animator>().SetBool("ButtonBool", false);

                        }
                    }
                    break;
            }

        }
        // tipos de verificacao sem vaso 
        if (noButton() == false)
        {

            if (OperDoor == true)
            {
                GetComponent<Animator>().SetBool("ButtonBool", false);
                ClosedDoor();
            }
            if (Grid == true)
            {
                if (otherOrdeGrid == false)
                {
                    GetComponent<Animator>().SetBool("ButtonBool", false);
                    ClosedDoor();
                    GridOrdem = false;

                }
                if (otherOrdeGrid == true)
                {
                    GetComponent<Animator>().SetBool("ButtonBool", false);
                    ClosedDoor();
                    GridOrdem = true;

                }
            }
            if (Restard == true)
            {
                GetComponent<Animator>().SetBool("ButtonBool", false);
            }
            if (rotaoHorario == true)
            {
                foreach (var item in canhao)
                {
                    item.GetComponent<Canhao>().rotation = false;

                }

                GetComponent<Animator>().SetBool("ButtonBool", false);
            }
            if (rotaoAntehoraria == true)
            {
                foreach (var item in canhao)
                {
                    item.GetComponent<Canhao>().rotationR = false;

                }

                GetComponent<Animator>().SetBool("ButtonBool", false);
            }
            if (DestinoInicial == true)
            {
                foreach (var item in canhao)
                {
                    item.GetComponent<Canhao>().DestinoInicial = false;

                }

                GetComponent<Animator>().SetBool("ButtonBool", false);
            }
            if (DestinoFinal == true)
            {
                foreach (var item in canhao)
                {
                    item.GetComponent<Canhao>().DestinoFinal = false;

                }

                GetComponent<Animator>().SetBool("ButtonBool", false);
            }
            if (espinho == true)
            {
                foreach (var item in espinhos)
                {
                    item.GetComponent<Espinho>().ButtonAct = false;

                }
                GetComponent<Animator>().SetBool("ButtonBool", false);
            }
        }
        //contado do jogador
        if (PlayerDown())
        {
            GetComponent<Animator>().SetBool("ButtonBool", true);
            if (Restard == true)
                restard();
            if (OperDoor == true)
                openDoor();
            if (Grid == true)
            {
                if (otherOrdeGrid == false)
                {
                    GridOrdem = true;

                }
                if (otherOrdeGrid == true)
                {
                    GridOrdem = true;

                }
            }
            if (DestinoInicial == true)
                foreach (var item in canhao)
                {
                    item.GetComponent<Canhao>().DestinoInicial = true;

                }
            if (DestinoFinal == true)
                foreach (var item in canhao)
                {
                    item.GetComponent<Canhao>().DestinoFinal = true;

                }
            if (rotaoHorario == true)
                foreach (var item in canhao)
                {
                    item.GetComponent<Canhao>().rotation = true;
                }
            if (rotaoAntehoraria == true)
                foreach (var item in canhao)
                {
                    item.GetComponent<Canhao>().rotationR = true;
                }
            if (espinho == true)
            {
                foreach (var item in espinhos)
                {
                    item.GetComponent<Espinho>().ButtonAct = true;

                }
            }







        }
    }
    void openDoor()
    {
        operDoorEvent = true;

    }
    void ClosedDoor()
    {
        operDoorEvent = false;
    }
    void restard()
    {

        GetComponent<Animator>().SetBool("ButtonBool", true);

        foreach (var item in vase)
        {
            item.GetComponent<Animator>().SetBool("WaterBool", item.GetComponent<Vaso>().defaultWater);
        }
        foreach (var item in gramofone)
        {
            item.GetComponent<Animator>().SetBool("WaterBool", item.GetComponent<Gramofone>().defaultWater);
        }
        foreach (var item in vasoFixo)
        {
            item.GetComponent<Animator>().SetBool("Water", !item.GetComponent<VasoFixo>().defaultWater);
        }


    }
    public void PlayerSound()
    {
        ButtonSong.Play();
        reset.Play();
    }
    public bool noButton()
    {

        return Physics.CheckSphere(checkAmbient.transform.position, .8f, vasolayer);

    }
    public bool PlayerDown()
    {

        return Physics.CheckSphere(checkAmbient.transform.position, .8f, PlayerLayer);

    }



}



















