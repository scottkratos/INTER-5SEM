using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorPlayerMovement : MonoBehaviour
{
    public static bool IsAlt;
    private bool IsRMB;
    private bool IsLMB;
    private bool IsMMB;
    private Vector2 InitRot;
    private Vector2 InitPos;
    private Vector2 CurrentRot;
    private Vector3 CurrentPos;
    private Vector3 CurrentChildPos;
    private const float rotRate = 100;
    private const float MoveRate = 20;
    private const float ZoomRate = 10;

    private enum MouseInstance
    {
        LeftClick,
        RightClick,
        Scroll,
        Nothing
    }

    private MouseInstance Check()
    {
        if (IsRMB)
        {
            return MouseInstance.RightClick;
        }
        else if (IsLMB)
        {
            return MouseInstance.LeftClick;
        }
        else if (IsMMB)
        {
            return MouseInstance.Scroll;
        }
        else
        {
            return MouseInstance.Nothing;
        }
    }

    private void Update() 
    {
        CheckBools();
        if (!IsAlt) return;
        switch (Check())
        {
            case MouseInstance.LeftClick:
                Quaternion rotation;
                rotation = Quaternion.Euler(CurrentRot.x + (InitRot.y - Camera.main.ScreenToViewportPoint(Input.mousePosition).y) * rotRate, CurrentRot.y + (Camera.main.ScreenToViewportPoint(Input.mousePosition).x - InitRot.x) * rotRate, 0);
                transform.rotation = rotation;
                break;
            case MouseInstance.RightClick:
                Vector3 zoom;
                zoom = new Vector3(InitPos.x - Camera.main.ScreenToViewportPoint(Input.mousePosition).x, InitPos.y - Camera.main.ScreenToViewportPoint(Input.mousePosition).y, 0);
                transform.GetChild(0).transform.position = CurrentChildPos + (transform.GetChild(0).transform.forward * ((zoom.x + zoom.y) * ZoomRate) * -1);
                break;
            case MouseInstance.Scroll:
                Vector3 position;
                position = new Vector3((InitPos.x - Camera.main.ScreenToViewportPoint(Input.mousePosition).x) * MoveRate, (InitPos.y - Camera.main.ScreenToViewportPoint(Input.mousePosition).y) * MoveRate, transform.position.z);
                transform.position = CurrentPos + (transform.right * position.x + transform.up * position.y);
                break;
            case MouseInstance.Nothing:
                CurrentRot = new Vector2(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y);
                CurrentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                CurrentChildPos = new Vector3(transform.GetChild(0).transform.position.x, transform.GetChild(0).transform.position.y, transform.GetChild(0).transform.position.z);
                break;
        }
    }

    private void CheckBools()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            IsAlt = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt))
        {
            IsAlt = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            InitRot = new Vector2(Camera.main.ScreenToViewportPoint(Input.mousePosition).x, Camera.main.ScreenToViewportPoint(Input.mousePosition).y);
            IsLMB = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            IsLMB = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            InitPos = new Vector2(Camera.main.ScreenToViewportPoint(Input.mousePosition).x, Camera.main.ScreenToViewportPoint(Input.mousePosition).y);
            IsRMB = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            IsRMB = false;
        }
        if (Input.GetMouseButtonDown(2))
        {
            InitPos = new Vector2(Camera.main.ScreenToViewportPoint(Input.mousePosition).x, Camera.main.ScreenToViewportPoint(Input.mousePosition).y);
            IsMMB = true;
        }
        if (Input.GetMouseButtonUp(2))
        {
            IsMMB = false;
        }
    }
}
