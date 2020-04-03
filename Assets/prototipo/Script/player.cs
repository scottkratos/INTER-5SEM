using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Vector3 input;
    LayerMask water, Puzzle, portal;
    [HideInInspector]
    public bool jumpBool, vision, take;
    public float vel;
    [HideInInspector]
    public float x, y, maxX, Jump, maxJump;
    [HideInInspector]
    public Rigidbody rigidbodyPlayer;
    [HideInInspector]
    public Transform hand, cameraTransform, checkGround;
    Animator setAnimacao;
    public LayerMask JumpLayerMask;
    public GameObject power, handTrue;
    [HideInInspector]
    public GameObject Ice;
    [HideInInspector]
    public Vector3 CameraController;
    [HideInInspector]
    public int index, portalIndex, ShotIndex, animationIndex;
    public GameObject[] portais;
    public GameObject[] shotWater;
    CharacterController characterController;
    public Ray eyes;
    public RaycastHit hit;
    [HideInInspector]
    public bool inHand;
    Rigidbody hitPortal;
    public Image[] cursor;
    GameObject objectsMove;

    private void Awake()
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
        handTrue = GameObject.FindGameObjectWithTag("HandTrue");
        cameraTransform = Camera.main.transform;
        Jump = 0;
        index = -1;
        animationIndex = -1;
        ShotIndex = -1;
        characterController.detectCollisions = false;

    }
    void Update()
    {
        MouseConfi();
        inputs();
        Config();
        interacao();
    }
    //configuracao do mose
    void MouseConfi()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cursor[0].enabled = true;
        cursor[1].enabled = false;
    }
    //interacao com objetos 
    void interacao()
    {
        //direcao da ray de visao
        eyes = Camera.main.ScreenPointToRay(Input.mousePosition);
        //atira 
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(cameraTransform.position, cameraTransform.transform.forward, 10, water) == false && power.GetComponent<Orbit>().InHand == true)
        {
            ShotIndex = 4;
            if (ShotIndex < 5)
            {
                shotWater[ShotIndex].transform.position = hand.transform.position;
                shotWater[ShotIndex].SetActive(true);
            }
            index = -1;
        }
        //interacao com a agua
        if (Physics.Raycast(cameraTransform.position, cameraTransform.transform.forward, 1, water))
        {
            cursor[0].enabled = false;
            cursor[1].enabled = true;
            if (Input.GetMouseButtonDown(1) && take == false)
            {
                ShotIndex = 0;
                power.transform.position = transform.position * 2;
                index = 4;
            }
        }
        //Ray para indentificar objetos que podem ser movidos
        if (Physics.Raycast(eyes, out hit, 2) && hit.transform.GetComponent<TakeObject>() != null)
        {
            cursor[0].enabled = false;
            cursor[1].enabled = true;
            if (take == false)
                objectsMove = hit.transform.gameObject;
        }
        //objetos que podem ser movidos
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(objectsMove.transform.position, transform.position) < 2.5f)
        {
            objectsMove.GetComponent<TakeObject>().take = !objectsMove.GetComponent<TakeObject>().take;
            take = !take;
        }
        //intercao com os portais
        if (Physics.Raycast(hand.position, hand.transform.forward, 20, portal))
        {
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
        // Ativacao da orbis 
        switch (index)
        {
            case -1:
                power.SetActive(true);
                power.GetComponent<Orbit>().Orbis[0].SetActive(false);
                power.GetComponent<Orbit>().Orbis[1].SetActive(false);
                power.GetComponent<Orbit>().Orbis[2].SetActive(false);
                power.GetComponent<Orbit>().Orbis[3].SetActive(false);
                power.GetComponent<Orbit>().Orbis[4].SetActive(false);
                StartCoroutine(ShotInHand());
                break;
            case 0:
                power.GetComponent<Orbit>().InHand = true;
                power.GetComponent<Orbit>().Orbis[0].SetActive(true);
                power.GetComponent<Orbit>().Orbis[1].SetActive(false);
                power.GetComponent<Orbit>().Orbis[2].SetActive(false);
                power.GetComponent<Orbit>().Orbis[3].SetActive(false);
                power.GetComponent<Orbit>().Orbis[4].SetActive(false);
                break;
            case 1:
                power.GetComponent<Orbit>().InHand = true;
                power.GetComponent<Orbit>().Orbis[0].SetActive(true);
                power.GetComponent<Orbit>().Orbis[1].SetActive(true);
                power.GetComponent<Orbit>().Orbis[2].SetActive(false);
                power.GetComponent<Orbit>().Orbis[3].SetActive(false);
                power.GetComponent<Orbit>().Orbis[4].SetActive(false);
                break;
            case 2:
                power.GetComponent<Orbit>().InHand = true;
                power.GetComponent<Orbit>().Orbis[0].SetActive(true);
                power.GetComponent<Orbit>().Orbis[1].SetActive(true);
                power.GetComponent<Orbit>().Orbis[2].SetActive(true);
                power.GetComponent<Orbit>().Orbis[3].SetActive(false);
                power.GetComponent<Orbit>().Orbis[4].SetActive(false);
                break;
            case 3:
                power.GetComponent<Orbit>().InHand = true;
                power.GetComponent<Orbit>().Orbis[0].SetActive(true);
                power.GetComponent<Orbit>().Orbis[1].SetActive(true);
                power.GetComponent<Orbit>().Orbis[2].SetActive(true);
                power.GetComponent<Orbit>().Orbis[3].SetActive(true);
                power.GetComponent<Orbit>().Orbis[4].SetActive(false);
                break;
            case 4:
                power.GetComponent<Orbit>().InHand = true;
                power.GetComponent<Orbit>().Orbis[0].SetActive(true);
                power.GetComponent<Orbit>().Orbis[1].SetActive(true);
                power.GetComponent<Orbit>().Orbis[2].SetActive(true);
                power.GetComponent<Orbit>().Orbis[3].SetActive(true);
                power.GetComponent<Orbit>().Orbis[4].SetActive(true);
                StopCoroutine(ShotInHand());
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
        if (ShotIndex >= 5)
        {
            ShotIndex = 5;
        }
        // numero minimo de dissparos
        if (ShotIndex <= -1)
        {
            ShotIndex = -1;
        }
        if (animationIndex > 5)
        {
            animationIndex = -1;
        }
        // numero minimo de dissparos
        if (animationIndex < -1)
        {
            animationIndex = 5;
        }
        if (CameraController.x > 45)
        {
            CameraController.x = 45;
        }
        if (CameraController.x < -45)
        {
            CameraController.x = -45;
        }

    }
    //Inputs de comandos da Gameplay
    void inputs()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (isGrounded() && Jump < 0)
        {
            Jump = -5;
        }
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            Jump = Mathf.Sqrt(2f * -2f * -10f);
        }
        Jump += -10 * Time.deltaTime;


        maxX = Mathf.Clamp(CameraController.x, -45, 45);
        CameraController += new Vector3(Input.GetAxis("Mouse Y") * 2, Input.GetAxis("Mouse X") * 2, 0);
        input = (x * cameraTransform.right + y * cameraTransform.forward) * vel * Time.deltaTime;
        characterController.Move(new Vector3(input.x, Jump * Time.deltaTime, input.z));
        cameraTransform.transform.localRotation = Quaternion.Euler(-maxX, CameraController.y, 0);
        transform.rotation = Quaternion.Euler(0, CameraController.y, 0);
    }
    // verifica se o personagem está no ar; 
    bool isGrounded()
    {
        return Physics.CheckSphere(checkGround.position, .2f, JumpLayerMask);
    }
    IEnumerator ShotInHand()
    {
        yield return new WaitForSeconds(0.5f);
        power.GetComponent<Orbit>().InHand = false;
    }


}

































































































































































































































































