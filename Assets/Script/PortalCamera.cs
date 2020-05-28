using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera, portal, otherPortal;
    Vector3 newCameraDirection;
    private void Start()
    {
        playerCamera = FindObjectOfType<player>().transform.GetChild(0).transform;
    }
    void Update()
    {
        // transform.position = otherPortal.position;
        float angularDifferenceBetweenPortalRotation = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationaDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotation, Vector3.up);
        // newCameraDirection = portalRotationaDifference * -playerCamera.forward;
        // transform.rotation = Quaternion.LookRotation(new Vector3(newCameraDirection.x, newCameraDirection.y, newCameraDirection.z), Vector3.up);
        // transform.rotation = Quaternion.Euler(FindObjectOfType<player>().maxX, FindObjectOfType<player>().CameraController.y, 0);




    }











}



