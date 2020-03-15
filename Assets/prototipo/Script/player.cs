using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    Vector3 input;
    LayerMask water, Puzzle, portal;
    public bool jumpBool, vision;
    public float vel;
    [HideInInspector]
    public float x, y, maxX, Jump, maxJump;
    public Rigidbody rigidbodyPlayer;
    public Transform cameraTransform, hand;
    Animator setAnimacao;
    public LayerMask JumpLayerMask;
    public GameObject portaA, portaB, poder;
    public Texture2D curso, curso2;
    [HideInInspector]
    public Vector3 CameraController;
    [HideInInspector]
    public int index, portalIndex;
    public GameObject[] portais;
    CapsuleCollider CapsuleCollider;
    public GameObject waterShot;
    Ray eyes;





    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        setAnimacao = GetComponent<Animator>();
        CapsuleCollider = GetComponent<CapsuleCollider>();
        water = LayerMask.GetMask("Water");
        Puzzle = LayerMask.GetMask("Puzzle");
        portal = LayerMask.GetMask("Portal");
        Jump = 0;
        index = -1;
        //portalIndex = -1;


    }
    void Update()
    {
        MouseConfi();
        inputs();
        animacao();
        Config();
        interacao();
        Debug.Log(transform.localRotation.eulerAngles.y);






    }
    private void FixedUpdate()
    {
        rigidbodyPlayer.transform.position += new Vector3(input.x, Jump, input.z);
        rigidbodyPlayer.transform.rotation = Quaternion.Euler(0, CameraController.y, 0);
        cameraTransform.transform.rotation = Quaternion.Euler(-maxX, CameraController.y, 0);
        if (isGrounded() && jumpBool)
        {
            rigidbodyPlayer.velocity = Vector3.zero;
            rigidbodyPlayer.AddForce(Vector3.up * 10, ForceMode.Impulse);
            maxJump = transform.position.y + 1;
        }
        if (isGrounded() == false && transform.position.y > maxJump)
        {
            rigidbodyPlayer.AddForce(Vector3.down * 1f, ForceMode.Impulse);
        }






    }
    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.NameToLayer("Water") == 1)
        {
            rigidbodyPlayer.mass = 0.5f;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {


    }
    //animacoes
    void animacao()
    {
        if (input != Vector3.zero)
        {
            setAnimacao.SetFloat("walking", 1);
        }
        else
        {
            setAnimacao.SetFloat("walking", 0);
        }

    }
    //configuracao do mose
    void MouseConfi()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(curso, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;


    }
    //interacao com objetos 
    void interacao()
    {
        RaycastHit hit;
        eyes = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && vision == false && FindObjectOfType<Orbit>().InHand == true)
        {
            Instantiate(waterShot, hand.transform.position, Quaternion.identity);
            index--;
        }
        //interacao com a agua
        if (Physics.Raycast(hand.position, hand.transform.forward, 5, water))
        {
            Cursor.SetCursor(curso2, Vector2.zero, CursorMode.Auto);
            vision = true;
            if (Input.GetMouseButtonDown(0))
            {
                poder.transform.position = transform.position * 2;
                index++;
            }

        }
        else
        {
            vision = false;
        }
        //intercao com puzzle
        if (Physics.Raycast(hand.position, hand.transform.forward, 5, Puzzle))
        {
            Cursor.SetCursor(curso2, Vector2.zero, CursorMode.Auto);

            if (Input.GetMouseButtonDown(0) && FindObjectOfType<WaterMoviment>().maxy == false && FindObjectOfType<Orbit>().InHand == true)
            {
                index--;
                FindObjectOfType<WaterMoviment>().Y += 0.5f;

            }
            if (Input.GetMouseButtonDown(1) && FindObjectOfType<WaterMoviment>().maxy == false)
            {
                if (index < 4)
                {
                    index++;
                    FindObjectOfType<WaterMoviment>().Y -= 0.5f;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {

            }


        }
        //intercao com os portais
        if (Physics.Raycast(hand.position, hand.transform.forward, 5, portal))
        {
            Cursor.SetCursor(curso2, Vector2.zero, CursorMode.Auto);

           

        }
        // Ativacao da orbis 
        switch (index)
        {
            case -1:
                poder.SetActive(true);
                FindObjectOfType<Orbit>().Orbis[0].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[1].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[2].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[3].SetActive(false);
                FindObjectOfType<Orbit>().Orbis[4].SetActive(false);
                poder.GetComponent<Orbit>().InHand = false;
                break;


            case 0:

                poder.GetComponent<Orbit>().InHand = true;
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
        //Ray para indentificar objetos que podem ser movidos
        if (Physics.Raycast(eyes, out hit) && hit.rigidbody.tag == "Vaso" && Input.GetKeyDown(KeyCode.E) && FindObjectOfType<Orbit>().InHand == false)
        {

            GameObject objeto = GameObject.FindGameObjectWithTag("Vaso");
            objeto.transform.parent = cameraTransform.transform;

        }
        if (Physics.Raycast(eyes, out hit) && hit.rigidbody.tag == "Ice")
        {
            Cursor.SetCursor(curso2, Vector2.zero, CursorMode.Auto);
            if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<IceArea>().Gelo.transform.position = hand.position;
                FindObjectOfType<IceArea>().Gelo.GetComponent<Rigidbody>().isKinematic = true;
                FindObjectOfType<IceArea>().inHand = true;

            }
        }
        if (Physics.Raycast(eyes, out hit) && hit.rigidbody.tag == "Portal" && Input.GetMouseButtonDown(0))
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
    // configuracao para Gameplayer
    void Config()
    {
        // numero maximo de bolhas d'agua
        if (index >= 4)
        {
            index = 4;
        }
        // numero minimo de bolhas d'agua
        if (index <= -1)
        {
            index = -1;
        }
    }
    //Input de comando 
    void inputs()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        jumpBool = Input.GetButton("Jump");
        CameraController += new Vector3(Input.GetAxis("Mouse Y") * 2, Input.GetAxis("Mouse X") * 2, 0);
        maxX = Mathf.Clamp(CameraController.x, -50, 50);
        input = (x * cameraTransform.right + y * cameraTransform.forward) * vel * Time.deltaTime;

    }
    // verifica se o personagem está no ar; 
    bool isGrounded()
    {
        return Physics.CheckCapsule(CapsuleCollider.bounds.center, new Vector3(CapsuleCollider.bounds.center.x, CapsuleCollider.bounds.min.y,
            CapsuleCollider.bounds.center.z), CapsuleCollider.radius * .9f, JumpLayerMask);


    }



}








































































































































































