using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    public GameObject posicao_inicial, posicao_final, canhao, agua;
    public float Angulo, TempoDePausa;
    float vel, velY, velZ;
    float posFinal, pos;
    Vector3 tragetoriaInicial, tragetoriaFinal, aguaInicial;
    Quaternion rotationOring;
    public bool DestinoInicial, rotation, rotationR, DestinoFinal;
    public bool RotacaoEmX, RotacaoEmY, RotacaoEmZ, movimentoOn, disparo;
    RaycastHit hit;
    Vector3 RayOring;
    // Start is called before the first frame update
    void Start()
    {
        rotationOring = transform.rotation;
        aguaInicial = agua.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotation)
        {
            vel = Angulo;

        }
        if (rotationR)
        {
            vel = -Angulo;

        }
        if (rotation == false && rotationR == false)
        {
            vel = rotationOring.x;

        }
        if (disparo)
        {
            agua.SetActive(true);

            agua.transform.Translate(-.8f, 0, 0);




            if (Physics.Raycast(transform.GetChild(0).transform.position, transform.GetChild(0).transform.up, out hit))
            {
                if (hit.collider.tag == "Canhao")
                {
                    hit.collider.GetComponent<Canhao>().disparo = true;
                }
                if (hit.transform.tag == "Vaso")
                {
                    hit.transform.gameObject.GetComponent<Vaso>().animator.SetBool("WaterBool", true);
                }
                if (hit.transform.tag == "Gramofone")
                {
                    hit.transform.gameObject.GetComponent<Gramofone>().animator.SetBool("WaterBool", true);
                }
            }
            Invoke("disparoR", .1f);
        }
        if (Physics.Raycast(transform.GetChild(0).transform.position, transform.GetChild(0).transform.up, out hit))
        {
            if (hit.collider.tag == "Portal")
            {
                Debug.Log("portal");
                if (hit.collider.gameObject.GetComponent<teleport>().reciever != null)
                {

                    if (hit.collider.gameObject.GetComponent<teleport>().reciever.gameObject.transform.eulerAngles.y == 90 || hit.collider.gameObject.GetComponent<teleport>().reciever.gameObject.transform.eulerAngles.y == -90)
                    {
                        GameObject outherPortal = hit.collider.gameObject.GetComponent<teleport>().reciever;
                        outherPortal.gameObject.transform.GetChild(1).GetComponent<teleport>().rayDirecion.origin = new Vector3(outherPortal.gameObject.transform.GetChild(1).GetComponent<teleport>().rayDirecion.origin.x, hit.point.y, hit.point.z);

                    }
                    else
                    {
                        // hit.collider.gameObject.GetComponent<teleport>().reciever.gameObject.GetComponent<teleport>().rayDirecion.origin = new Vector3(hit.point.x, hit.point.y, hit.collider.gameObject.GetComponent<teleport>().reciever.gameObject.GetComponent<teleport>().rayDirecion.origin.z);

                    }

                    
                }






            }



        }
        rotacao();
        rotacaoR();
        if (movimentoOn)
            movimento();
        Debug.DrawRay(transform.GetChild(0).transform.position, transform.GetChild(0).transform.up, Color.blue, 5);




    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(posicao_inicial.transform.position, posicao_final.transform.position);

    }
    void movimento()
    {

        if (DestinoFinal == true)
        {
            tragetoriaInicial = Vector3.Lerp(canhao.transform.position, posicao_final.transform.position, .1f);
            canhao.transform.position = tragetoriaInicial;

        }
        if (DestinoInicial == true)
        {
            tragetoriaFinal = Vector3.Lerp(canhao.transform.position, posicao_inicial.transform.position, .1f);
            canhao.transform.position = tragetoriaFinal;

        }

    }
    void rotacao()
    {

        if (RotacaoEmX == true)
        {

            canhao.transform.rotation = Quaternion.Euler(vel, canhao.transform.rotation.eulerAngles.y, canhao.transform.rotation.eulerAngles.z);

        }
        if (RotacaoEmY == true)
        {

            canhao.transform.rotation = Quaternion.Euler(canhao.transform.rotation.eulerAngles.x, vel, canhao.transform.rotation.z);

        }
        if (RotacaoEmZ == true)
        {

            canhao.transform.rotation = Quaternion.Euler(canhao.transform.rotation.eulerAngles.x, canhao.transform.rotation.eulerAngles.y, vel);

        }
    }
    void rotacaoR()
    {
        if (RotacaoEmX == true)
        {

            canhao.transform.rotation = Quaternion.Euler(vel, canhao.transform.rotation.eulerAngles.y, canhao.transform.rotation.eulerAngles.z);

        }
        if (RotacaoEmY == true)
        {

            canhao.transform.rotation = Quaternion.Euler(canhao.transform.rotation.eulerAngles.x, vel, canhao.transform.rotation.z);

        }
        if (RotacaoEmZ == true)
        {

            canhao.transform.rotation = Quaternion.Euler(canhao.transform.rotation.eulerAngles.x, canhao.transform.rotation.eulerAngles.y, vel);

        }
    }
    IEnumerator Rotacao(float angulo)
    {



        yield return new WaitForSeconds(0.5f);
        if (vel <= angulo)
            vel += 3;
        StopCoroutine(Rotacao(angulo));


    }
    IEnumerator RotacaoR(float angulo)
    {



        yield return new WaitForSeconds(0.5f);
        if (vel >= angulo)
            vel -= 3;
        StopCoroutine(RotacaoR(angulo));


    }
    void disparoR()
    {
        disparo = false;
        agua.SetActive(false);
        agua.transform.position = canhao.transform.position;
    }






}
