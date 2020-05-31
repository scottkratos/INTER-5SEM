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
       // if (portal.transform.forward.z == -1 || otherPortal.transform.forward.z == -1)
       // {
       //     Vector3 playerOffset = playerCamera.position - otherPortal.position;
       //     float zOffset = playerOffset.z * portal.forward.z >= -0.1f ? playerOffset.z * portal.forward.z : -0.1f;
       //     transform.position = portal.position - new Vector3(-playerOffset.x / 3, -playerOffset.y + 0.3f, zOffset / 3);
       // }
       // else
       // {
       //     Vector3 playerOffset = playerCamera.position - otherPortal.position;
       //     float zOffset = playerOffset.z >= 0.1f ? playerOffset.z : 0.1f;
       //     transform.position = portal.position - new Vector3(playerOffset.x / 3, -playerOffset.y + 0.3f, -zOffset / 3);
       // }
        float angularDifferenceBetweenPortalRotation = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotationaDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotation, Vector3.up);
        newCameraDirection = portalRotationaDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(new Vector3(-newCameraDirection.x, newCameraDirection.y, -newCameraDirection.z), Vector3.up);
    }
}



