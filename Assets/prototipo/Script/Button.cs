using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator anim, Door;
    public Transform vase;
    public bool AmoutWaterVase;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DistanceButton();
       
    }
    void openDoor()
    {
        Door.SetBool("DoorBool", true);

    }
    void ClosedDoor()
    {
        Door.SetBool("DoorBool", false);

    }
    void DistanceButton()
    {

        float distacia = Vector3.Distance(vase.transform.position, transform.position);
        if (distacia < 1 && AmoutWaterVase == true)
        {
            anim.SetBool("ButtonBool", true);

        }
        else
        {
            anim.SetBool("ButtonBool", false);
        }



    }



}
