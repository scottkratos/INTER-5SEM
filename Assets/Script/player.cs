using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Playables;

public class player : MonoBehaviour
{
    public GameObject CheatMenu;
    Vector3 input, velocity;
    public LayerMask water, Puzzle, portal, Ice;
    [HideInInspector]
    public bool jumpBool, vision, take;
    public float vel, Sensitivity;
    [HideInInspector]
    public float x, y, maxX, Jump, maxJump, gravidade, Speed;
    [HideInInspector]
    public Rigidbody rigidbodyPlayer;
    [HideInInspector]
    public Transform hand, cameraTransform, checkGround;
    Animator setAnimacao;
    public LayerMask JumpLayerMask;
    public GameObject power, handTrue;
    //[HideInInspector]
    //public GameObject Ice;
    // [HideInInspector]
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
    public CanvasRenderer Menu, load;
    public GameObject Pausa;
    public static player Instance;
    public bool CutsceneMode, CutSceneLoad;
    private AudioListener audioSource;
    Transform handOring;
    public PlayableDirector Timeline;
    bool isContinue;
    float loadtime;

    private void Awake()
    {
        Instance = this;
        rigidbodyPlayer = GetComponent<Rigidbody>();
        setAnimacao = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        inHand = power.GetComponent<Orbit>().InHand;
        power = GameObject.FindGameObjectWithTag("Power");
        // Ice = GameObject.FindGameObjectWithTag("Ice");
        checkGround = GameObject.FindGameObjectWithTag("CheckGraound").transform;
        water = LayerMask.GetMask("Water");
        Puzzle = LayerMask.GetMask("Puzzle");
        portal = LayerMask.GetMask("Portal");
        Ice = LayerMask.GetMask("Ice");
        hand = GameObject.FindGameObjectWithTag("Hand").transform;
        handTrue = GameObject.FindGameObjectWithTag("HandTrue");
        isContinue = false;
        cameraTransform = Camera.main.transform;
        Jump = 2;
        index = -1;
        animationIndex = -1;
        gravidade = -50f;
        ShotIndex = -1;
        characterController.detectCollisions = false;
        audioSource = GetComponentInChildren<AudioListener>();
        take = false;
    }
    private void Start()
    {
        handOring = GameObject.FindGameObjectWithTag("HandTrue").transform;
    }
    void Update()
    {
        transform.GetChild(0).gameObject.SetActive(!CutsceneMode);
        transform.GetChild(2).gameObject.SetActive(!CutsceneMode);
        if (CutsceneMode) return;
        if (isContinue == false)
        {
            transform.GetChild(0).transform.gameObject.SetActive(!CutsceneMode);
            transform.GetChild(2).transform.gameObject.SetActive(!CutsceneMode);
            audioSource.enabled = !CutsceneMode;

        }
        else
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
            transform.GetChild(2).transform.gameObject.SetActive(true);
            audioSource.enabled = true;

        }
        if (Pausa.activeInHierarchy == true || CheatMenu.activeInHierarchy)
        {
            if (Pausa.activeInHierarchy == true)
            {
                Time.timeScale = 0;
            }
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            MouseConfi();
            inputs();
            Config();
            interacao();
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CheatMenu.activeSelf)
            {
                CheatMenu.SetActive(false);
            }
            else
            {
                if (Pausa.activeSelf)
                {
                    if (Pausa.transform.GetChild(0).gameObject.activeSelf)
                    {
                        Pausa.SetActive(false);
                    }
                    else if (Pausa.transform.GetChild(1).gameObject.activeSelf)
                    {
                        Pausa.transform.GetChild(0).gameObject.SetActive(true);
                        Pausa.transform.GetChild(1).gameObject.SetActive(false);
                    }
                    else if (Pausa.transform.GetChild(2).gameObject.activeSelf)
                    {
                        Pausa.transform.GetChild(1).gameObject.SetActive(true);
                        Pausa.transform.GetChild(2).gameObject.SetActive(false);
                    }
                    else if (Pausa.transform.GetChild(3).gameObject.activeSelf)
                    {
                        Pausa.transform.GetChild(1).gameObject.SetActive(true);
                        Pausa.transform.GetChild(3).gameObject.SetActive(false);
                    }
                }
                else
                {
                    Pausa.transform.GetChild(0).gameObject.SetActive(true);
                    Pausa.transform.GetChild(1).gameObject.SetActive(false);
                    Pausa.transform.GetChild(2).gameObject.SetActive(false);
                    Pausa.transform.GetChild(3).gameObject.SetActive(false);
                    Pausa.SetActive(true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Pausa.activeSelf) return;
            CheatMenu.SetActive(!CheatMenu.activeSelf);
            CheatMenu.transform.GetChild(0).gameObject.SetActive(true);
            CheatMenu.transform.GetChild(1).gameObject.SetActive(false);
            CheatMenu.transform.GetChild(2).gameObject.SetActive(false);
        }



    }
    //configuracao do mouse
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
        if (Input.GetMouseButtonDown(0) && power.GetComponent<Orbit>().InHand == true)
        {
            ShotIndex = 4;
            foreach (var item in shotWater)
            {
                item.transform.position = hand.transform.position;
                item.gameObject.SetActive(true);
            }
            index = -1;
        }

        //interacao com a agua
        if (Physics.Raycast(cameraTransform.position, cameraTransform.transform.forward, 3f, water) && take == false)
        {
            cursor[0].enabled = false;
            cursor[1].enabled = true;

            if (Input.GetMouseButtonDown(1))
            {
                ShotIndex = 0;
                power.transform.parent = hand;
                index = 4;
            }
        }
        if (Physics.Raycast(eyes, out hit, 5) && take == false && hit.transform.tag == "VasoFixo" && power.GetComponent<Orbit>().InHand == false && hit.transform.GetComponent<VasoFixo>().GetComponent<Animator>().GetBool("Water") == true)
        {
            cursor[0].enabled = false;
            cursor[1].enabled = true;
            if (Input.GetMouseButtonDown(1))
            {
                hit.transform.gameObject.GetComponent<VasoFixo>().GetComponent<Animator>().SetBool("Water", false);
                ShotIndex = 0;
                index = 4;

            }
        }
        //Ray para indentificar objetos que podem ser movidos
        if (Physics.Raycast(eyes, out hit, 5) && hit.transform.gameObject.GetComponent<TakeObject>() != null && power.GetComponent<Orbit>().InHand == false)
        {
            if (hit.transform.gameObject.GetComponent<TakeObject>() != null)
            {
                cursor[1].enabled = true;
                objectsMove = hit.transform.gameObject;
            }
            else
            {
                cursor[0].enabled = true;
            }
            //objetos que podem ser movidos
            if (Input.GetKeyDown(KeyCode.E) && objectsMove.GetComponent<TakeObject>() != null)
            {
                objectsMove.GetComponent<TakeObject>().take = !objectsMove.GetComponent<TakeObject>().take;

                take = !take;
            }
        }
        //intercao com os portais
        if (Physics.Raycast(hand.position, hand.transform.forward, portal))
        {
            if (Physics.Raycast(eyes, out hit) && Input.GetMouseButtonDown(0) && FindObjectOfType<Orbit>().InHand == true && hit.collider.tag == "ParedePortal")
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
                Vector3 newPosition = new Vector3(hit.rigidbody.position.x, hit.rigidbody.position.y, hit.rigidbody.position.z) + hit.rigidbody.transform.forward.normalized * .2f;
                bool portalCreated = false;
                if (portalIndex == 1)
                {
                    if (newPosition != portais[1].transform.position)
                    {
                        portais[0].transform.position = newPosition;
                        portais[0].transform.rotation = hit.rigidbody.transform.parent.transform.rotation;

                        portalCreated = true;
                    }
                }
                if (portalIndex == 2)
                {
                    if (newPosition != portais[0].transform.position)
                    {
                        portais[1].transform.position = newPosition;
                        portais[1].transform.rotation = hit.rigidbody.transform.parent.transform.rotation;

                        portalCreated = true;
                    }
                }
                if (!portalCreated)
                {
                    portalIndex--;
                }
            }

        }
        //intercao com o gelo
        if (Physics.Raycast(eyes, out hit, 5) && Input.GetKeyDown(KeyCode.E) && hit.collider.transform.tag != null)
        {
            if (hit.collider.transform.tag == "Ice")
            {
                if (hit.collider.GetComponent<IceTranform>() != null)
                    hit.collider.GetComponent<IceTranform>().take = !hit.collider.GetComponent<IceTranform>().take;
                if (hit.collider.GetComponent<iceZona>() != null)
                    hit.collider.GetComponent<iceZona>().take = !hit.collider.GetComponent<iceZona>().take;
            }


        }
        //intercao com o zona de gelo
        if (Physics.Raycast(eyes, out hit) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.transform.tag == "ZonaDeFrio")
            {
                Instantiate(hit.collider.GetComponent<IceArea>().gelo, hit.collider.GetComponent<IceArea>().transform.GetChild(8).transform).SetActive(true);
                foreach (var item in shotWater)
                {
                    item.gameObject.SetActive(false);
                }
            }
            if (hit.collider.transform.tag == "ZonaDeCalor")
            {
                hit.collider.GetComponent<FireArea>().transform.GetChild(7).GetComponent<ParticleSystem>().Play();
                foreach (var item in shotWater)
                {
                    item.gameObject.SetActive(false);
                }
            }

        }
        //interacao com vaso fixo
        if (Physics.Raycast(eyes, out hit) && hit.collider.transform.tag == "VasoFixo" && Input.GetMouseButtonDown(0))
        {
            hit.transform.gameObject.GetComponent<VasoFixo>().gameObject.GetComponent<Animator>().SetBool("Water", true);
            hit.transform.gameObject.GetComponent<VasoFixo>().NotWater = false;
        }

        if (Physics.Raycast(eyes, out hit) && hit.collider.transform.tag == "Canhao" && Input.GetMouseButtonDown(0))
        {
            foreach (var item in shotWater)
            {
                item.SetActive(false);
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
        if (CameraController.x > 90)
        {
            CameraController.x = 90;
        }
        if (CameraController.x < -90)
        {
            CameraController.x = -90;
        }

    }
    //Inputs de comandos da Gameplay
    void inputs()
    {
        //handTrue.transform.position = handOring.position;
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (isGrounded() && velocity.y < 0)
        {
            velocity = new Vector3(0, -5f, 0);
        }
        maxX = Mathf.Clamp(CameraController.x, -90, 90);
        CameraController += new Vector3(Input.GetAxis("Mouse Y") * Sensitivity, Input.GetAxis("Mouse X") * Sensitivity, 0);
        if (CameraController.x >= 60)
        {
            input = (x * cameraTransform.right + y * -cameraTransform.up) * vel * Time.deltaTime;
        }
        else if (CameraController.x <= -60 && CameraController.x <= -45)
        {
            input = (x * cameraTransform.right + y * cameraTransform.up) * vel * Time.deltaTime;
        }
        else
        {
            input = (x * cameraTransform.right + y * cameraTransform.forward) * vel * Time.deltaTime;

        }
        velocity.y += gravidade * Time.deltaTime;
        if (isGrounded() && Input.GetButtonDown("Jump") && input != Vector3.zero)
        {
            velocity = new Vector3(input.x + vel * Time.deltaTime, Mathf.Sqrt(Jump * -2 * gravidade), input.z + vel * Time.deltaTime);
        }
        else if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            velocity = new Vector3(0, Mathf.Sqrt(Jump * -2 * gravidade), 0);
        }
        characterController.Move(new Vector3(input.x, 0, input.z));
        characterController.Move(velocity * Time.deltaTime);
        cameraTransform.transform.localRotation = Quaternion.Euler(-maxX, CameraController.y, 0);
        transform.rotation = Quaternion.Euler(0, CameraController.y, 0);

    }
    //atualiza jogador apos load 
    public void LoadPlayer()
    {
        //isContinue = true;
        //PlayerData data = LoadGame.LoadPlayer();
        //Vector3 position;
        //position.x = data.position[0];
        //position.y = data.position[1];
        //position.z = data.position[2];
        //Vector3 rotation;
        //rotation.x = data.rotation[0];
        //rotation.y = data.rotation[1];
        //rotation.z = data.rotation[2];
        //CameraController = rotation;
        //transform.position = position;

    }
    // verifica se o personagem está no ar; 
    bool isGrounded()
    {
        return Physics.CheckSphere(checkGround.position, .3f, JumpLayerMask);
    }
    IEnumerator ShotInHand()
    {
        yield return new WaitForSeconds(0.5f);
        power.GetComponent<Orbit>().InHand = false;

    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Porta")
        {

            index = -1;
            ShotIndex = -1;
            foreach (var item in portais)
            {
                item.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Morte")
        {
            LevelLoader.Instance.LoadGameScene();

        }
    }
}