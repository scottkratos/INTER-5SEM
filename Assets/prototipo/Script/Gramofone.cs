using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramofone : MonoBehaviour
{
    public GameObject Water, Door;
    public Animator anim;
    public bool grade;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void gramofoneAnim()
    {
        if (FindObjectOfType<player>().animationIndex == 0)
            anim.speed = 0;


    }
    void gramofoneAnim1()
    {
        if (FindObjectOfType<player>().animationIndex == 1)
            anim.speed = 0;


    }
    void gramofoneAnim2()
    {
        if (FindObjectOfType<player>().animationIndex == 2)
            anim.speed = 0;


    }
    void gramofoneAnim3()
    {
        if (FindObjectOfType<player>().animationIndex == 3)
            anim.speed = 0;

    }
    void gramofoneAnim4()
    {
        if (grade == true)
        {
            Door.SetActive(false);
        }
        else
        {
            Door.GetComponent<Animator>().SetBool("DoorBool", true);

        }





    }
}
