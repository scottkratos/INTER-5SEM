using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator anim, Door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void openDoor()
    {
        Door.SetBool("DoorBool", true);
        anim.speed = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vaso")
        {

            anim.SetBool("ButtonBool", true);


        }
    }
}
