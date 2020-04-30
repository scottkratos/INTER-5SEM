using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TakeObject : MonoBehaviour
{

    static TakeObject _Controller;
    public static TakeObject Controller
    {
        get
        {
            return _Controller;
        }
    }

    [HideInInspector]
    public bool take;
    [HideInInspector]
    public GameObject Hand;
    public player Player;
    public GameObject checkAmbiente;
    Rigidbody vaseRigidbody;
    BoxCollider vasoCollider;
    public LayerMask Grid, Ambiente;
    public Quaternion rotationOrigin;

    private void Awake()
    {
        _Controller = this;
        Hand = player.Instance.gameObject.transform.GetChild(0).transform.GetChild(1).gameObject;
        Player = player.Instance;
        vaseRigidbody = GetComponent<Rigidbody>();
        vasoCollider = GetComponent<BoxCollider>();
        rotationOrigin = transform.rotation;
    }




    private void LateUpdate()
    {
        if (isGrounded() && take == true)
        {

            take = false;
            Player.take = false;
        }
        if (NoAmbiente() && take == true)
        {

            take = false;
            Player.take = false;


        }
        if (take == true)
        {
            transform.SetParent(Hand.transform, false);
            transform.position = Hand.transform.position;
            transform.rotation = Player.cameraTransform.rotation;
            vaseRigidbody.isKinematic = true;

        }
        else
        {
            transform.parent = null;
            transform.rotation = rotationOrigin;
            vaseRigidbody.isKinematic = false;

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

















