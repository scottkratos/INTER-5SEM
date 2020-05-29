﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class WaterShooter : MonoBehaviour
{

    [HideInInspector]
    public RaycastHit hit, hitGrade;
    public GameObject[] ShotWater;
    public Camera fpsCam;
    Ray oring;
    public LayerMask Grade;
    float distance;
    Transform Player;


    private void Awake()
    {
        Player = FindObjectOfType<player>().transform;

    }

    void Update()
    {
        RayGrid();
        eventos();
        oring = Camera.main.ScreenPointToRay(Input.mousePosition);
        //direcao do disparo 
        foreach (GameObject shot in ShotWater)
        {
            shot.transform.position += Player.GetComponent<player>().eyes.direction;

        }
    }
    void RayGrid()
    {
        if (isGrounded())
        {
            if (hit.transform.rotation.eulerAngles.y == 90 || hit.transform.rotation.eulerAngles.y == -90)
            {
                Debug.DrawRay(new Vector3(hit.transform.position.x, hit.point.y, hit.point.z), fpsCam.transform.forward, Color.red);
                if (Physics.Raycast(new Vector3(hit.transform.position.x, hit.point.y, hit.point.z), fpsCam.transform.forward, out hit))
                {

                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Gramofone")
                    {

                        hit.transform.gameObject.GetComponent<Gramofone>().animator.SetBool("WaterBool", true);
                        hit.transform.gameObject.GetComponent<Gramofone>().animator.speed = 1;

                    }
                    if (Input.GetMouseButtonDown(1) && hit.transform.tag == "Vaso" && hit.transform.GetComponent<Vaso>().animator.GetBool("WaterBool") == true && Player.GetComponent<player>().take == false)
                    {
                        hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", false);

                        Player.GetComponent<player>().ShotIndex = 0;
                        Player.GetComponent<player>().index = 4;

                    }
                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Vaso")
                    {
                        hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", true);



                    }
                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Canhao")
                    {
                        hit.transform.gameObject.GetComponent<Canhao>().disparo = true;



                    }
                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "VasoFixo")
                    {
                        hit.transform.gameObject.GetComponent<VasoFixo>().gameObject.GetComponent<Animator>().SetBool("Water", true);
                        hit.transform.gameObject.GetComponent<VasoFixo>().NotWater = false;

                    }
                    if (Input.GetMouseButtonDown(1) && hit.transform.tag == "VasoFixo")
                    {
                        hit.transform.gameObject.GetComponent<VasoFixo>().gameObject.GetComponent<Animator>().SetBool("Water", false);
                        Player.GetComponent<player>().ShotIndex = 0;
                        Player.GetComponent<player>().index = 4;

                    }
                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "ParedePortal")
                    {
                        Player.GetComponent<player>().portalIndex++;
                        switch (Player.GetComponent<player>().portalIndex)
                        {
                            case 1:
                                Player.GetComponent<player>().portais[0].SetActive(true);
                                break;
                            case 2:
                                Player.GetComponent<player>().portais[1].SetActive(true);
                                break;
                            case 3:
                                Player.GetComponent<player>().portais[0].SetActive(true);
                                Player.GetComponent<player>().portalIndex = 1;
                                break;
                        }
                        if (Player.GetComponent<player>().portalIndex == 1)
                        {
                            Player.GetComponent<player>().portais[0].transform.position = new Vector3(hit.rigidbody.position.x, hit.rigidbody.position.y, hit.rigidbody.position.z + .1f);
                            Player.GetComponent<player>().portais[0].transform.rotation = hit.rigidbody.rotation;
                        }
                        if (Player.GetComponent<player>().portalIndex == 2)
                        {
                            Player.GetComponent<player>().portais[1].transform.position = new Vector3(hit.rigidbody.position.x, hit.rigidbody.position.y, hit.rigidbody.position.z + .1f);
                            Player.GetComponent<player>().portais[1].transform.rotation = hit.rigidbody.rotation;
                        }

                    }
                }
            }
            else
            {
                Debug.DrawRay(new Vector3(hit.point.x, hit.point.y, hit.transform.position.z), fpsCam.transform.forward, Color.red);
                if (Physics.Raycast(new Vector3(hit.point.x, hit.point.y, hit.transform.position.z), fpsCam.transform.forward, out hit))
                {

                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Gramofone")
                    {

                        hit.transform.gameObject.GetComponent<Gramofone>().animator.SetBool("WaterBool", true);

                    }
                    if (Input.GetMouseButtonDown(1) && hit.transform.tag == "Vaso" && hit.transform.GetComponent<Vaso>().animator.GetBool("WaterBool") == true && Player.GetComponent<player>().take == false)
                    {
                        hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", false);
                        Player.GetComponent<player>().ShotIndex = 0;
                        Player.GetComponent<player>().index = 4;


                    }
                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Canhao")
                    {
                        hit.collider.transform.parent.gameObject.GetComponent<Canhao>().disparo = true;



                    }
                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "VasoFixo")
                    {
                        hit.transform.gameObject.GetComponent<VasoFixo>().gameObject.GetComponent<Animator>().SetBool("Water", true);
                        hit.transform.gameObject.GetComponent<VasoFixo>().NotWater = false;
                    }
                    if (Input.GetMouseButtonDown(1) && hit.transform.tag == "VasoFixo")
                    {
                        hit.transform.gameObject.GetComponent<VasoFixo>().gameObject.GetComponent<Animator>().SetBool("Water", false);
                        Player.GetComponent<player>().ShotIndex = 0;
                        Player.GetComponent<player>().index = 4;

                    }
                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Vaso")
                    {
                        hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", true);



                    }
                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "ParedePortal")
                    {
                        Player.GetComponent<player>().portalIndex++;
                        switch (Player.GetComponent<player>().portalIndex)
                        {
                            case 1:
                                Player.GetComponent<player>().portais[0].SetActive(true);
                                break;
                            case 2:
                                Player.GetComponent<player>().portais[1].SetActive(true);
                                break;
                            case 3:
                                Player.GetComponent<player>().portais[0].SetActive(true);
                                Player.GetComponent<player>().portalIndex = 1;
                                break;
                        }
                        if (Player.GetComponent<player>().portalIndex == 1)
                        {
                            Player.GetComponent<player>().portais[0].transform.position = new Vector3(hit.rigidbody.position.x, hit.rigidbody.position.y, hit.rigidbody.position.z + .1f);
                            Player.GetComponent<player>().portais[0].transform.rotation = hit.rigidbody.rotation;
                        }
                        if (Player.GetComponent<player>().portalIndex == 2)
                        {
                            Player.GetComponent<player>().portais[1].transform.position = new Vector3(hit.rigidbody.position.x, hit.rigidbody.position.y, hit.rigidbody.position.z + .1f);
                            Player.GetComponent<player>().portais[1].transform.rotation = hit.rigidbody.rotation;
                        }

                    }
                }
            }



        }
    }
    void eventos()
    {
        //ativacoe dos eventos  

        if (Physics.Raycast(oring, out hit, 4))
        {
            if (Input.GetMouseButtonDown(1) && hit.transform.tag == "Vaso" && FindObjectOfType<Orbit>().InHand == false && hit.transform.GetComponent<Vaso>().animator.GetBool("WaterBool") == true && Player.GetComponent<player>().take == false)
            {
                if (hit.collider.gameObject.GetComponent<Vaso>().congelado == false)
                {
                    hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", false);
                    Player.GetComponent<player>().ShotIndex = 0;
                    Player.GetComponent<player>().index = 4;

                }
            }

        }

        if (Physics.Raycast(oring, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Vaso" && FindObjectOfType<Orbit>().InHand == true)
            {
                if (hit.collider.gameObject.GetComponent<Vaso>().congelado == false)
                    hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", true);


            }

            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Gramofone" && FindObjectOfType<Orbit>().InHand == true && isGrounded() == false)
            {
                hit.transform.gameObject.GetComponent<Gramofone>().animator.SetBool("WaterBool", true);


            }
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Canhao" && FindObjectOfType<Orbit>().InHand == true)
            {
                hit.transform.parent.gameObject.GetComponent<Canhao>().disparo = true;


            }
        }

    }
    bool isGrounded()
    {
        return Physics.CheckSphere(hit.point, .5f, Grade);
    }
}






































































