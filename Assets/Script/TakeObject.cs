using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TakeObject : MonoBehaviour
{
    [HideInInspector]
    public bool take;
    [HideInInspector]
    public GameObject Hand, player;
    public GameObject checkAmbiente;
    Rigidbody vaseRigidbody;
    BoxCollider vasoCollider;
    public LayerMask Grid, Ambiente;
    

    private void Awake()
    {
        Hand = GameObject.FindGameObjectWithTag("HandTrue");
        player = GameObject.FindGameObjectWithTag("Player");
        vaseRigidbody = GetComponent<Rigidbody>();
        vasoCollider = GetComponent<BoxCollider>();
    }




    private void LateUpdate()
    {


        if (isGrounded() && take == true)
        {
            take = false;
            player.GetComponent<player>().take = false;
        }
        if (NoAmbiente() && take == true)
        {

            take = false;
            player.GetComponent<player>().take = false;


        }
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
    bool isGrounded()
    {
        return Physics.CheckSphere(transform.position, .2f, Grid);

    }
    bool NoAmbiente()
    {
        return Physics.CheckSphere(checkAmbiente.transform.position, .2f, Ambiente);
    }




}

















