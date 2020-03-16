using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTranform : MonoBehaviour
{
    float y = 0.1f;
    float yEvaporation;
    [HideInInspector]
    public float AmountWater;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //altera o tamnho do objeto
    IEnumerator size()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (transform.localScale.y < AmountWater)
            {

                y += 0.1f;
                transform.localScale = new Vector3(0.5f, y, 0.5f);
            }
        }
    }
    IEnumerator evaporation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (transform.localScale.y > 0.1f)
            {
                y -= 0.1f;
                transform.localScale = new Vector3(0.5f, y, 0.5f);

            }
        }
    }















}
