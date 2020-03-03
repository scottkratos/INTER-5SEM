using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditor : MonoBehaviour
{
    [Header("Constantes:")]
    [Space]
    [SerializeField]
    private GameObject CameraControl;
    [SerializeField]
    private GameObject Collision;
    [SerializeField]
    private GameObject HUD;
    [SerializeField]
    private GameObject Icon;
    [Space]
    [Header("Customiza aqui:")]
    [Space]
    public Material[] materials;
    public LevelEditorObjects[] prefabs;
    public int[] Points;
    private GameObject Preview;
    public Light[] lights;
    public State PlayerState = State.GroundConstruct;
    public List<Vector3> GridPosition = new List<Vector3>();
    public List<GameObject> GridDict = new List<GameObject>();
    public int SelectedIndex;
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
        Preview = Instantiate(prefabs[SelectedIndex].Preview, transform);
        ConstructHUD();
    }

    private void ConstructHUD()
    {
        for (int i = 0; i < HUD.transform.childCount; i++)
        {
            Destroy(HUD.transform.GetChild(i));
        }

        HUD.transform.parent.gameObject.SetActive(PlayerState != State.SelectConstruct);

        switch (PlayerState)
        {
            case State.GroundConstruct:
                for(int i = 0; i < Points[0]; i++)
                {
                    GameObject go = Instantiate(Icon, HUD.transform);
                    go.GetComponent<Image>().sprite = prefabs[i].Tool.sprite;
                }
                break;
            case State.WallsConstruct:
                for (int i = 0; i < Points[0]; i++)
                {
                    GameObject go = Instantiate(Icon, HUD.transform);
                    go.GetComponent<Image>().sprite = prefabs[i].Tool.sprite;
                }
                break;
            case State.Painting:
                for (int i = Points[0] + 1; i < Points[1]; i++)
                {
                    GameObject go = Instantiate(Icon, HUD.transform);
                    go.GetComponent<Image>().sprite = prefabs[i].Tool.sprite;
                }
                break;
            case State.HotZone:
                for (int i = Points[2] + 1; i < Points[3]; i++)
                {
                    GameObject go = Instantiate(Icon, HUD.transform);
                    go.GetComponent<Image>().sprite = prefabs[i].Tool.sprite;
                }
                break;
            case State.Illumination:
                for (int i = Points[1] + 1; i < Points[2]; i++)
                {
                    GameObject go = Instantiate(Icon, HUD.transform);
                    go.GetComponent<Image>().sprite = prefabs[i].Tool.sprite;
                }
                break;
            case State.ColdZone:
                for (int i = Points[3] + 1; i < Points[4]; i++)
                {
                    GameObject go = Instantiate(Icon, HUD.transform);
                    go.GetComponent<Image>().sprite = prefabs[i].Tool.sprite;
                }
                break;
        }
    }
    public void ChangeSelected(int index)
    {
        SelectedIndex = index;
        Destroy(Preview);
        Preview = prefabs[SelectedIndex].Preview;
        ConstructHUD();
    }
    private void Update()
    {
        if (PlayerState != State.SelectConstruct)
        {
            Preview.SetActive(!LevelEditorPlayerMovement.IsAlt);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag != "LEditor" && hit.transform.gameObject.tag != "GhostEditor")
                {
                    gridlock = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));
                    Preview.transform.position = gridlock;
                }
            }
            if (!IsEditing)
                if (LevelEditorPlayerMovement.IsAlt) return;
            Buttons();
            Action();
        }
        else
        {
            switch (PlayerState)
            {
                case State.GroundConstruct:
                    break;
                case State.WallsConstruct:
                    break;
                case State.Illumination:
                    break;
                case State.Painting:
                    break;
                case State.ColdZone:
                    break;
                case State.HotZone:
                    break;
            }
        }
    }
    //quicksave
    //autosave
    private void Action()
    {
        if (IsLMB || IsRMB)
        {
            ConstructEnd = gridlock;
        }
        else
        {
            ConstructInit = gridlock;
        }
    }

    private void Terminate(bool IsConstruct, bool IsWalls)
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

        for (int i = 0; i < x + 1; i++)
        {
            for (int r = 0; r < y + 1; r++)
            {
                for (int j = 0; j < z + 1; j++)
                {
                    float xresult, yresult, zresult;
                    xresult = ConstructInit.x > ConstructEnd.x ? ConstructEnd.x : ConstructInit.x;
                    yresult = ConstructInit.y > ConstructEnd.y ? ConstructEnd.y : ConstructInit.y;
                    zresult = ConstructInit.z > ConstructEnd.z ? ConstructEnd.z : ConstructInit.z;
                    Vector3 grid = new Vector3(xresult + i, yresult + r, zresult + j);
                    if (!IsWalls)
                    {
                        if (IsConstruct)
                        {
                            if (!GridPosition.Contains(grid))
                            {
                                if (SelectedIndex == -1) return;
                                GameObject go = Instantiate(prefabs[SelectedIndex].Normal, transform);
                                go.transform.position = grid;
                                GridPosition.Add(grid);
                                GridDict.Add(go);
                            }
                        }
                        else
                        {
                            if (GridPosition.Contains(grid))
                            {
                                int index;
                                index = GridPosition.IndexOf(grid);
                                Destroy(GridDict[index]);
                                GridPosition.RemoveAt(index);
                                GridDict.RemoveAt(index);
                            }
                        }
                    }
                    else
                    {
                        if (IsConstruct)
                        {
                            if (!GridPosition.Contains(grid))
                            {
                                if (grid.x == ConstructInit.x || grid.x == ConstructEnd.x || grid.z == ConstructInit.z || grid.z == ConstructEnd.z)
                                {
                                    if (SelectedIndex == -1) return;
                                    GameObject go = Instantiate(prefabs[SelectedIndex].Normal, transform);
                                    go.transform.position = grid;
                                    GridPosition.Add(grid);
                                    GridDict.Add(go);
                                }
                            }
                        }
                        else
                        {
                            if (GridPosition.Contains(grid))
                            {
                                if (grid.x == ConstructInit.x || grid.x == ConstructEnd.x || grid.z == ConstructInit.z || grid.z == ConstructEnd.z)
                                {
                                    int index;
                                    index = GridPosition.IndexOf(grid);
                                    Destroy(GridDict[index]);
                                    GridPosition.RemoveAt(index);
                                    GridDict.RemoveAt(index);
                                }
                            }
                        }
                    }
                }
            }
        }
        System.GC.Collect();
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
            Terminate(true, PlayerState == State.WallsConstruct);
        }
        if (Input.GetMouseButtonUp(1) && !IsLMB)
        {
            IsRMB = false;
            Terminate(false, PlayerState == State.WallsConstruct);
        }
        IsEditing = IsLMB || IsRMB;
        if (Input.mouseScrollDelta.y == 1)
        {
            Collision.transform.position = new Vector3(Collision.transform.position.x, Collision.transform.position.y + 1, Collision.transform.position.z);
        }
        else if (Input.mouseScrollDelta.y == -1)
        {
            Collision.transform.position = new Vector3(Collision.transform.position.x, Collision.transform.position.y + -1, Collision.transform.position.z);
        }
    }

    public void ChangeTool(int newstate)
    {
        switch (newstate)
        {
            case 0:
                PlayerState = State.SelectConstruct;
                break;
            case 1:
                PlayerState = State.GroundConstruct;
                break;
            case 2:
                PlayerState = State.WallsConstruct;
                break;
            case 3:
                PlayerState = State.Painting;
                break;
            case 4:
                PlayerState = State.ColdZone;
                break;
            case 5:
                PlayerState = State.HotZone;
                break;
            case 6:
                PlayerState = State.Illumination;
                break;
        }
        ConstructHUD();
        SelectedIndex = -1;
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
    SelectConstruct,
    GroundConstruct,
    WallsConstruct,
    Painting,
    ColdZone,
    HotZone,
    Illumination
}
[System.Serializable]
public class LevelEditorObjects
{
    public GameObject Normal;
    public GameObject Preview;
    public Image Tool;
}
