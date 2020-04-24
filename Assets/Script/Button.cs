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
    public GameObject[] GridEvent;
    [HideInInspector]
    public bool operDoorEvent, GridOrdem;
    public bool Restard, OperDoor, Grid;
    public AudioSource ButtonSong, finalPuzzle;
    bool open, closed;
    public GameObject checkAmbient;
    public LayerMask vasolayer;
    public AudioSource reset;
    public Material RefMaterial;
    private Material NormalMaterial;

    private void Start()
    {
        anim = GetComponent<Animator>();
        NormalMaterial = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        switch (Level)
        {

            case 0:
                if (noButton() == true && vase.Any(vas => vas.GetComponent<Vaso>().AmoutWaterVase == true))
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
            case 4:
                if (noButton() == true && vase.Any(vas => vas.GetComponent<Vaso>().AmoutWaterVase == true))
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
                if (noButton() == true && vase[0].GetComponent<Vaso>().AmoutWaterVase == true)
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
                if (noButton() == true && vase[1].GetComponent<Vaso>().AmoutWaterVase == true)
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
                if (noButton() == true && vase[2].GetComponent<Vaso>().AmoutWaterVase == true)
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















        if (noButton() == false)
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
            if (Restard == true)
            {
                GetComponent<Animator>().SetBool("ButtonBool", false);

            }

        }
        // tipos de verificacao dos vaso vazios
        switch (Level)
        {

            case 0:
                if (noButton() == true && vase.Any(vas => vas.GetComponent<Vaso>().AmoutWaterVase == false))
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
                    if (Restard == true)
                    {
                        GetComponent<Animator>().SetBool("ButtonBool", false);

                    }
                }
                break;
            case 4:
                if (noButton() == true && vase[0].GetComponent<Vaso>().AmoutWaterVase == false)
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
        if (Restard == true)
        {
            GetComponent<Animator>().SetBool("ButtonBool", true);

            foreach (var item in vase)
            {
                item.GetComponent<Animator>().SetBool("WaterBool", true);
            }
            foreach (var item in gramofone)
            {
                item.GetComponent<Animator>().SetBool("WaterBool", false);
            }

        }
        //if (RefMaterial != NormalMaterial) reset.Play();
    }
    public void PlayerSound()
    {

        GetComponent<AudioSource>().Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vaso")
        {

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



        }
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("ButtonBool", false);

        }
    }
    public bool noButton()
    {

        return Physics.CheckSphere(checkAmbient.transform.position, .8f, vasolayer);

    }


}








