using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid : MonoBehaviour
{
    [HideInInspector]
    public bool GridOrdem, SaveOrdem;
    public bool Plataforma, button, gramofono;
    Animator GridMoviment;
    Vector3 posicao;
    public GameObject[] gramofonos;
    public GameObject[] buttons;
    public int level;
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

        if (gramofono == true && button == false)
        {
            // movimento de grades e paredes 
            switch (level)
            {

                case 0:
                    if (Plataforma == false && gramofonos.All(gramofone => gramofone == gramofone.GetComponent<Gramofone>().GridOrdem == true))
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y - 16, posicao.z), .05f);
                    }
                    if (Plataforma == false && gramofonos.All(gramofone => gramofone == gramofone.GetComponent<Gramofone>().GridOrdem == false))
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), .05f);
                    }
                    break;
                case 8:
                    if (Plataforma == false && gramofonos[0].GetComponent<Gramofone>().GridOrdem == true && gramofonos[1].GetComponent<Gramofone>().GridOrdem == true)
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), .05f);
                    }
                    if (Plataforma == false && gramofonos[0].GetComponent<Gramofone>().GridOrdem == false && gramofonos[1].GetComponent<Gramofone>().GridOrdem == true)
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), .05f);
                    }
                    if (Plataforma == false && gramofonos[0].GetComponent<Gramofone>().GridOrdem == true && gramofonos[1].GetComponent<Gramofone>().GridOrdem == false)
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), .05f);
                    }
                    if (Plataforma == false && gramofonos.All(gramofone => gramofone == gramofone.GetComponent<Gramofone>().GridOrdem == false))
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y - 16, posicao.z), .05f);
                    }
                    break;
                case 16:
                    if (Plataforma == false && gramofonos.All(gramofone => gramofone == gramofone.GetComponent<Gramofone>().GridOrdem == true))
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y - 7, posicao.z), .05f);
                    }
                    if (Plataforma == false && gramofonos.All(gramofone => gramofone == gramofone.GetComponent<Gramofone>().GridOrdem == false))
                    {
                        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), .05f);
                    }
                    break;



            }




            // Plataforma submersas 
            if (Plataforma == true && gramofonos.All(gramofone => gramofone == gramofone.GetComponent<Gramofone>().GridOrdem == true))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), .05f);

            }
            if (Plataforma == true && gramofonos.All(gramofone => gramofone == gramofone.GetComponent<Gramofone>().GridOrdem == false))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y - 2, posicao.z), .05f);
            }



        }
        if (button == true && gramofono == false)
        {

            if (Plataforma == false && buttons.All(button => button == button.GetComponent<Button>().GridOrdem == true))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y - 16, posicao.z), .05f);
            }
            if (Plataforma == false && buttons.All(button => button == button.GetComponent<Button>().GridOrdem == false))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), .05f);
            }




        }
        if (gramofono == true && button == true)
        {

            if (Plataforma == false && buttons.All(button => button == button.GetComponent<Button>().GridOrdem == true) || gramofonos.All(gramofone => gramofone == gramofone.GetComponent<Gramofone>().GridOrdem == true))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y - 16, posicao.z), .05f);
            }
            if (Plataforma == false && buttons.All(button => button == button.GetComponent<Button>().GridOrdem == false) || gramofonos.All(gramofone => gramofone == gramofone.GetComponent<Gramofone>().GridOrdem == false))
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), .05f);
            }




        }










    }
}








