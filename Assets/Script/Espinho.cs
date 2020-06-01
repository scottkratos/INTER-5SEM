using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinho : MonoBehaviour
{
    public bool button, tempo, anguloX, anguloY, anguloZ, Positivo, ButtonAct;
    Vector3 posicao;
    float tempoDuracao, tempoFinal;

    // Start is called before the first frame update
    void Start()
    {
        posicao = transform.localPosition;
        tempoDuracao = 3;
    }

    // Update is called once per frame
    void Update()
    {

        tempoFinal += Time.deltaTime;
        if (tempo == true)
        {
            espinhoTempo();
        }
        if (button == true)
        {
            espinhoButton();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ButtonAct = !ButtonAct;
        }
    }
    void espinhoTempo()
    {
        if (tempo && anguloY)
        {
            if (tempoDuracao >= tempoFinal)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y - 2f, posicao.z), .5f);
                if (tempoDuracao * 2 <= tempoFinal)
                    tempoFinal = 0;
            }

        }
        if (tempo && anguloX && Positivo == false)
        {
            if (tempoDuracao >= tempoFinal)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x - 2f, posicao.y, posicao.z), .5f);
                if (tempoDuracao * 2<= tempoFinal)
                    tempoFinal = 0;
            }

        }
        if (tempo && anguloX && Positivo == true)
        {
            if (tempoDuracao >= tempoFinal)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x + 2f, posicao.y, posicao.z), .5f);
                if (tempoDuracao * 2 <= tempoFinal)
                    tempoFinal = 0;
            }

        }
        if (tempo && anguloZ && Positivo == false)
        {
            if (tempoDuracao >= tempoFinal)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z - 2f), .5f);
                if (tempoDuracao * 2 <= tempoFinal)
                    tempoFinal = 0;
            }

        }
        if (tempo && anguloZ && Positivo == true)
        {
            if (tempoDuracao >= tempoFinal)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z + 2f), .5f);
                if (tempoDuracao * 2 <= tempoFinal)
                    tempoFinal = 0;
            }

        }

    }
    void espinhoButton()
    {
        if (anguloY)
        {
            if (ButtonAct == false)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            if (ButtonAct == true)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y - 2.3f, posicao.z), .5f);

            }

        }
        if (anguloX && Positivo == false)
        {
            if (ButtonAct == false)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            if (ButtonAct == true)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x - 2.3f, posicao.y, posicao.z), .5f);
                if (tempoDuracao * 2 <= tempoFinal)
                    tempoFinal = 0;
            }

        }
        if (anguloX && Positivo == true)
        {
            if (ButtonAct == false)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            if (ButtonAct == true)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x + 2.3f, posicao.y, posicao.z), .5f);
                if (tempoDuracao * 2 <= tempoFinal)
                    tempoFinal = 0;
            }

        }
        if (anguloZ && Positivo == false)
        {
            if (ButtonAct == false)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            if (ButtonAct == true)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z - 2.3f), .5f);

            }

        }
        if (anguloZ && Positivo == true)
        {
            if (ButtonAct == false)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z), 0.5f);

            }
            if (ButtonAct == true)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(posicao.x, posicao.y, posicao.z + 2.3f), .5f);

            }

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Morre");
            LevelLoader.Instance.LoadGameScene();
        }
    }
}
