using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Vector3 input;
    LayerMask water, Puzzle, portal;
    [HideInInspector]
    public bool jumpBool, vision;
    public float vel;
    [HideInInspector]
    public float x, y, maxX, Jump, maxJump;
    [HideInInspector]
    public Rigidbody rigidbodyPlayer;
    [HideInInspector]
    public Transform hand, cameraTransform, checkGround;
    Animator setAnimacao;
    public LayerMask JumpLayerMask;
    public GameObject power;
    [HideInInspector]
    public GameObject Ice;
    public Texture2D[] cursores;
    [HideInInspector]
    public Vector3 CameraController;
    [HideInInspector]
    public int index, portalIndex, ShotIndex, animationIndex;
    public GameObject[] portais;
    public GameObject[] shotWater;
    public GameObject[] vasos;
    CharacterController characterController;
    Ray eyes;
    RaycastHit hit;
    bool inHand, take;
    Rigidbody hitPortal;









    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        setAnimacao = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        inHand = power.GetComponent<Orbit>().InHand;
        power = GameObject.FindGameObjectWithTag("Power");
        Ice = GameObject.FindGameObjectWithTag("Ice");
        checkGround = GameObject.FindGameObjectWithTag("CheckGraound").transform;
        water = LayerMask.GetMask("Water");
        Puzzle = LayerMask.GetMask("Puzzle");
        portal = LayerMask.GetMask("Portal");
        hand = GameObject.FindGameObjectWithTag("Hand").transform;
        cameraTransform = Camera.main.transform;
        Jump = 0;
        index = -1;
        animationIndex = -1;
        take = false;
        characterController.detectCollisions = false;

    }
    void Update()
    {
        MouseConfi();
        inputs();
        Config();
        interacao();
        Debug.Log(FindObjectOfType<WaterMoviment>().maxy);

    }
    //animacoes
    // void animacao()
    // {
    //     if (input != Vector3.zero)
    //     {
    //         setAnimacao.SetFloat("walking", 1);
    //     }
    //     else
    //     {
    //         setAnimacao.SetFloat("walking", 0);
    //     }
    //
    // }
    //configuracao do mose
    void MouseConfi()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(cursores[0], Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;


    }
    //interacao com objetos 
    void interacao()
    {

        eyes = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(cameraTransform.position, cameraTransform.transform.forward, 10, water) == false &&
            Physics.Raycast(hand.position, hand.transform.forward, 5, Puzzle) == false && power.GetComponent<Orbit>().InHand == true)
        {
            ShotIndex++;
            shotWater[ShotIndex].transform.position = hand.transform.position;
            shotWater[ShotIndex].SetActive(true);
            index--;




        }
        //interacao com a agua
        if (Physics.Raycast(cameraTransform.position, cameraTransform.transform.forward, 10, water))
        {
            Cursor.SetCursor(cursores[1], Vector2.zero, CursorMode.Auto);
            if (Input.GetMouseButtonDown(0))
            {
                ShotIndex--;
                power.transform.position = transform.position * 2;
                index++;

            }


        }
        //intercao com puzzle
        if (Physics.Raycast(cameraTransform.position, cameraTransform.transform.forward, 10, Puzzle))
        {
            Cursor.SetCursor(cursores[1], Vector2.zero, CursorMode.Auto);

            if (Input.GetMouseButtonDown(0) && FindObjectOfType<WaterMoviment>().maxy == false && FindObjectOfType<Orbit>().InHand == true)
            {
                index--;
                ShotIndex++;
                animationIndex++;

                for (int i = 0; i < vasos.Length; i++)
                {
                    if (hit.rigidbody == vasos[i].gameObject.GetComponent<Rigidbody>())
                    {
                        switch (animationIndex)
                        {
                            case 0:
                                vasos[i].GetComponent<WaterMoviment>().anim.SetBool("WaterBool", true);

                                break;
                            case 1:
                                vasos[i].GetComponent<WaterMoviment>().anim.speed = 1;

                                break;

                            case 2:
                                vasos[i].GetComponent<WaterMoviment>().anim.speed = 1;

                                break;

                            case 3:
                                vasos[i].GetComponent<WaterMoviment>().anim.speed = 1;

                                break;

                            case 4:
                                vasos[i].GetComponent<WaterMoviment>().anim.speed = 1;

                                break;




                        }

                    }


                }


            }
            if (Input.GetMouseButtonDown(1) && FindObjectOfType<WaterMoviment>().maxy == false)
            {
                index++;
                ShotIndex--;
                for (int i = 0; i < vasos.Length; i++)
                {
                    if (hit.rigidbody == vasos[i].gameObject.GetComponent<Rigidbody>() && index < 4)
                    {
                        // vasos[i].GetComponent<WaterMoviment>().anim.Play();
                    }
                }






            }






        }
        //Ray para indentificar objetos que podem ser movidos
        if (Physics.Raycast(eyes, out hit) && Input.GetKeyDown(KeyCode.E))
        {

            GameObject objeto = hit.rigidbody.gameObject;
            objeto.GetComponent<TakeObject>().take = true;






        }

        //intercao com os portais
        if (Physics.Raycast(hand.position, hand.transform.forward, 20, portal))
        {
            Cursor.SetCursor(cursores[1], Vector2.zero, CursorMode.Auto);
            if (Physics.Raycast(eyes, out hit) && Input.GetMouseButtonDown(0) && FindObjectOfType<Orbit>().InHand == true)
            {

                portalIndex++;
                switch (portalIndex)
                {
                    case 1:
                        portais[0].SetActive(true);
                        break;
                    case 2:
                        portais[1].SetActive(true);
                        break;
                    case 3:
                        portais[0].SetActive(true);
                        portalIndex = 1;
                        break;
                }
                if (portalIndex == 1)
                {
                    portais[0].transform.position = hit.rigidbody.position;
                    portais[0].transform.rotation = hit.rigidbody.rotation;
                }
                if (portalIndex == 2)
                {
                    portais[1].transform.position = hit.rigidbody.position;
                    portais[1].transform.rotation = hit.rigidbody.rotation;
                }
            }
        }
        //Ray para indentificar e movimentar gelo
        if (Physics.Raycast(eyes, out hit) && hit.rigidbody == Ice.GetComponent<Rigidbody>())
        {
            Cursor.SetCursor(cursores[1], Vector2.zero, CursorMode.Auto);
            if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<IceArea>().Gelo.transform.position = hand.position;
                FindObjectOfType<IceArea>().Gelo.GetComponent<Rigidbody>().isKinematic = true;
                FindObjectOfType<IceArea>().inHand = true;
                FindObjectOfType<IceArea>().transform.parent = hand.transform;
            }
        }
        if (Input.GetMouseButtonDown(1) && FindObjectOfType<IceArea>().inHand == true)
        {
            //FindObjectOfType<IceArea>().Gelo.transform.position = hand.position;
            FindObjectOfType<IceArea>().Gelo.GetComponent<Rigidbody>().isKinematic = false;
            FindObjectOfType<IceArea>().inHand = false;
            FindObjectOfType<IceArea>().transform.parent = null;
        }
        // Ativacao da orbis 
        switch (index)
        {
            case -1:
                power.SetActive(true);
                FindObjectOfType<Orbit>().Orbis[0].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[1].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[2].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[3].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[4].SetActive(false);
                power.GetComponent<Orbit>().InHand = false;
                break;


            case 0:

                power.GetComponent<Orbit>().InHand = true;
                FindObjectOfType<Orbit>().Orbis[0].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[1].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[2].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[3].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[4].SetActive(false);
                break;


            case 1:
                FindObjectOfType<Orbit>().Orbis[0].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[1].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[2].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[3].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[4].SetActive(false);
                break;
            case 2:
                FindObjectOfType<Orbit>().Orbis[0].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[1].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[2].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[3].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[4].SetActive(false);
                break;
            case 3:
                FindObjectOfType<Orbit>().Orbis[0].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[1].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[2].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[3].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[4].SetActive(false);
                break;
            case 4:
                FindObjectOfType<Orbit>().Orbis[0].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[1].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[2].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[3].SetActive(true);
                FindObjectOfType<Orbit>().Orbis[4].SetActive(true);
                break;
        }


    }
    // configuracao para Gameplayer
    void Config()
    {
        // numero maximo de bolhas d'agua
        if (index >= 4)
        {
            index = 4;
        }
        // numero minimo de disparos
        if (index <= -1)
        {
            index = -1;
        }
        if (ShotIndex >= 4)
        {
            ShotIndex = 4;
        }
        // numero minimo de dissparos
        if (ShotIndex <= -1)
        {
            ShotIndex = -1;
        }
    }
    //Input de comando 
    void inputs()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (isGrounded() == true && Input.GetButtonDown("Jump"))
        {
            Jump = Mathf.Sqrt(1.5f * -2f * -10f);
        }
        else
        {

            Jump += -10 * Time.deltaTime;
        }
        CameraController += new Vector3(Input.GetAxis("Mouse Y") * 2, Input.GetAxis("Mouse X") * 2, 0);
        maxX = Mathf.Clamp(CameraController.x, -50, 50);
        input = (x * cameraTransform.right + y * cameraTransform.forward) * vel * Time.deltaTime;
        characterController.Move(new Vector3(input.x, Jump * Time.deltaTime, input.z));
        cameraTransform.transform.rotation = Quaternion.Euler(-maxX, CameraController.y, 0);
        transform.rotation = Quaternion.Euler(0, CameraController.y, 0);
    }
    // verifica se o personagem está no ar; 
    bool isGrounded()
    {
        return Physics.CheckSphere(checkGround.position, 0.7f, JumpLayerMask);


    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }



















}








































































































































































