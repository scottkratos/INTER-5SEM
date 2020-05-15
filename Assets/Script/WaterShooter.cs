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
                hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", false);
                Player.GetComponent<player>().ShotIndex = 0;
                Player.GetComponent<player>().index = 4;
            }

        }

        if (Physics.Raycast(oring, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Vaso" && FindObjectOfType<Orbit>().InHand == true)
            {
                hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", true);


            }

            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Gramofone" && FindObjectOfType<Orbit>().InHand == true && isGrounded() == false)
            {
                hit.transform.gameObject.GetComponent<Gramofone>().animator.SetBool("WaterBool", true);


            }
        }

    }
    bool isGrounded()
    {
        return Physics.CheckSphere(hit.point, .5f, Grade);
    }
}






































































