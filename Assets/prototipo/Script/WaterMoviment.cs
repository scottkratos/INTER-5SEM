using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoviment : MonoBehaviour
{
    public float Y = 0f;
    public bool maxy = false;

    private void Start()
    {

    }
    void Update()
    {
        if (FindObjectOfType<player>().index <= 4 || FindObjectOfType<player>().index >= -1)
        {
            transform.localScale = new Vector3(transform.localScale.x, Y, transform.localScale.z);

        }
        if (maxy == true)
        {
            FindObjectOfType<DoorMoviment>().StartCoroutine("Open");
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vaso")
            maxy = true;

    }






}
