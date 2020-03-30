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
    public LayerMask Grade;
    public GameObject colliderGrade;

    private void Awake()
    {
        Hand = GameObject.FindGameObjectWithTag("HandTrue");
        vaseRigidbody = GetComponent<Rigidbody>();
        vasoCollider = GetComponent<BoxCollider>();
        Grade = LayerMask.GetMask("Grade");
    }

    private void Update()
    {

    }


    private void LateUpdate()
    {
        if (take == true)
        {
            transform.position = Hand.transform.position;
            vaseRigidbody.isKinematic = true;
            vasoCollider.enabled = false;
            if (isGrounded())
            {
                take = false;
            }

        }
        else
        {
            vaseRigidbody.isKinematic = false;
            vasoCollider.enabled = true;

        }

    }
    bool isGrounded()
    {
        return Physics.CheckSphere(transform.position, .5f, Grade);
    }




}
