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
    Vector3 HandOring;
    Rigidbody vaseRigidbody;
    BoxCollider vasoCollider;
    bool toque;
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
    private void Start()
    {

    }


    private void LateUpdate()
    {
        HandOring = player.Instance.gameObject.transform.GetChild(0).transform.GetChild(2).gameObject.transform.position;
        if (isGrounded() && take == true)
        {

            Hand.transform.position = Vector3.Lerp(Hand.transform.position, Player.transform.position, .1f);
            if (Vector3.Distance(Hand.transform.position, Player.transform.position) < 1.2f)
            {

                Player.take = false;
                take = false;

            }

        }

        if (NoAmbiente() && take == true)
        {

            Hand.transform.position = Vector3.Lerp(Hand.transform.position, Player.transform.position, .1f);
            if (Vector3.Distance(Hand.transform.position, Player.transform.position) < 1.2f)
            {

                Player.take = false;
                take = false;

            }
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
            if (Vector3.Distance(Hand.transform.position, Player.transform.position) < 1.2f)
                Hand.transform.position = Vector3.Lerp(Hand.transform.position, HandOring, 1);


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

















