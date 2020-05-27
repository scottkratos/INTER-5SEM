using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject player, agua, aguaRespaw;
    public GameObject reciever;
    float anglePortalZ, anglePortalX;
    float RorationPortalZ, RotationPortalX;
    public bool playerIsOverLapping = false;
    public bool disparo;
    public Ray rayDirecion;
    RaycastHit hit;
    public static teleport instace;


    private void Awake()
    {
        instace = this;
    }
    private void Start()
    {
        rayDirecion.origin = transform.position;
        rayDirecion.direction = transform.forward;
    }

    void Update()
    {
        AnglePortal();
        aguaRespaw.transform.position = rayDirecion.origin;
        Debug.DrawRay(rayDirecion.origin, rayDirecion.direction);
        if (Physics.Raycast(rayDirecion, out hit))
        {
            if (disparo == true)
            {
                agua.SetActive(true);
                agua.transform.Translate(0, 0, 1);

            }


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverLapping = true;
            FindObjectOfType<player>().CameraController.y = 0;
            FindObjectOfType<player>().CameraController.y += FindObjectOfType<player>().transform.rotation.y + RotationPortalX;
            player.transform.position = new Vector3(reciever.transform.position.x + anglePortalX, reciever.transform.position.y, reciever.transform.position.z + anglePortalZ);


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
        if (reciever.transform.localRotation.eulerAngles.y == 270)
        {
            anglePortalX = -1.6f;
            RotationPortalX = -90;

        }
        if (reciever.transform.localRotation.eulerAngles.y == 90)
        {
            anglePortalX = 1.6f;
            RotationPortalX = 90;
        }
        if (reciever.transform.localRotation.eulerAngles.y == 180)
        {
            anglePortalZ = -1.6f;
            RotationPortalX = 180;
        }
        if (reciever.transform.localRotation.eulerAngles.y == 0)
        {
            anglePortalZ = 1.6f;
            RotationPortalX = 0;
        }



    }





































































}
