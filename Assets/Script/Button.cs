using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class Button : MonoBehaviour
{
    public Animator anim, Door;
    public Transform vase;
    public bool AmoutWaterVase, Restard, OperDoor;
    public GameObject[] gramofone;
    public AudioSource ButtonSong, finalPuzzle;


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DistanceButton();
        if (anim.GetComponent<Animator>().GetBool("ButtonBool") == false)
        {


        }

    }
    void openDoor()
    {
        if (OperDoor == true)
        {
            Door.SetBool("DoorBool", true);
            Door.GetComponent<AudioSource>().Play();
            finalPuzzle.Play();

        }
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




    void restard()
    {
        if (Restard == true)
        {
            vase.GetComponent<Animator>().SetBool("WaterBool", true);

            foreach (var item in gramofone)
            {
                item.GetComponent<Animator>().SetBool("WaterBool", false);

            }

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        ButtonSong.Play();
        if (collision.gameObject.tag == "Player")
        {
            restard();
        }
    }























}








