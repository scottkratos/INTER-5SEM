using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject player, agua, aguaRespaw;
    public GameObject reciever;
    public float anglePortalZ, anglePortalX;
    public float RorationPortalZ, RotationPortalX, RotationPortalXY;
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
        player = FindObjectOfType<player>().gameObject;
        rayDirecion.origin = transform.position;
        rayDirecion.direction = transform.forward;
    }

    void Update()
    {
        if(playerIsOverLapping == true)
        {
            player.GetComponent<player>().CameraController.y = 0;
            player.GetComponent<player>().CameraController.y += FindObjectOfType<player>().transform.rotation.y + RotationPortalX;
            player.transform.position = new Vector3(reciever.transform.position.x + anglePortalX, reciever.transform.position.y + RotationPortalXY, reciever.transform.position.z + anglePortalZ); 

        }
        rayDirecion.origin = new Vector3(transform.position.x, transform.position.y - .7f, transform.position.z);
        rayDirecion.direction = transform.forward;
        AnglePortal();
        aguaRespaw.transform.position = rayDirecion.origin;
        Debug.DrawRay(rayDirecion.origin, rayDirecion.direction);
        if (Physics.Raycast(rayDirecion, out hit))
        {
            if (disparo == true)
            {
                Debug.Log(hit.point);
                if (hit.transform.tag == "Vaso")
                {
                    hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", true);
                }
                agua.SetActive(true);
                agua.transform.Translate(0, 0, 1.5f);
                Invoke("disparoR", .1f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverLapping = true;
          
            // player.transform.position = new Vector3(reciever.transform.position.x, reciever.transform.position.y + RotationPortalXY, reciever.transform.position.z);

        }
        if (other.tag == "Ice")
        {
            other.gameObject.transform.position = new Vector3(reciever.transform.position.x, reciever.transform.position.y - 3, reciever.transform.position.z);
        }
        if (other.tag == "Vaso")
        {
            other.gameObject.transform.position = new Vector3(reciever.transform.position.x + anglePortalX, reciever.transform.position.y, reciever.transform.position.z + anglePortalZ);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverLapping = false;
            //Debug.Log(reciever.transform.localRotation.eulerAngles.x);

        }
        if (other.tag == "Vaso")
        {
            // other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    // calculo dos angulos de teleporte 
    void AnglePortal()
    {
        if (reciever.transform.localRotation.eulerAngles.y == 270 && reciever.transform.localRotation.eulerAngles.x != 90)
        {
            anglePortalX = -1.6f;
            RotationPortalX = 140;
            RotationPortalXY = 0;
        }

        if (reciever.transform.localRotation.eulerAngles.y == 90 && reciever.transform.localRotation.eulerAngles.x != 90)
        {
            anglePortalX = 1.6f;
            RotationPortalX = 90;
            RotationPortalXY = 0;
        }
        if (reciever.transform.localRotation.eulerAngles.y == 180 && reciever.transform.localRotation.eulerAngles.x != 90)
        {
            anglePortalZ = -1.6f;
            RotationPortalX = 90;
            RotationPortalXY = 0;
        }
        if (reciever.transform.localRotation.eulerAngles.y == 0 && reciever.transform.localRotation.eulerAngles.x != 90)
        {
            anglePortalZ = 1.6f;
            RotationPortalX = 0;
            RotationPortalXY = 0;
        }
        if (reciever.transform.localRotation.eulerAngles.x == 90)
        {
            RotationPortalXY = -3f;
        }






    }
    void disparoR()
    {
        disparo = false;
        agua.SetActive(false);
        agua.transform.position = aguaRespaw.transform.position;
    }

}
