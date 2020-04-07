using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public bool GridOrdem, SaveOrdem;
    Animator GridMoviment;
    Vector3 posicao;


    // Start is called before the first frame update
    void Start()
    {
        GridMoviment = GetComponent<Animator>();
        posicao = transform.localPosition;
        SaveOrdem = GridOrdem;
    }

    // Update is called once per frame
    void Update()
    {

        if (GridOrdem == true)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y - 8, posicao.z), .5f);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), .5f);
        }
    }
}








