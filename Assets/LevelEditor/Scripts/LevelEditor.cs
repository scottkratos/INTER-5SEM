using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    [SerializeField]
    private GameObject CameraControl;
    [SerializeField]
    private GameObject FollowMouse;
    public Material[] materials;
    public GameObject[] prefabs;
    public Light[] lights;
    public GameObject[] props;
    public State PlayerState = State.GroundConstruct;
    public List<Vector3> GridPosition = new List<Vector3>();
    public List<GameObject> GridDict = new List<GameObject>();
    private bool IsRMB;
    private bool IsLMB;
    public static bool IsEditing;
    private Vector3 ConstructInit;
    private Vector3 ConstructEnd;
    private Vector3 gridlock;

    private void Start()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("LEditor"))
        {
            GridPosition.Add(go.transform.position);
            GridDict.Add(go);
        }
    }

    private void Update()
    {
        FollowMouse.SetActive(!LevelEditorPlayerMovement.IsAlt);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag != "LEditor" && hit.transform.gameObject.tag != "GhostEditor")
            {
                gridlock = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));
                FollowMouse.transform.position = gridlock;
            }
        }
        if (!IsEditing)
            if (LevelEditorPlayerMovement.IsAlt) return;
        Buttons();
        Action();
    }
    //quicksave
    //autosave
    private void Action()
    {
        if (IsLMB)
        {
            ConstructEnd = gridlock;
        }
        else
        {
            ConstructInit = gridlock;
        }
    }

    private void Terminate()
    {
        float x, y, z;
        Vector2 xi, yi, zi, xf, yf, zf;
        xi = new Vector2(ConstructInit.x, 0);
        yi = new Vector2(ConstructInit.y, 0);
        zi = new Vector2(ConstructInit.z, 0);
        xf = new Vector2(ConstructEnd.x, 0);
        yf = new Vector2(ConstructEnd.y, 0);
        zf = new Vector2(ConstructEnd.z, 0);
        x = Vector2.Distance(xi, xf);
        y = Vector2.Distance(yi, yf);
        z = Vector2.Distance(zi, zf);
        for (int i = 0; i < x; i++)
        {
            for (int r = 0; r < y; r++)
            {
                for (int j = 0; j < z; j++)
                {
                    GameObject go = Instantiate(prefabs[0], transform);
                    go.transform.position = new Vector3(ConstructInit.x + i, ConstructInit.y + r, ConstructInit.z + j);
                }
            }
        }
    }
    private void Buttons()
    {
        if (Input.GetMouseButtonDown(0) && !IsRMB)
        {
            IsLMB = true;
        }
        if (Input.GetMouseButtonDown(1) && !IsLMB)
        {
            IsRMB = true;
        }
        if (Input.GetMouseButtonUp(0) && !IsRMB)
        {
            IsLMB = false;
            Terminate();
        }
        if (Input.GetMouseButtonUp(1) && !IsLMB)
        {
            IsRMB = false;
            Terminate();
        }
        IsEditing = IsLMB || IsRMB;
    }

    public void ChangeTool(int newstate)
    {
        switch (newstate)
        {
            case 0:
                PlayerState = State.GroundConstruct;
                break;
            case 1:
                PlayerState = State.Painting;
                break;
            case 2:
                PlayerState = State.PlacingPrefabs;
                break;
            case 3:
                PlayerState = State.PlacingProps;
                break;
        }
    }

    public void ResetCam(int newstate)
    {
        switch (newstate)
        {
            case 0:
                Quaternion rotation = Quaternion.Euler(15, -45, 0);
                CameraControl.transform.rotation = rotation;
                break;
            case 1:
                CameraControl.transform.position = new Vector3(0, 0, 0);
                CameraControl.transform.GetChild(0).transform.position = new Vector3(0, 0, -10);
                break;
        }
    }
}

public enum State
{
    GroundConstruct,
    Painting,
    PlacingPrefabs,
    PlacingProps
}
