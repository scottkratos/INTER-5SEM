using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canhao : MonoBehaviour
{
    public GameObject posicao_inicial, posicao_final, canhao;
    public float vel;
    float posFinal, pos;
    Vector3 tragetoriaInicial, tragetoriaFinal;
    bool Destino, rotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movimento();
        rotacao();

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
                Invoke("Destinoinical", .5f);
        }
        if (Destino == true)
        {
            tragetoriaFinal = Vector3.Lerp(canhao.transform.position, posicao_inicial.transform.position, .1f);
            canhao.transform.position = tragetoriaFinal;
            if (Vector3.Distance(canhao.transform.position, posicao_inicial.transform.position) < 0.1f)
                Invoke("Destinofinal", .5f);
        }
    }
    void rotacao()
    {
        StartCoroutine(sentindoRotacao());
        canhao.transform.rotation = Quaternion.Euler(canhao.transform.rotation.x, vel, canhao.transform.rotation.z);





    }
    IEnumerator sentindoRotacao()
    {

        yield return new WaitForSeconds(.5f);
        while (rotation == false)
        {
            yield return new WaitForSeconds(.5f);
            vel += 1;
            if (vel == 45)
            {
                rotation = true;

            }

        }
        yield return new WaitForSeconds(.5f);
        while (rotation == true)
        {
            yield return new WaitForSeconds(.5f);
            vel -= 1;
            if (vel == -45)
            {
                rotation = false;

            }

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
