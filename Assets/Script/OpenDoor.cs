using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Audio;

public class OpenDoor : MonoBehaviour
{
    public List<GameObject> Buutons, gramofone;
    public bool Button, Gramofono;
    public GameObject Door;
    public AudioSource open, closed;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Button == true && Gramofono == false && Door.GetComponent<LevelController>().DoorClosed == false)
            if (Buutons.All(events => events == events.GetComponent<Button>().operDoorEvent == true))
            {
                GetComponent<Animator>().SetBool("DoorBool", true);

            }
            else
            {
                GetComponent<Animator>().SetBool("DoorBool", false);
            }


        if (Gramofono == true && Button == false && Door.GetComponent<LevelController>().DoorClosed == false)
            if (gramofone.All(events => events == events.GetComponent<Gramofone>().DoorEvent == true))
                GetComponent<Animator>().SetBool("DoorBool", true);


        if (Gramofono == true && Button == true && Door.GetComponent<LevelController>().DoorClosed == false)
        {
            if (gramofone.All(events => events == events.GetComponent<Gramofone>().DoorEvent == true) && Buutons.All(events => events == events.GetComponent<Button>().operDoorEvent == true))
            {
                GetComponent<Animator>().SetBool("DoorBool", true);
            }


        }

    }
    public void OpenSound()
    {


        open.Play();

    }
    public void closedSound()
    {

        closed.Play();

    }
}
