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

        eventos();
        oring = Camera.main.ScreenPointToRay(Input.mousePosition);
        //direcao do disparo 
        foreach (GameObject shot in ShotWater)
        {
            shot.transform.position += Player.GetComponent<player>().eyes.direction;

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
                hit.transform.parent.gameObject.GetComponent<Canhao>().transform.GetChild(0).transform.GetChild(1).GetComponent<ParticleSystem>().Play();

            }
        }

    }
    bool isGrounded()
    {
        return Physics.CheckSphere(hit.point, .5f, Grade);
    }
}






































































