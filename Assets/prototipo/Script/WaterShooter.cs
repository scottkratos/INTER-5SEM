using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShooter : MonoBehaviour
{

    [HideInInspector]
    public RaycastHit hit;
    public GameObject[] ShotWater;
    public Camera fpsCam;




    void Update()
    {

        foreach (GameObject shot in ShotWater)
        {

            shot.transform.position += Camera.main.transform.forward;
        }


        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Vaso" && FindObjectOfType<Orbit>().InHand == true)
            {
               // FindObjectOfType<player>().index--;
               // FindObjectOfType<player>().ShotIndex++;
                FindObjectOfType<player>().animationIndex++;





                switch (FindObjectOfType<player>().animationIndex)
                {
                    case 0:
                        hit.transform.gameObject.GetComponent<WaterMoviment>().anim.SetBool("WaterBool", true);

                        break;
                    case 1:
                        hit.transform.gameObject.GetComponent<WaterMoviment>().anim.speed = 1;

                        break;

                    case 2:
                        hit.transform.gameObject.GetComponent<WaterMoviment>().anim.speed = 1;

                        break;

                    case 3:
                        hit.transform.gameObject.GetComponent<WaterMoviment>().anim.speed = 1;

                        break;

                    case 4:
                        hit.transform.gameObject.GetComponent<WaterMoviment>().anim.speed = 1;

                        break;




                }







            }

        }
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Gramofone" && FindObjectOfType<Orbit>().InHand == true)
            {
                // FindObjectOfType<player>().index--;
                // FindObjectOfType<player>().ShotIndex++;
                FindObjectOfType<player>().animationIndex++;





                switch (FindObjectOfType<player>().animationIndex)
                {
                    case 0:
                        hit.transform.gameObject.GetComponent<Gramofone>().anim.SetBool("GramofoneBool", true);

                        break;
                    case 1:
                        hit.transform.gameObject.GetComponent<Gramofone>().anim.speed = 1;

                        break;

                    case 2:
                        hit.transform.gameObject.GetComponent<Gramofone>().anim.speed = 1;

                        break;

                    case 3:
                        hit.transform.gameObject.GetComponent<Gramofone>().anim.speed = 1;

                        break;

                    case 4:
                        hit.transform.gameObject.GetComponent<Gramofone>().anim.speed = 1;

                        break;




                }







            }

        }
    }


















}
