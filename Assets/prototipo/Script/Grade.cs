using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grade : MonoBehaviour
{
    GameObject grade;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Gramofone")
        {
            // FindObjectOfType<player>().index--;
            // FindObjectOfType<player>().ShotIndex++;
            FindObjectOfType<player>().animationIndex++;





            switch (FindObjectOfType<player>().animationIndex)
            {
                case 0:
                    collision.transform.gameObject.GetComponent<Gramofone>().anim.SetBool("GramofoneBool", true);

                    break;
                case 1:
                    collision.transform.gameObject.GetComponent<Gramofone>().anim.speed = 1;

                    break;

                case 2:
                    collision.transform.gameObject.GetComponent<Gramofone>().anim.speed = 1;

                    break;

                case 3:
                    collision.transform.gameObject.GetComponent<Gramofone>().anim.speed = 1;

                    break;

                case 4:
                    collision.transform.gameObject.GetComponent<Gramofone>().anim.speed = 1;

                    break;




            }
        }
    }
}
