using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShooter : MonoBehaviour
{
    public SphereCollider shotWater, wallCollider;
    public LayerMask puzzle;

    // Start is called before the first frame update
    void Start()
    {
        shotWater = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(0.1f, 0, 0) + FindObjectOfType<player>().cameraTransform.forward;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Physics.IgnoreCollision(shotWater, wallCollider, true);

        }

    }
    bool ShotArea()
    {
        return Physics.CheckCapsule(shotWater.bounds.center, new Vector3(shotWater.bounds.center.x, shotWater.bounds.min.y, shotWater.bounds.center.z), shotWater.radius * .9f, puzzle);
    }











}
