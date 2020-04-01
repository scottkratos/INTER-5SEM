using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Animator anim, Door;
    public Transform vase;
    public bool AmoutWaterVase, Restard, OperDoor;
    public GameObject[] gramofone;



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        DistanceButton();

    }
    void openDoor()
    {
        if (OperDoor == true)
            Door.SetBool("DoorBool", true);

    }
    void ClosedDoor()
    {
        if (OperDoor == true)
            Door.SetBool("DoorBool", false);

    }
    void DistanceButton()
    {

        float distacia = Vector3.Distance(vase.transform.position, transform.position);


        if (distacia < 1 && AmoutWaterVase == true && Door != null)
        {
            anim.SetBool("ButtonBool", true);
        }
        else
        {
            anim.SetBool("ButtonBool", false);
        }

    }











    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aaaaaaaaaaaaaappp");
        if (Restard == true && collision.gameObject.tag == "Player")
        {
            vase.GetComponent<Animator>().SetBool("WaterBool", true);
            foreach (var item in gramofone)
            {
                item.GetComponent<Animator>().SetBool("WaterBool", false);

            }
        }
        if (Restard == true && AmoutWaterVase == true)
        {
            vase.GetComponent<Animator>().SetBool("WaterBool", true);
            foreach (var item in gramofone)
            {
                item.GetComponent<Animator>().SetBool("WaterBool", false);

            }
        }
    }






}








