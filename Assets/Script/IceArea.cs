using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceArea : MonoBehaviour
{
    int index;
    public GameObject Gelo;
    [HideInInspector]
    public bool inHand;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (index)
        {
            case 0:
                Gelo.GetComponent<IceTranform>().AmountWater = 0.3f;
                break;
            case 1:
                Gelo.GetComponent<IceTranform>().AmountWater = 0.6f;
                break;
            case 2:
                Gelo.GetComponent<IceTranform>().AmountWater = 0.9f;
                break;
            case 3:
                Gelo.GetComponent<IceTranform>().AmountWater = 1.2f;
                break;
            case 4:
                Gelo.GetComponent<IceTranform>().AmountWater = 1.5f;
                break;



        }


        if (inHand == true)
        {
           // Gelo.transform.parent = FindObjectOfType<player>().hand;
            if (Gelo.transform.localScale.y > Gelo.GetComponent<IceTranform>().AmountWater)
            {
                FindObjectOfType<IceTranform>().StopCoroutine("size");
            }

        }
        if (inHand == false)
        {
           // Gelo.GetComponent<Rigidbody>().isKinematic = false;
           // Gelo.transform.parent = null;

        }
        if (Input.GetMouseButtonDown(1))
        {
           // inHand = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && FindObjectOfType<player>().index > -1)
        {
            Gelo.transform.position = FindObjectOfType<player>().hand.position;
            inHand = true;
            Gelo.SetActive(true);
            Gelo.GetComponent<Rigidbody>().isKinematic = true;
            index = FindObjectOfType<player>().index;
            FindObjectOfType<player>().index -= index + 1;
            FindObjectOfType<IceTranform>().StartCoroutine("size");

        }
    }
}
