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
    private Animator animator;
    private bool Cutscene;
    private bool Lock = true;
    private PuzzleComplete CompleteRef;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Cutscene = GetComponentInParent<LevelController>().CutsceneDoor;
        CompleteRef = transform.parent.transform.GetChild(3).GetComponent<PuzzleComplete>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cutscene) return;

        if (Button == true && Gramofono == false && Door.GetComponent<LevelController>().DoorClosed == false)
            if (Buutons.All(events => events == events.GetComponent<Button>().operDoorEvent == true))
            {
                animator.SetBool("DoorBool", true);

            }
            else
            {
                animator.SetBool("DoorBool", false);
            }


        if (Gramofono == true && Button == false && Door.GetComponent<LevelController>().DoorClosed == false)
            if (gramofone.All(events => events == events.GetComponent<Gramofone>().DoorEvent == true))
                animator.SetBool("DoorBool", true);
            else
                animator.SetBool("DoorBool", false);

        if (Gramofono == true && Button == true && Door.GetComponent<LevelController>().DoorClosed == false)
        {
            if (gramofone.All(events => events.GetComponent<Gramofone>().DoorEvent == true) && Buutons.All(events => events.GetComponent<Button>().operDoorEvent == true))
            {
                animator.SetBool("DoorBool", true);
            }
            else
            {
                animator.SetBool("DoorBool", false);
            }


        }

    }
    public void OpenSound()
    {
        open.Play();
        //CompleteRef.IsDoorOpen(true);
    }
    public void closedSound()
    {
        if (Lock)
        {
            Lock = false;
            return;
        }
        closed.Play();
       // CompleteRef.IsDoorOpen(true);
    }
}
