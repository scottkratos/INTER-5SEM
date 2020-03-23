using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [HideInInspector]
    public bool take = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (take == true)
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
            transform.transform.parent = FindObjectOfType<player>().hand.parent;

        }
        if (Input.GetMouseButtonDown(0))
        {
            transform.GetComponent<Rigidbody>().isKinematic = false;
            transform.transform.parent = null;
            take = false;
        }


    }
}
