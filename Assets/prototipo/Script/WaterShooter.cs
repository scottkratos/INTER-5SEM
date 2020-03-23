using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShooter : MonoBehaviour
{
    Ray eyes;
    [HideInInspector]
    public RaycastHit hit;
    [HideInInspector]
    public Rigidbody HitRigidbody;




    void Update()
    {
        transform.position += new Vector3(0.1f, 0, 0) + FindObjectOfType<player>().cameraTransform.forward;
        eyes.origin = transform.position;
        eyes.direction = transform.right;

    }
    private void OnCollisionEnter(Collision collision)
    {


        for (int i = 0; i < FindObjectOfType<player>().vasos.Length; i++)
        {

            if (collision.rigidbody == FindObjectOfType<player>().vasos[i].gameObject.GetComponent<Rigidbody>())
            {
                FindObjectOfType<player>().vasos[i].GetComponent<WaterMoviment>().Y += 0.5f;
            }

        }



    }

















}
