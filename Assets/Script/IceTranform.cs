using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTranform : MonoBehaviour
{
    float y = 0.1f;
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
        transform.localScale = new Vector3(0.3f, y, 0.3f);
        StartCoroutine("size");
    }

    // Update is called once per frame
    void Update()
    {
        if (take == false)
        {
            transform.position = player.transform.GetChild(0).transform.GetChild(1).transform.position;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        if (take == true)
        {
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
            if (transform.localScale.y < .5f)
            {
                y += 0.1f;
            }
            transform.localScale = new Vector3(0.3f, y, 0.3f);
            if (transform.localScale.y >= .5f)
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
            transform.localScale = new Vector3(0.3f, y, 0.3f);
            if (transform.localScale.y <= .1f)
            {
                StopCoroutine("evaporation");
                Destroy(gameObject);
            }
        }
    }
}
