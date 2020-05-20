using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    public GameObject posicao_inicial, posicao_final, canhao;
    public float AnguloX, anguloY, anguloZ, TempoDePausa;
    float velX, velY, velZ;
    float posFinal, pos;
    Vector3 tragetoriaInicial, tragetoriaFinal;
    bool Destino, rotation;
    public bool RotacaoEmX, RotacaoEmY, RotacaoEmZ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movimento();
        if (RotacaoEmX)
            rotacaoX();
        if (RotacaoEmY)
            rotacaoy();
        if (RotacaoEmZ)
            rotacaoZ();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(posicao_inicial.transform.position, posicao_final.transform.position);

    }
    void movimento()
    {

        if (Destino == false)
        {
            tragetoriaInicial = Vector3.Lerp(canhao.transform.position, posicao_final.transform.position, .1f);
            canhao.transform.position = tragetoriaInicial;
            if (Vector3.Distance(canhao.transform.position, posicao_final.transform.position) < 0.1f)
                Invoke("Destinoinical", TempoDePausa);
        }
        if (Destino == true)
        {
            tragetoriaFinal = Vector3.Lerp(canhao.transform.position, posicao_inicial.transform.position, .1f);
            canhao.transform.position = tragetoriaFinal;
            if (Vector3.Distance(canhao.transform.position, posicao_inicial.transform.position) < 0.1f)
                Invoke("Destinofinal", TempoDePausa);
        }
    }
    void rotacaoX()
    {
        StartCoroutine(RotacaoX());
        canhao.transform.rotation = Quaternion.Euler(canhao.transform.rotation.x + velX, canhao.transform.rotation.eulerAngles.y, canhao.transform.rotation.eulerAngles.z);
    }
    void rotacaoy()
    {
        StartCoroutine(RotacaoY());
        canhao.transform.rotation = Quaternion.Euler(canhao.transform.rotation.eulerAngles.x, canhao.transform.rotation.y + velY, canhao.transform.rotation.eulerAngles.z);
    }
    void rotacaoZ()
    {
        StartCoroutine(RotacaoZ());
        canhao.transform.rotation = Quaternion.Euler(canhao.transform.rotation.eulerAngles.x, canhao.transform.rotation.eulerAngles.y, canhao.transform.rotation.z + velZ);
    }
    IEnumerator RotacaoX()
    {

        yield return new WaitForSeconds(0.1f);
        if (rotation == false)
        {
            yield return new WaitForSeconds(0.1f);
            velX -= 1;
            if (velX <= -AnguloX)
                rotation = true;
        }
        yield return new WaitForSeconds(0.1f);
        if (rotation == true)
        {
            yield return new WaitForSeconds(0.1f);
            velX += 1;
            if (velX >= AnguloX)
                rotation = false;
        }

    }
    IEnumerator RotacaoY()
    {

        yield return new WaitForSeconds(0.1f);
        if (rotation == false)
        {
            yield return new WaitForSeconds(0.1f);
            velY -= 1;
            if (velY <= -anguloY)
                rotation = true;
        }
        yield return new WaitForSeconds(0.1f);
        if (rotation == true)
        {
            yield return new WaitForSeconds(0.1f);
            velY += 1;
            if (velY >= anguloY)
                rotation = false;
        }

    }
    IEnumerator RotacaoZ()
    {

        yield return new WaitForSeconds(0.1f);
        if (rotation == false)
        {
            yield return new WaitForSeconds(0.1f);
            velZ -= 1;
            if (velZ <= -anguloZ)
                rotation = true;
        }
        yield return new WaitForSeconds(0.1f);
        if (rotation == true)
        {
            yield return new WaitForSeconds(0.1f);
            velZ += 1;
            if (velZ >= anguloZ)
                rotation = false;
        }

    }
    void Destinoinical()
    {
        Destino = true;
    }
    void Destinofinal()
    {
        Destino = false;
    }







}
