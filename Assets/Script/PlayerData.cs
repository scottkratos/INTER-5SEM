using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public float[] indexLevel;
    public float[] rotation;
    public bool cutSceneLoad;

    public PlayerData(player player)
    {

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        indexLevel = new float[3];
        if (player.gameObject.scene.buildIndex != 0)
        {
            indexLevel[0] = player.gameObject.scene.buildIndex;
            indexLevel[1] = player.gameObject.scene.buildIndex + 1;
            indexLevel[2] = player.gameObject.scene.buildIndex - 1;

        }
        rotation = new float[3];
        rotation[0] = player.transform.rotation.eulerAngles.x;
        rotation[1] = player.transform.rotation.eulerAngles.y;
        rotation[2] = player.transform.rotation.eulerAngles.z;
        cutSceneLoad = player.CutSceneLoad;


    }



}
