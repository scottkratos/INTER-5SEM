using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoviment : MonoBehaviour
{


    public GameObject Water, Door;
    public Animator anim;

    private void Start()
    {

    }
    void Update()
    {




    }

    void stopAnim()
    {
        if (FindObjectOfType<player>().animationIndex == 0)
            anim.speed = 0;


    }
    void stopAnim1()
    {
        if (FindObjectOfType<player>().animationIndex == 1)
            anim.speed = 0;


    }
    void stopAnim2()
    {
        if (FindObjectOfType<player>().animationIndex == 2)
            anim.speed = 0;


    }
    void stopAnim3()
    {
        if (FindObjectOfType<player>().animationIndex == 3)
            anim.speed = 0;

    }
    void stopAnim4()
    {




    }






}
