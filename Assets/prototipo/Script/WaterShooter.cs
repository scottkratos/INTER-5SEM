using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShooter : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.1f, 0, 0) + FindObjectOfType<player>().cameraTransform.forward;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vaso")
        {
            FindObjectOfType<WaterMoviment>().Y += 0.5f;
        }
        if (collision.gameObject.tag == "Portal")
        {
            //FindObjectOfType<player>().portalIndex++;
            Debug.Log("portal");
        }



    }













}
