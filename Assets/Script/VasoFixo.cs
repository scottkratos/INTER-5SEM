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
       

        
        if (NotWater == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Water", false);

        }
    }
}
