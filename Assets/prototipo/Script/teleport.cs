using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject player;
    public Transform reciever;
    float anglePortalZ, anglePortalX;
    float RorationPortalZ, RotationPortalX;
    public bool playerIsOverLapping = false;

    private void Start()
    {
        anglePortalZ = -0.6f;
    }
    void Update()
    {
        AnglePortal();
        if (playerIsOverLapping == true)
        {

            player.transform.position = new Vector3(reciever.position.x + anglePortalX, reciever.position.y, reciever.position.z + anglePortalZ);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<player>().CameraController.y += FindObjectOfType<player>().transform.rotation.y + RotationPortalX;
            playerIsOverLapping = true;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverLapping = false;

        }
    }
    // calculo dos angulos de teleporte 
    void AnglePortal()
    {
        if (reciever.transform.rotation.y > 0)
        {
            anglePortalX = 1.2f;
        }
        if (reciever.transform.rotation.y < 0)
        {
            anglePortalX = -1.2f;
        }

        if (reciever.transform.rotation.y == 0)
        {
            anglePortalZ = 1.2f;
            RotationPortalX = 0;
        }
        

    }




































































}
