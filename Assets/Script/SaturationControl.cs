using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SaturationControl : MonoBehaviour
{
    public static float lastIndex = 0;
    private Volume vol;
    private ColorAdjustments ca;

    private void Start()
    {
        vol = GetComponent<Volume>();
        if (LoadGame.LoadCutscene() != null)
        {
            CutSceneData dataCut = LoadGame.LoadCutscene();
            lastIndex = dataCut.index - 1;
        }
    }
    private void Update()
    {
        //ca.saturation.value = Mathf.Lerp(10, -30, lastIndex / 32);
        if (vol.profile.TryGet<ColorAdjustments>(out ca))
        {
            ca.saturation.value = Mathf.Lerp(10, -30, lastIndex / 32f);
        }
    }
}
