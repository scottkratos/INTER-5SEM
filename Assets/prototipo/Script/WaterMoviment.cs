using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoviment : MonoBehaviour
{


    public GameObject evetObject;
    public Animator anim;

    private void Awake()
    {
        anim.SetBool("WaterBool", false);
    }


    void EventGameplaye()
    {

        if (gameObject.tag == "Gramofone")
        {
            evetObject.GetComponent<Animator>().SetBool("DoorBool", true);
        }
        else
        {
            evetObject.GetComponent<Button>().AmoutWaterVase = true;
        }
    }































}
