using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasoFixo : MonoBehaviour
{
    Ray oring;
    public RaycastHit hit;
    Transform Player;
    public bool NotWater;
    public bool defaultWater;

    private void Awake()
    {
        Player = FindObjectOfType<player>().transform;
        defaultWater = NotWater;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        oring = Player.GetComponent<player>().eyes;

        if (Physics.Raycast(oring, out hit, 4))
        {
            if (Input.GetMouseButtonDown(1) && hit.transform.tag == "VasoFixo" && FindObjectOfType<Orbit>().InHand == false && hit.transform.GetComponent<VasoFixo>().GetComponent<Animator>().GetBool("Water") == true)
            {
                hit.transform.gameObject.GetComponent<VasoFixo>().GetComponent<Animator>().SetBool("Water", false);
                Player.GetComponent<player>().ShotIndex = 0;
                Player.GetComponent<player>().index = 4;
            }

        }
        if (NotWater == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Water", false);

        }
    }
}
