using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera, portal, otherPortal;
    Vector3 newCameraDirection;
    void Update()
    {
        transform.position = otherPortal.position;
        float angularDifferenceBetweenPortalRotation = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationaDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotation, Vector3.up);
        if (portal.transform.rotation.y < 0)
        {
            newCameraDirection = portalRotationaDifference * playerCamera.forward;
            float Maxy = Mathf.Clamp(newCameraDirection.y, 0, 1);
            transform.rotation = Quaternion.LookRotation(new Vector3(newCameraDirection.x, 0, newCameraDirection.z), Vector3.up);

        }
        if (portal.transform.rotation.y < 0)
        {
            newCameraDirection = portalRotationaDifference * -playerCamera.forward;
            float Maxy = Mathf.Clamp(newCameraDirection.x, -10, 10);
            transform.rotation = Quaternion.LookRotation(new Vector3(Maxy, newCameraDirection.y, newCameraDirection.z), Vector3.up);
            //transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }











}



