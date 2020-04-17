using System.Collections;
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
        //direcao do disparo 
        foreach (GameObject shot in ShotWater)
        {
            shot.transform.position += Camera.main.transform.forward;

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

                        hit.transform.gameObject.GetComponent<WaterMoviment>().animator.SetBool("WaterBool", true);
                        hit.transform.gameObject.GetComponent<WaterMoviment>().animator.speed = 1;

                    }
                    if (Input.GetMouseButtonDown(1) && hit.transform.tag == "Vaso" && hit.transform.GetComponent<WaterMoviment>().animator.GetBool("WaterBool") == true)
                    {
                        hit.transform.gameObject.GetComponent<WaterMoviment>().animator.SetBool("WaterBool", false);

                        Player.GetComponent<player>().ShotIndex = 0;
                        Player.GetComponent<player>().index = 4;

                    }
                }
            }
            if (hit.transform.rotation.eulerAngles.y == 0)
            {
                Debug.DrawRay(new Vector3(hit.point.x, hit.point.y, hit.transform.position.z), fpsCam.transform.forward, Color.red);
                if (Physics.Raycast(new Vector3(hit.point.x, hit.point.y, hit.transform.position.z), fpsCam.transform.forward, out hit))
                {

                    if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Gramofone")
                    {

                        hit.transform.gameObject.GetComponent<WaterMoviment>().animator.SetBool("WaterBool", true);
                        hit.transform.gameObject.GetComponent<WaterMoviment>().animator.speed = 1;
                    }
                    if (Input.GetMouseButtonDown(1) && hit.transform.tag == "Vaso" && hit.transform.GetComponent<WaterMoviment>().animator.GetBool("WaterBool") == true)
                    {
                        hit.transform.gameObject.GetComponent<WaterMoviment>().animator.SetBool("WaterBool", false);
                        Player.GetComponent<player>().ShotIndex = 0;
                        Player.GetComponent<player>().index = 4;


                    }
                }
            }



        }
    }
    void eventos()
    {
        //ativacoe dos eventos  
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Vaso" && FindObjectOfType<Orbit>().InHand == true)
            {
                hit.transform.gameObject.GetComponent<WaterMoviment>().animator.SetBool("WaterBool", true);
                hit.transform.gameObject.GetComponent<AudioSource>().Play();
                if (hit.transform.gameObject.GetComponent<WaterMoviment>().animator.speed == 0)
                    hit.transform.gameObject.GetComponent<WaterMoviment>().animator.speed = 1;
            }

            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Gramofone" && FindObjectOfType<Orbit>().InHand == true && isGrounded() == false)
            {
                hit.transform.gameObject.GetComponent<WaterMoviment>().animator.SetBool("WaterBool", true);
                hit.transform.gameObject.GetComponent<AudioSource>().Play();
                if (hit.transform.gameObject.GetComponent<WaterMoviment>().animator.speed == 0)
                    hit.transform.gameObject.GetComponent<WaterMoviment>().animator.speed = 1;
            }
        }
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 2))
        {
            if (Input.GetMouseButtonDown(1) && hit.transform.tag == "Vaso" && FindObjectOfType<Orbit>().InHand == false && hit.transform.GetComponent<WaterMoviment>().animator.GetBool("WaterBool") == true)
            {
                hit.transform.gameObject.GetComponent<WaterMoviment>().animator.SetBool("WaterBool", false);
                Player.GetComponent<player>().ShotIndex = 0;
                Player.GetComponent<player>().index = 4;
            }

        }


    }
    bool isGrounded()
    {
        return Physics.CheckSphere(hit.point, .5f, Grade);
    }
}






































































