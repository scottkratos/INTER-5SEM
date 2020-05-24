using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && other.gameObject.GetComponent<player>().power.GetComponent<Orbit>().InHand == true)
        {
            Instantiate(FindObjectOfType<player>().GetComponent<IceTranform>().Gelo).SetActive(true);
        }
    }
}
