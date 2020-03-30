using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [HideInInspector]
    public bool take;
    [HideInInspector]
    public GameObject Hand;
    Rigidbody vaseRigidbody;
    BoxCollider vasoCollider;

  
    private void Awake()
    {
        Hand = GameObject.FindGameObjectWithTag("HandTrue");
        vaseRigidbody = GetComponent<Rigidbody>();
        vasoCollider = GetComponent<BoxCollider>();
    }




    private void LateUpdate()
    {
        if (take == true)
        {
            transform.position = Hand.transform.position;
            vaseRigidbody.isKinematic = true;
            vasoCollider.enabled = false;

        }
        else
        {
            vaseRigidbody.isKinematic = false;
            vasoCollider.enabled = true;

        }

    }





}
