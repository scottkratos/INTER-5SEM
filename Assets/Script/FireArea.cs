using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ice")
        {
            other.gameObject.GetComponent<IceTranform>().StartCoroutine("evaporation");

        }
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<player>().power.GetComponent<Orbit>().InHand == true)
            {
                other.gameObject.GetComponent<player>().index = -1;
                other.gameObject.GetComponent<player>().ShotIndex = 4;
            }

        }
        if (other.tag == "Vaso")
        {
            if (other.gameObject.GetComponent<Vaso>().animator.GetBool("WaterBool") == true)
            {
                other.gameObject.GetComponent<Vaso>().transform.GetChild(5).GetComponent<ParticleSystem>().Play();
                other.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", false);

            }


        }


    }
}
