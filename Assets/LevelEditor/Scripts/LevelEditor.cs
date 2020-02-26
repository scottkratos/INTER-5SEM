using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public Material[] materials;
    public GameObject[] prefabs;
    public Light[] lights;
    public GameObject[] props;
    public State PlayerState = State.GroundConstruct;
}

public enum State
{
    GroundConstruct,
    Painting,
    PlacingPrefabs,
    PlacingProps
}
