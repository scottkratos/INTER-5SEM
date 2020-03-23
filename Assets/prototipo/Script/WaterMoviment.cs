using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoviment : MonoBehaviour
{
    public float Y = 0f;
    public GameObject Water;
    public bool maxy = false;

    public Animator anim;
    private void Start()
    {

    }
    void Update()
    {

        if (FindObjectOfType<player>().index <= 4 || FindObjectOfType<player>().index >= -1)
        {
            // Water.transform.localScale = new Vector3(transform.localScale.x, Y, transform.localScale.z);

        }
        if (maxy == true)
        {




        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vaso")
            maxy = true;

    }
    void stopAnim()
    {
        maxy = true;
        anim.speed = 0;


    }





}
