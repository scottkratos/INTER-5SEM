using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    int index;
    public GameObject Gelo;
    bool inHand;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Gelo.transform.localScale.y < 0f)
        {
            FindObjectOfType<IceTranform>().StopCoroutine("evaporation");
            Gelo.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            inHand = true;
            index = FindObjectOfType<player>().index;
            FindObjectOfType<player>().index -= index + 1;
            Gelo.GetComponent<IceTranform>().StartCoroutine("evaporation");


        }
    }
}
