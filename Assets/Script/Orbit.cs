using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject hand;
    public GameObject[] Orbis;
    public GameObject center;
    LayerMask puzzle, water;
    float time;
    public float speed, amplitudeX, amplitudeY, amplitudeZ;
    [HideInInspector]
    public bool InHand;


    private void Awake()
    {
        hand = GameObject.FindGameObjectWithTag("Hand");
        InHand = false;
        puzzle = LayerMask.GetMask("Puzzle");
        water = LayerMask.GetMask("water");
    }



    void Update()
    {

        center.transform.position = hand.transform.position;
        time += Time.deltaTime * speed;
        ConfigOrbitais();
        if (InHand == true)
        {
            foreach (GameObject orbi in Orbis)
            {
                orbi.GetComponent<SphereCollider>().enabled = false;
            }
        }
        else
        {
            foreach (GameObject orbi in Orbis)
            {
                orbi.GetComponent<SphereCollider>().enabled = true;
            }
        }
    }
    void rotation(GameObject planet, float amplitudeX, float amplitudeY, float amplitudeZ)
    {
        float X = Mathf.Cos(time) * amplitudeX;
        float Y = Mathf.Sin(time) * amplitudeY;
        float Z = Mathf.Sin(time) * amplitudeZ;
        Vector3 pos = new Vector3(X, Y, Z);
        planet.transform.position = pos + center.transform.position;
    }
    void ConfigOrbitais()
    {
        if (Orbis[1])
        {
            rotation(Orbis[1], amplitudeX, amplitudeY, amplitudeZ);
            Orbis[1].transform.LookAt(center.transform);
        }
        if (Orbis[2])
        {
            rotation(Orbis[2], -amplitudeX, -amplitudeY, amplitudeZ);
            Orbis[2].transform.LookAt(center.transform);
        }
        if (Orbis[3])
        {
            rotation(Orbis[3], amplitudeX, -amplitudeY, -amplitudeZ);
            Orbis[3].transform.LookAt(center.transform);
        }
        if (Orbis[4])
        {
            rotation(Orbis[4], amplitudeX, amplitudeY, -amplitudeZ);
            Orbis[4].transform.LookAt(center.transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "ZonaDeCalor")
        {
            gameObject.SetActive(false);

        }

    }








}




























































