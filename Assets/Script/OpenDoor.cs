using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OpenDoor : MonoBehaviour
{
    public List<GameObject> EventObjects;
    public bool Button, Gramofono;
    public GameObject Door;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Button == true && Door.GetComponent<LevelController>().DoorClosed == false)
            if (EventObjects.All(events => events == events.GetComponent<Button>().operDoorEvent == true) && EventObjects.All(events => events == events.GetComponent<Button>().AmoutWaterVase == true))
            {
                GetComponent<Animator>().SetBool("DoorBool", true);

            }
            else
            {
                GetComponent<Animator>().SetBool("DoorBool", false);
            }


        if (Gramofono == true && Door.GetComponent<LevelController>().DoorClosed == false)
            if (EventObjects.All(events => events == EventObjects.LastOrDefault().GetComponent<WaterMoviment>().DoorEvent == true))
                GetComponent<Animator>().SetBool("DoorBool", true);

    }

}
