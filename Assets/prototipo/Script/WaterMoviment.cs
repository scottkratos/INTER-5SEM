using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoviment : MonoBehaviour
{


    public GameObject evetObject;
    public Animator anim;
    public bool Grade, door, button;

    private void Awake()
    {
        anim.SetBool("WaterBool", false);
    }


    void EventGameplaye()
    {

        if (door == true)
        {
            evetObject.GetComponent<Animator>().SetBool("DoorBool", true);
        }
        if (Grade == true)
        {
            evetObject.SetActive(false);
        }
        if (button == true)
        {
            evetObject.GetComponent<Button>().AmoutWaterVase = true;
        }





    }































}
