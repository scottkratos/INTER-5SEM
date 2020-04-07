using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoviment : MonoBehaviour
{
    float x, z, maxZ, maxX;

    
    void Awake()
    {
        maxZ = transform.position.z - 0.3f;
        maxX = transform.position.x + 5f;
    }
    public IEnumerator Open()
    {

        while (true)
        {
            yield return new WaitForSeconds(2);
            if (transform.position.z > maxZ)
            {
                z -= 0.0001f;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + z);
            }
            else
            {
                z = 0;
            }
            yield return new WaitForSeconds(0.5f);
            if (transform.position.x < maxX)
            {
                x += 0.0001f;
                transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z);
            }
            else
            {
                x = 0;
            }

        }

    }









   
}
