using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTranform : MonoBehaviour
{
    float y = .3f;
    float yEvaporation;
    [HideInInspector]
    public float AmountWater;

    public GameObject Gelo, player;
    public bool take, inHand;
    //public GameObject Vapor;
    // public ParticleSystem vapor;
    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<player>().gameObject;
        transform.position = player.transform.GetChild(0).transform.GetChild(1).transform.position;
        take = false;
        transform.localScale = new Vector3(1.5f, y, 1.5f);
        StartCoroutine("size");
    }

    // Update is called once per frame
    void Update()
    {
        if (take == false)
        {
            transform.parent = player.transform.GetChild(0).transform.GetChild(3).transform;
            transform.position = player.transform.GetChild(0).transform.GetChild(3).transform.position;
            GetComponent<Rigidbody>().isKinematic = true;

        }
        if (take == true)
        {
            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = false;

        }

    }
    //altera o tamnho do objeto
    IEnumerator size()
    {
        while (true)
        {
            player.GetComponent<player>().index = -1;
            player.GetComponent<player>().ShotIndex = 4;
            yield return new WaitForSeconds(0.1f);
            if (transform.localScale.y < 1.5f)
            {
                y += 0.1f;
            }
            transform.localScale = new Vector3(1.5f, y, 1.5f);
            if (transform.localScale.y >= 1.5f)
            {
                StopCoroutine("size");
            }
        }
    }
    IEnumerator evaporation()
    {
        while (true)
        {
            // vapor.Play();
            yield return new WaitForSeconds(0.5f);
            if (transform.localScale.y > 0.1f)
            {
                y -= 0.1f;
            }
            transform.localScale = new Vector3(1.5f, y, 1.5f);
            if (transform.localScale.y <= .1f)
            {
                StopCoroutine("evaporation");
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Portal" && this.gameObject.tag != "Player")
        {

           // transform.position = other.GetComponent<teleport>().reciever.gameObject.transform.GetChild(0).transform.position;
            take = true;
            GetComponent<BoxCollider>().enabled = false;
            Invoke("Kinematic", .6f);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
    void KinematicOn()
    {

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
    }
    void Kinematic()
    {

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<BoxCollider>().enabled = true;
    }
}
