using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CutSceneData
{
    public int index;


    public CutSceneData(CutscenePrepare cutsceneControl)
    {
        index = cutsceneControl.index;
        //level = cutsceneControl.gameObject.scene.buildIndex;
    }
}
